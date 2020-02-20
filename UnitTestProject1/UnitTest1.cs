//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Globalization;
//using System.IO;
//using System.Xml;
//using System.Linq;
//using System.Text.RegularExpressions;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ORTRulesEngine;
//using ORTRulesEngine.Entities;

//namespace UnitTestProject1
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void Unique_Rule_Test()
//        {
//            //IList<string> statesList = new List<string> { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
//            IList<string> statesList = new List<string> {"AL", "AK", "AZ", "AR"};
//            IList<string> underwriterList = new List<string> {"AGTIC", "ORNTIC"};
//            IList<string> letterTypeList = new List<string> {"ALTA8", "AL00"};
//            IList<string> transactionTypeList = new List<string> {"Blanket", "Cash", "Single"};

//            var iTestCounter = 0;
//            var testStart = DateTime.Now.Ticks;

//            foreach (string state in statesList)
//            {
//                foreach (var underwriter in underwriterList)
//                {
//                    foreach (var transactionType in transactionTypeList)
//                    {
//                        foreach (var letterType in letterTypeList)
//                        {
//                            iTestCounter++;
//                            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                                underwriter: underwriter, letterType: letterType);

//                            Assert.IsTrue(Get_Statisfying_Groups(cpl, "CPL_Letter_File_Name", "CPL"));
//                        }
//                    }
//                }
//            }

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);

//            Console.WriteLine("Executed " + iTestCounter + " CPL Tests in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Test_All_Oututs()
//        {

//            IList<string> statesList = new List<string>
//            {
//                "AL",
//                "AK",
//                "AZ",
//                "AR",
//                "CA",
//                "CO",
//                "CT",
//                "DE",
//                "FL",
//                "GA",
//                "HI",
//                "ID",
//                "IL",
//                "IN",
//                "IA",
//                "KS",
//                "KY",
//                "LA",
//                "ME",
//                "MD",
//                "MA",
//                "MI",
//                "MN",
//                "MS",
//                "MO",
//                "MT",
//                "NE",
//                "NV",
//                "NH",
//                "NJ",
//                "NM",
//                "NY",
//                "NC",
//                "ND",
//                "OH",
//                "OK",
//                "OR",
//                "PA",
//                "RI",
//                "SC",
//                "SD",
//                "TN",
//                "TX",
//                "UT",
//                "VT",
//                "VA",
//                "WA",
//                "WV",
//                "WI",
//                "WY"
//            };
//            //IList<string> statesList = new List<string> { "AL", "AK", "AZ", "AR" };
//            IList<string> underwriterList = new List<string> {"AGTIC", "ORNTIC"};
//            IList<string> letterTypeList = new List<string> {"ALTA8", "AL00"};
//            IList<string> transactionTypeList = new List<string> {"Blanket", "Cash", "Single"};

//            var iTestCounter = 0;
//            var testStart = DateTime.Now.Ticks;

//            IDictionary<CPLLetterBodyRule, RuleInformation> ruleInformationDictionary =
//                new Dictionary<CPLLetterBodyRule, RuleInformation>();

//            foreach (string state in statesList)
//            {
//                foreach (var underwriter in underwriterList)
//                {
//                    foreach (var transactionType in transactionTypeList)
//                    {
//                        foreach (var letterType in letterTypeList)
//                        {
//                            iTestCounter++;
//                            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                                underwriter: underwriter, letterType: letterType);

//                            Write_Results(cpl);
//                        }
//                    }
//                }
//            }

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/TimeSpan.TicksPerMillisecond);

//            Console.WriteLine("Executed " + iTestCounter + " CPL Tests in " + testTotal + " milli seconds.");
//        }




//        [TestMethod]
//        public void Specification_Pattern_ALTA8_B_2005_12()
//        {
//            var expectedResult = "ALTA8-B-2005-12";
//            //var state = "AK";
//            //var underwriter = "ORNTIC";
//            //var transactionType = "Blanket";
//            //var letterType = "ALTA8";

//            var cpl = new CPLAgentDisplayRule();

//            cpl.TransactionPropertyState = "AR";
//            cpl.LetterType = "AR01";

