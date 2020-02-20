using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnitOfWorkRuleSpecificationRepository;
using UnitOfWorkRuleSpecificationRepository.Models;

//using Fakes;

namespace ORTRulesEngine
{
    public class RuleEngine<T>
    {
        public void ExecuteSpecifications(T ruleUnderTest, string property, string domain)
        {
            IDictionary<string, ISpecification<T>> aDictionary = new Dictionary<string, ISpecification<T>>();

            var specificationsList = GetSpecificationList(property, domain);

            // Set the default Value
            var specification = specificationsList.FirstOrDefault();
            var defaultValue = string.Empty;

            if (specification != null)
            {
                defaultValue = specification.DefaultValue;
            }

            ruleUnderTest.GetType().GetProperty(property).SetValue(ruleUnderTest, defaultValue, null);

            // Join the specifications 
            var joinedSpecifications = JoinSpecifications(specificationsList);

            foreach (var ruleGroup in joinedSpecifications)
            {
                var groupId = ruleGroup.Key;
                specification = specificationsList.FirstOrDefault(o => o.MainGroup == groupId);
                if (specification == null)
                {
                    continue;
                }

                var ruleValue = specification.RuleValue;
                var ruleExpSpec = ruleGroup.Value;

                aDictionary.Add(ruleValue, ruleExpSpec);
            }

            var specificationRuleValue = defaultValue;

            foreach (var ruleValue in from spec in aDictionary
                                      let ruleExpSpec = spec.Value
                                      let ruleValue = spec.Key
                                      where ruleExpSpec.IsSatisfiedBy(ruleUnderTest)
                                      select ruleValue)
            {
                specificationRuleValue = ruleValue;
            }

            ruleUnderTest.GetType().GetProperty(property).SetValue(ruleUnderTest, specificationRuleValue, null);
        }

        private IDictionary<int, ISpecification<T>> JoinSpecifications(IList<SpecificationInfo<T>> specificationsList)
        {
            var retVal = new Dictionary<int, ISpecification<T>>();

            // Get the groups
            var mainGroupList = specificationsList.Select(o => new { o.MainGroup, o.SubGroup })
                .Distinct().OrderBy(o => o.MainGroup).ThenByDescending(o => o.SubGroup).ToList();

            ISpecification<T> mainRuleExpSpec = null;
            var subJoin = "And";
            var groupId = 0;

            foreach (var groupInfo in mainGroupList)
            {
                groupId = groupInfo.MainGroup;
                var subGroupId = groupInfo.SubGroup;
                ISpecification<T> subGroupExpSpec = null;

                // Get all the RuleSpecifications in this sub group
                var subSpecificationInfoList = specificationsList
                    .Where(o => o.MainGroup.Equals(groupId))
                    .Where(o => o.SubGroup.Equals(subGroupId))
                    .OrderByDescending(o => o.SubGroup).ToList();

                foreach (var subSpecificationInfo in subSpecificationInfoList)
                {
                    if (subGroupExpSpec == null)
                    {
                        subGroupExpSpec = subSpecificationInfo.Specification;
                        continue;
                    }

                    // Use the Main join for joining within the sub group
                    // Use the Sub join for joining to existing specifications
                    subJoin = subSpecificationInfo.SubJoin;

                    if (subSpecificationInfo.MainJoin.Equals("And", StringComparison.OrdinalIgnoreCase))
                    {
                        subGroupExpSpec = subGroupExpSpec.And(subSpecificationInfo.Specification);
                    }
                    else
                    {
                        subGroupExpSpec = subGroupExpSpec.Or(subSpecificationInfo.Specification);
                    }
                }

                if (mainRuleExpSpec == null)
                {
                    mainRuleExpSpec = subGroupExpSpec;
                    continue;
                }

                // use the sub join to join to the main group
                if (subJoin == "And")
                {
                    mainRuleExpSpec = mainRuleExpSpec.And(subGroupExpSpec);
                }
                else
                {
                    mainRuleExpSpec = mainRuleExpSpec.Or(subGroupExpSpec);
                }
            }

            retVal.Add(groupId, mainRuleExpSpec);

            return retVal;
        }

