using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using Fakes;
using Fakes.FakeRulesDataSetTableAdapters;
using Fakes.Properties;

namespace RulesFakes
{
    public class FakeRuleEngine<T>
    {
        public void ExecuteCPLSpecifications(T adr, string property)
        {
            IDictionary<string, ISpecification<T>> aDictionary = new Dictionary<string, ISpecification<T>>();

            var specificationsList = GetSpecificationList(property);

            // Set the default Value
            var specification = specificationsList.FirstOrDefault();
            var defaultValue = string.Empty;

            if (specification != null)
            {
                defaultValue = specification.DefaultValue;
            }

            adr.GetType().GetProperty(property).SetValue(adr, defaultValue, null);
            // Get the groups and set the value to the rule value if the rule group satisfies

            var ruleGroups = Get_Specification_Groups(specificationsList);
            foreach (var ruleGroup in ruleGroups)
            {
                var groupId = ruleGroup.Key;
                specification = specificationsList.FirstOrDefault(o => o.MainGroup == groupId);
                if (specification == null)
                {
                    continue;
                }

                var ruleValue = specification.RuleValue;
                var cplExpSpec = ruleGroup.Value;

                aDictionary.Add(ruleValue, cplExpSpec);
            }

            var specificationRuleValue = defaultValue;

            foreach (var spec in aDictionary)
            {
                var cplExpSpec = spec.Value;
                var ruleValue = spec.Key;
                var result = cplExpSpec.IsSatisfiedBy(adr);
                if (result)
                {
                    specificationRuleValue = ruleValue;
                    break;
                }
            }

            adr.GetType().GetProperty(property).SetValue(adr, specificationRuleValue, null);
        }

        private IDictionary<int, ISpecification<T>> Get_Specification_Groups(IList<SpecificationInfo<T>> specificationsList)
        {
            var retVal = new Dictionary<int, ISpecification<T>>();

            // Get the groups
            var groupList = specificationsList.Select(o => new
            { o.MainGroup, o.DefaultValue, o.RuleValue }).Distinct().OrderBy(o => o.MainGroup).ToList();

            ISpecification<T> cplExpSpec;

            foreach (var groupInfo in groupList)
            {
                cplExpSpec = null;
                var groupId = groupInfo.MainGroup;

                var specificationInfoList = specificationsList.Where(o => o.MainGroup == groupId);
                var subGroupList = specificationInfoList.Select(o => o.SubGroup).Distinct().ToList();

                foreach (var subGroup in subGroupList)
                {
                    // When the sub group changes, need to record the join for the sub group
                    // Join the sub group first
                    var mainJoin = specificationInfoList.Where(o => o.SubGroup == subGroup).FirstOrDefault().MainJoin;
                    ISpecification<T> subCplExpSpec = null;

                    foreach (var specificationInfo in specificationInfoList.Where(o => o.SubGroup == subGroup))
                    {
                        if (subCplExpSpec == null)
                        {
                            subCplExpSpec = specificationInfo.Specification;
                            continue;
                        }

                        var join = string.IsNullOrEmpty(specificationInfo.SubJoin)
                            ? specificationInfo.MainJoin
                            : specificationInfo.SubJoin;

                        if (join == "And")
                        {
                            subCplExpSpec = subCplExpSpec.And(specificationInfo.Specification);
                        }
                        else
                        {
                            subCplExpSpec = subCplExpSpec.Or(specificationInfo.Specification);
                        }
                    }

                    // Join the sub to the main 
                    if (cplExpSpec == null)
                    {
                        cplExpSpec = subCplExpSpec;
                        continue;
                    }

                    if (mainJoin == "And")
                    {
                        cplExpSpec = cplExpSpec.And(subCplExpSpec);
                    }
                    else
                    {
                        cplExpSpec = cplExpSpec.Or(subCplExpSpec);
                    }
                }

                retVal.Add(groupId, cplExpSpec);
            }

            return retVal;
        }