//            var testStart = DateTime.Now.Ticks;
//            var result = cpl.CPLAgentDisplay;
//            //Assert.AreEqual(expectedResult, cpl.CPLAgentDisplay);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_ALTA8_CASH_ORNTIC()
//        {
//            var expectedResult = "ALTA8-CASH-ORNTIC";
//            var state = "AK";
//            var underwriter = "ORNTIC";
//            var transactionType = "Cash";
//            var letterType = "ALTA8";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_ALTA8_S_2015_12()
//        {
//            var expectedResult = "ALTA8-S-2015-12";

//            var state = "AK";
//            var underwriter = "ORNTIC";
//            var transactionType = "Single";
//            var letterType = "ALTA8";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AL_00_AGT_C()
//        {
//            var expectedResult = "AL-00-AGT";

//            var state = "AL";
//            var underwriter = "AGTIC";
//            var transactionType = "Cash";
//            var letterType = "AL00";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AL_00_AGT_S()
//        {
//            var expectedResult = "AL-00-AGT";

//            var state = "AL";
//            var underwriter = "AGTIC";
//            var transactionType = "Single";
//            var letterType = "AL00";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AL_00_C()
//        {
//            var expectedResult = "AL-00";

//            var state = "AL";
//            var underwriter = "ORNTIC";
//            var transactionType = "Cash";
//            var letterType = "AL00";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AL_00_S()
//        {
//            var expectedResult = "AL-00";
//            var state = "AL";
//            var underwriter = "ORNTIC";
//            var transactionType = "Single";
//            var letterType = "AL00";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AR_01_AGT_C()
//        {
//            var expectedResult = "AR-01-AGT";
//            var state = "AR";
//            var underwriter = "AGTIC";
//            var transactionType = "Cash";
//            var letterType = "AR01";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AR_01_AGT_S()
//        {
//            var expectedResult = "AR-01-AGT";
//            var state = "AR";
//            var underwriter = "AGTIC";
//            var transactionType = "Single";
//            var letterType = "AR01";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AR_01_S()
//        {
//            var expectedResult = "AR-01-AGT";
//            var state = "AR";
//            var underwriter = "AGTIC";
//            var transactionType = "Single";
//            var letterType = "AR01";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_AR_01_C()
//        {
//            var expectedResult = "AR-01-AGT";
//            var state = "AR";
//            var underwriter = "AGTIC";
//            var transactionType = "Cash";
//            var letterType = "AR01";

//            var cpl = new CPLLetterBodyRule(state: state, transactionType: transactionType,
//                underwriter: underwriter, letterType: letterType);

//            var testStart = DateTime.Now.Ticks;
//            Assert.AreEqual(expectedResult, cpl.CPL_Letter_File_Name);
//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        private bool Get_Statisfying_Groups(CPLLetterBodyRule cpl, string property, string domain)
//        {
//            var target = new RuleEngine<CPLLetterBodyRule>();
//            var result = target.Get_Satisfying_Specfications(cpl, property, domain);
//            Console.WriteLine("---");
//            Console.WriteLine(string.Concat("Transaction: '", cpl.TransactionType, "'"));
//            Console.WriteLine(string.Concat("State: '", cpl.State, "'"));
//            Console.WriteLine(string.Concat("Underwriter: '", cpl.Underwriter, "'"));
//            Console.WriteLine(string.Concat("Letter Type '", cpl.LetterType, "'"));

//            Console.WriteLine(result.Count > 0
//                ? string.Concat("Satisfied by Rule Group: ", string.Join(";", result))
//                : "Satisfied by Rule Group: None");

//            Console.WriteLine("---");
//            Console.WriteLine();

//            return result.Count < 2;
//        }

//        private void Write_Results(CPLLetterBodyRule cpl)
//        {
//            // Find the matching cpl in the dictionary
//            Console.WriteLine("---");
//            Console.WriteLine("CPL Rule Results: ");
//            Console.WriteLine(string.Concat("Transaction: '", cpl.TransactionType, "'"));
//            Console.WriteLine(string.Concat("State: '", cpl.State, "'"));
//            Console.WriteLine(string.Concat("Underwriter: '", cpl.Underwriter, "'"));
//            Console.WriteLine(string.Concat("Letter Type '", cpl.LetterType, "'"));
//            Console.WriteLine(string.Concat("Results '", cpl.CPL_Letter_File_Name, "'"));
//            Console.WriteLine("---");
//            Console.WriteLine();
//        }