        public IList<int> Get_Satisfying_Specfications(T ruleUnderTest, string property, string domain)
        {
            var retVal = new List<int>();

            var specificationsList = GetSpecificationList(property, domain);

            // Get the groups
            var groups = JoinSpecifications(specificationsList);

            foreach (var group in groups)
            {
                var groupId = group.Key;
                var ruleExpSpec = group.Value;

                if (ruleExpSpec.IsSatisfiedBy(ruleUnderTest))
                {
                    retVal.Add(groupId);
                }
            }

            return retVal;
        }

        private List<SpecificationInfo<T>> GetSpecificationList(string property, string domain)
        {
            var connectionString =
                 "Data Source=mn-dev-db13;Initial Catalog=ornticcorprulespecification;Integrated Security=True";

            ICollection<RuleSpecificationComposite> specificationRules;
            var specificationsList = new List<SpecificationInfo<T>>();

            using (var repository = new UowRuleSpecificationRepository(connectionString))
            {
                specificationRules = repository.GetSpecificationRules(property, domain);
            }

            foreach (var (specificationInfoComposite, specificationInfo) in from specificationInfoComposite in specificationRules
                                                                            let specificationInfo = new SpecificationInfo<T>()
                                                                            select (specificationInfoComposite, specificationInfo))
            {
                specificationInfo.ProcessingRuleId = (int)specificationInfoComposite.Id;
                if (!Enum.TryParse(specificationInfoComposite.EvaluationOperator, true, out Operator operation))
                {
                    continue;
                }

                var rule = new Rule(specificationInfoComposite.EvaluationProperty, operation
                   , specificationInfoComposite.EvaluationValue
                   , (int)specificationInfoComposite.Id);
               
                var compiledRule = CompileRule<T>(rule);
                
                var ruleSpecication = new ExpressionSpecification<T>(compiledRule);
                
                specificationInfo.DefaultValue = specificationInfoComposite.DefaultValue;
                specificationInfo.EvalProperty = specificationInfoComposite.EvaluationProperty;
                specificationInfo.MainGroup = specificationInfoComposite.MainGroup;
                specificationInfo.MainJoin = specificationInfoComposite.MainJoin;
                specificationInfo.ProcessingRuleId = (int)specificationInfoComposite.Id;
                specificationInfo.RuleProperty = specificationInfoComposite.RuleSpecificationName;
                specificationInfo.RuleValue = specificationInfoComposite.SpecificationValue;
                specificationInfo.Specification = ruleSpecication;
                specificationInfo.SubGroup = specificationInfoComposite.SubGroup;
                specificationInfo.SubJoin = specificationInfoComposite.SubJoin;
                
                specificationsList.Add(specificationInfo);
            }

            return specificationsList;

        }

        public Func<T, bool> CompileRule<T>(Rule rule)
        {
            if (string.IsNullOrEmpty(rule.PropertyName))
            {
                ExpressionBuilder expressionBuilder = new ExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                Expression expression = expressionBuilder.BuildExpression<T>(rule.Operator_, rule.Value, param);
                Func<T, bool> func = Expression.Lambda<Func<T, bool>>(expression, param).Compile();

                return func;
            }
            else
            {
                ExpressionBuilder expressionBuilder = new ExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                Expression expression = expressionBuilder.BuildExpression<T>(rule.PropertyName, rule.Operator_, rule.Value, param);
                Func<T, bool> func = Expression.Lambda<Func<T, bool>>(expression, param).Compile();
                return func;
            }
        }

    }
}