        public IList<int> Get_Satisfying_Specfications(T cpl, string property)
        {
            var retVal = new List<int>();

            var specificationsList = GetSpecificationList(property);

            // Get the groups
            var groups = Get_Specification_Groups(specificationsList);

            foreach (var group in groups)
            {
                var groupId = group.Key;
                var cplExpSpec = group.Value;

                if (cplExpSpec.IsSatisfiedBy(cpl))
                {
                    retVal.Add(groupId);
                }
            }

            return retVal;
        }

        //public IDictionary<Rule,string> 



        private List<SpecificationInfo<T>> GetSpecificationList(string property)
        {
            // Get These Rules from a database table 
            var ta = new ProcessingRulesTableAdapter();
            var dataTable = ta.GetDataByRuleProperty(property);
            var specificationsList = new List<SpecificationInfo<T>>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var processingRuleId = Int32.Parse(dataRow["ProcessingRuleId"].ToString());
                var operationName = dataRow["Operator"].ToString();
                var evalPropertyName = dataRow["EvalProperty"].ToString();
                var value = dataRow["Value"];
                var mainJoin = dataRow["MainJoin"].ToString();
                var mainGroup = int.Parse(dataRow["MainGroup"].ToString());

                var subJoin = dataRow["SubJoin"]?.ToString() ?? "";
                var subGroupValue = dataRow["SubGroup"]?.ToString() ?? "-1";
                var subGroup = int.Parse(string.IsNullOrEmpty(subGroupValue) ? "-1" : subGroupValue);

                var ruleValue = dataRow["RuleValue"].ToString();
                var defaultValue = dataRow["DefaultValue"].ToString();

                Operator operation;
                if (Enum.TryParse(operationName, true, out operation))
                {
                    var rule = new FakeRule(evalPropertyName, operation, value, processingRuleId);

                    var compiledRule = CompileRule<T>(rule);

                    var cplSpec = new FakeRule.ExpressionSpecification<T>(compiledRule);

                    var specificationInfo = new SpecificationInfo<T>();
                    specificationInfo.MainJoin = mainJoin;
                    specificationInfo.MainGroup = mainGroup;
                    specificationInfo.SubJoin = subJoin;
                    specificationInfo.SubGroup = subGroup;
                    specificationInfo.Specification = cplSpec;
                    specificationInfo.EvalProperty = evalPropertyName;
                    specificationInfo.RuleProperty = property;
                    specificationInfo.RuleValue = ruleValue;
                    specificationInfo.DefaultValue = defaultValue;
                    specificationInfo.ProcessingRuleId = processingRuleId;

                    specificationsList.Add(specificationInfo);
                }
            }


            return specificationsList;


            return specificationsList;
        }

        public Func<T, bool> CompileRule<T>(FakeRule rule)
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

        #region FakeRules

        //private SpecificationInfo HideAgentInfoOnLetter
        //{
        //    get
        //    {
        //        var processingRuleId = 1;
        //        var evalPropertyName = "HideAgentInfoOnLetter";

        //        Operator operation = Operator.Equal;

        //        var rule = new FakeRule(evalPropertyName, operation, "True", processingRuleId);
        //        var compiledRule = CompileRule<FakeAgentDisplayRule>(rule);

        //        var cplSpec = new FakeRule.ExpressionSpecification<FakeAgentDisplayRule>(compiledRule);

        //        //var specificationInfo = new HideAgentInfoOnLetter();

        //        //specificationInfo.Specification = cplSpec;

        //        return specificationInfo;
        //    }
        //}

        //private SpecificationInfo HideAgentInfoOnLetterForNJ
        //{
        //    get
        //    {
        //        var processingRuleId = 2;
        //        var evalPropertyName = "HideAgentInfoOnLetterForNJ";

        //        Operator operation = Operator.Equal;

        //        var rule = new FakeRule(evalPropertyName, operation, "True", processingRuleId);
        //        var compiledRule = CompileRule<FakeAgentDisplayRule>(rule);

        //        var cplSpec = new FakeRule.ExpressionSpecification<FakeAgentDisplayRule>(compiledRule);

        //        var specificationInfo = new HideAgentInfoOnLetterForNJ();

        //        specificationInfo.Specification = cplSpec;

        //        return specificationInfo;
        //    }
        //}

        #endregion FakeRules

    }
}