//        [TestMethod]
//        public void
//            Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_True_For_IsOrtis_And_IsParent_And_IsNational
//            ()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = true;
//            mergeData.Agent.IsORTRIS = true;
//            mergeData.Agent.isNational = true;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart)/10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }


//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_True_For_IsOrtis_And_IsParent_And_Not_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = true;
//            mergeData.Agent.IsORTRIS = true;
//            mergeData.Agent.isNational = false;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_True_For_Not_IsOrtis_And_IsParent_And_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = true;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = true;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_True_For_IsOrtis_And_Not_IsParent_And_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = true;
//            mergeData.Agent.isNational = true;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_True_For_Not_IsOrtis_And_Not_IsParent_And_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = true;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_False_For_Not_IsOrtis_And_Not_IsParent_And_Not_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsFalse(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_False_For_IsOrtis_And_Not_IsParent_And_Not_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = true;
//            mergeData.Agent.isNational = false;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsFalse(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Ortis_Parent_Or_National_Should_Be_False_For_Not_IsOrtis_And_IsParent_And_Not_IsNational()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = true;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsFalse(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_Is_Parent_Should_Be_True()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = true;
//            mergeData.Agent.IsORTRIS = true;
//            mergeData.Agent.isNational = true;
//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.IsOrtisParentOrNational;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtisParentOrNational_And_Blanket_Letter_Should_Be_False()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NNJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Blanket;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.HideAgentInfoForNJLetter;

//            Assert.IsFalse(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_No_Closing_Attorney_Should_Be_False()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NNJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.HideAgentInfoForNJLetter;

//            Assert.IsFalse(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Be_True()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            // Set LetterTransaction Type
//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            // Set the ClosingAttorney
//            mergeData.ClosingAttorney = new ClosingAttorneyInformation();
//            mergeData.ClosingAttorney.NameLine1 = "Test";

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.HideAgentInfoForNJLetter;

//            Assert.IsTrue(bool.Parse(result));

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Be_Empty()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            // Set LetterTransaction Type
//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            // Set the ClosingAttorney
//            mergeData.ClosingAttorney = new ClosingAttorneyInformation();
//            mergeData.ClosingAttorney.NameLine1 = "Test";

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.CPLAgentDisplay;

//            Assert.AreEqual(result, string.Empty);

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_No_Closing_Attorney_Should_Not_Be_Empty()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            // Set LetterTransaction Type
//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.CPLAgentDisplay;

//            Assert.AreNotEqual(result, string.Empty);

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_Not_NJ00_And_Not_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Not_Be_Empty()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is false
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = false;

//            // Make sure the lettertype is NJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.AL00;
//            mergeData.LetterType = letterType;

//            // Set LetterTransaction Type
//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            // Set the ClosingAttorney
//            mergeData.ClosingAttorney = new ClosingAttorneyInformation();
//            mergeData.ClosingAttorney.NameLine1 = "Test";

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.CPLAgentDisplay;

//            Assert.AreNotEqual(result, string.Empty);

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//        [TestMethod]
//        public void Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Is_IsOrtisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Not_Be_Empty()
//        {
//            //IsOrtisParentOrNational
//            var mergeData = new FakeMergeData();

//            // Make sure IsOrtrisParentOrNational is True
//            // (IsParent && IsORTRIS) || IsNational
//            mergeData.Agent = new Agent();
//            mergeData.Agent.IsParent = false;
//            mergeData.Agent.IsORTRIS = false;
//            mergeData.Agent.isNational = true;

//            // Make sure the lettertype is NJ00
//            var letterType = new LetterType();
//            letterType.Code = LetterTypeValue.NJ00;
//            mergeData.LetterType = letterType;

//            // Set LetterTransaction Type
//            mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

//            // Set the ClosingAttorney
//            mergeData.ClosingAttorney = new ClosingAttorneyInformation();
//            mergeData.ClosingAttorney.NameLine1 = "Test";

//            var agentRules = new FakeAgentDisplayRule(mergeData);

//            var testStart = DateTime.Now.Ticks;
//            var result = agentRules.CPLAgentDisplay;

//            Assert.AreNotEqual(result, string.Empty);

//            var testEnd = DateTime.Now.Ticks;
//            var testTotal = ((testEnd - testStart) / 10000);
//            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
//        }

//    }
//}


    