//private SpecificationInfo<T> GetSpecificationInfo(XElement xmlElement, IDictionary<string, string> viewFieldDictionary)
//{
//    SpecificationInfo<T> specificationInfo = null;
//    Operator operation;
//    //var operationName = GetSpecificationInfo()
//    var operationName = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["Operator"]).Value);
//    var processingRuleId =
//        FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["ProcessingRuleId"]).Value);
//    var evalPropertyName = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["EvalProperty"]).Value);
//    var ruleValue = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["RuleValue"]).Value);
//    var subGroup = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["SubGroup"]).Value);
//    var mainGroup = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["MainGroup"]).Value);
//    var evaluationValue = FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["EvaluationValue"]).Value); //dataRow["Value"];

//    if (Enum.TryParse(operationName, true, out operation))
//    {
//        specificationInfo = new SpecificationInfo<T>();

//        var rule = new Rule(evalPropertyName, operation, evaluationValue, int.Parse(processingRuleId));

//        var compiledRule = CompileRule<T>(rule);
//        var cplSpec = new ExpressionSpecification<T>(compiledRule);

//        specificationInfo.MainJoin =
//            FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["MainJoin"]).Value);
//        specificationInfo.MainGroup = (int)float.Parse(mainGroup);
//        specificationInfo.SubJoin =
//            FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["SubJoin"]).Value);
//        specificationInfo.SubGroup = (int)float.Parse(subGroup);
//        specificationInfo.Specification = cplSpec;
//        specificationInfo.EvalProperty = evalPropertyName;
//        specificationInfo.RuleProperty =
//            FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["RuleProperty"]).Value);
//        specificationInfo.RuleValue = ruleValue;
//        specificationInfo.DefaultValue =
//            FixSPString(xmlElement.Attribute("ows_" + viewFieldDictionary["DefaultValue"]).Value);

//        specificationInfo.ProcessingRuleId = (int)float.Parse(processingRuleId);
//    }

//    return specificationInfo;
//}

//private string FixSPString(string value)
//{
//    if (value.Length > 2 && value.Substring(1, 2) == ";#")
//    {
//        return value.Substring(3);
//    }

//    return value;
//}

//private List<T> GetSpecificationList_SP(string property)
//{
//    // Get These Rules from Sharepoint
//    var specificationsList = new List<T>();

//    var serviceClient = new SharepointListsService.Lists();
//    //var itemKeyField = "Rule_Property";

//    //var xmlDoc = new XmlDocument();
//    //var nodeQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");
//    var xmlQuery = string.Concat(@"<Where><Eq><FieldRef Name='Rule_x0020_Property' /><Value Type='Lookup'>",
//        property, @"</Value></Eq></Where>");
//    var xmlOptions = @"<IncludeMandatoryColumns>False</IncludeMandatoryColumns>";



//    IDictionary<string, string> viewFieldDictionary = new Dictionary<string, string>();
//    viewFieldDictionary.Add("Title", "Title");
//    viewFieldDictionary.Add("EvalProperty", "Evaluation_x0020_Property");
//    viewFieldDictionary.Add("RuleProperty", "Rule_x0020_Property");
//    viewFieldDictionary.Add("MainGroup", "Main_x0020_Group");
//    viewFieldDictionary.Add("Operator", "Operator");
//    viewFieldDictionary.Add("SubGroup", "SubJoin");
//    viewFieldDictionary.Add("MainJoin", "Main_x0020_Rule_x0020_Join");
//    viewFieldDictionary.Add("SubJoin", "Sub_x0020_Join");
//    viewFieldDictionary.Add("RuleValue", "Rule_x0020_Value");
//    viewFieldDictionary.Add("DefaultValue", "Default_x0020_Value");
//    viewFieldDictionary.Add("EvaluationValue", "Evaluation_x0020_Value");
//    viewFieldDictionary.Add("ProcessingRuleId", "ID");

//    StringBuilder sbViewFields = new StringBuilder();
//    foreach (var viewField in viewFieldDictionary)
//    {
//        //<FieldRef Name='Evaluation_x0020_Property' />
//        sbViewFields.Append(string.Concat("<FieldRef Name='", viewField.Value, "' />"));
//    }

//    var xmlViewFields = View_Fields_Node(sbViewFields.ToString());
//    var xmlNodeQuery = Query_Node(xmlQuery);
//    var xmlNodeOptions = Query_Options(xmlOptions);

//    serviceClient.Url = @"https://sharepoint-qua.oldrepublictitle.com/Sites/IS/Dev/_vti_bin/lists.asmx";
//    serviceClient.UseDefaultCredentials = true;

//    var result = serviceClient.GetListItems("CPL Rules", null, xmlNodeQuery, xmlViewFields, null,
//        xmlNodeOptions, null);

//    var xData = XElement.Parse(result.InnerXml);
//    var xmlName = XName.Get("row", "#RowsetSchema");
//    var xmlElements = xData.DescendantsAndSelf(xmlName);

//    foreach (var xmlElement in xmlElements)
//    {
//        var specificationInfo = GetSpecificationInfo(xmlElement, viewFieldDictionary);
//        if (specificationInfo == null)
//        {
//            continue;
//        }

//        //specificationsList.Add(specificationInfo);
//    }

//    return specificationsList;
//}


//public String RemoveNameSpaceFromXml(String xmlString)
//{
//    return xmlString
//        .Replace(String.Concat(@"xmlns:s=""", "uuid:BDC6E3F0-6DA3-11d1-A2A3-00AA00C14882", @""""), "")
//        .Replace(String.Concat(@"xmlns:dt=""", "uuid:C2F41010-65B3-11d1-A29F-00AA00C14882", @""""), "")
//        .Replace(String.Concat(@"xmlns:rs=""", "urn:schemas-microsoft-com:rowset", @""""), "")
//        .Replace(String.Concat(@"xmlns:z=""", "#RowsetSchema", @""""), "")
//        .Replace(String.Concat(@"xmlns=""", @"http://schemas.microsoft.com/sharepoint/soap/workflow/", @""""), "")
//        .Replace(String.Concat(@"xmlns=""", @"http://schemas.microsoft.com/sharepoint/soap/directory/", @""""), "")
//        .Replace(String.Concat(@"xmlns=""", @"http://schemas.microsoft.com/sharepoint/soap/", @""""), "")
//        .Replace("rs:data", "data")
//        .Replace("z:row", "row")
//        .Replace(@"<ToDoData >", @"<ToDoData>")
//        .Replace(@"<xml    >", @"<xml>")
//        .Replace(@"<xml   >", @"<xml>")
//        .Replace(@"<xml  >", @"<xml>")
//        .Replace(@"<xml >", @"<xml>")
//        .Replace(@" >", @">");
//}

//public XmlNode Query_Node(String camlQuery)
//{
//    var xmlDoc = new XmlDocument();
//    var nodeQuery = xmlDoc.CreateNode(XmlNodeType.Element, "Query", "");

//    if (!String.IsNullOrEmpty(camlQuery))
//    {
//        nodeQuery.InnerXml = camlQuery;
//    }

//    return nodeQuery;
//}

//public XmlNode View_Fields_Node(String camlQuery)
//{
//    var xmlDoc = new XmlDocument();
//    var nodeQuery = xmlDoc.CreateNode(XmlNodeType.Element, "ViewFields", "");

//    if (!String.IsNullOrEmpty(camlQuery))
//    {
//        nodeQuery.InnerXml = camlQuery;
//    }

//    return nodeQuery;
//}

//public XmlElement Query_Options(String camlQuery)
//{

//    var xmlDoc = new XmlDocument();
//    var optionsQuery = xmlDoc.CreateElement("QueryOptions");

//    if (!String.IsNullOrEmpty(camlQuery))
//    {
//        optionsQuery.InnerXml = camlQuery;
//    }

//    return optionsQuery;
//}
