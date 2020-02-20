using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORTRulesEngine.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class CplAgentTests
    {

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_True_For_IsOrtris_And_IsParent_And_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "True";
            cpl.IsOrtris = "True";
            cpl.IsNational = "True";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;
            
            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);
            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsTrue(bool.Parse(result));
        }


        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_True_For_IsOrtris_And_IsParent_And_Not_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "True";
            cpl.IsOrtris = "True";
            cpl.IsNational = "False";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsTrue(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_True_For_Not_IsOrtris_And_IsParent_And_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "True";
            cpl.IsOrtris = "False";
            cpl.IsNational = "True";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsTrue(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_True_For_IsOrtris_And_Not_IsParent_And_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsOrtris = "True";
            cpl.IsParent = "False";
            cpl.IsNational = "True";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsTrue(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_True_For_Not_IsOrtris_And_Not_IsParent_And_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsOrtris = "False";
            cpl.IsParent = "False";
            cpl.IsNational = "True";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsTrue(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_False_For_Not_IsOrtris_And_Not_IsParent_And_Not_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsOrtris = "False";
            cpl.IsParent = "False";
            cpl.IsNational = "False";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsFalse(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_False_For_IsOrtris_And_Not_IsParent_And_Not_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "False";
            cpl.IsOrtris = "True";
            cpl.IsNational = "False";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsFalse(bool.Parse(result));
        }

        [TestMethod]
        public void
            Test()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "False";
            cpl.IsOrtris = "True";
            cpl.IsNational = "False";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.CPLAgentDisplay;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

           // Assert.IsFalse(bool.Parse(result));
        }

        [TestMethod]
        public void
            Is_Ortris_Parent_Or_National_Should_Be_False_For_Not_IsOrtris_And_IsParent_And_Not_IsNational
            ()
        {
            var cpl = new CPLAgentDisplayRule();

            cpl.IsParent = "True";
            cpl.IsOrtris = "False";
            cpl.IsNational = "False";

            var testStart = DateTime.Now.Ticks;
            var result = cpl.IsOrtrisParentOrNational;

            var testEnd = DateTime.Now.Ticks;
            var testTotal = ((testEnd - testStart) / 10000);

            Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

            Assert.IsFalse(bool.Parse(result));
        }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtrisParentOrNational_And_Blanket_Letter_Should_Be_False
    //        ()
    //    {
    //        var cpl = new CPLAgentDisplayRule();

    //        cpl.LetterType = "NJOO";
    //        cpl.IsForBlanketLetter = "True";

    //        var testStart = DateTime.Now.Ticks;
    //        var result = cpl.IsOrtrisParentOrNational;

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart) / 10000);

    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");

    //        Assert.IsTrue(bool.Parse(result));

    //        // Make sure the lettertype is NNJ00
    //        mergeData.LetterType.Code = LetterTypeValue.NJ00;

    //        mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Blanket;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.HideAgentInfoForNJLetter;

    //        Assert.IsFalse(bool.Parse(result));

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtrisParentOrNational_And_Not_Blanket_Letter_And_No_Closing_Attorney_Should_Be_False
    //        ()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();

    //        mergeData.LetterType.Code = LetterTypeValue.NJ00;
    //        mergeData.ClosingAttorney = null;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.HideAgentInfoForNJLetter;

    //        Assert.IsFalse(bool.Parse(result));

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtrisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Be_True
    //        ()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();

    //        // Make sure the lettertype is NJ00
    //        mergeData.LetterType.Code = LetterTypeValue.NJ00;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.HideAgentInfoForNJLetter;

    //        Assert.IsTrue(bool.Parse(result));

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Not_IsOrtrisParentOrNational_And_Not_Blanket_Letter_And_No_Closing_Attorney_Should_Not_Be_Empty
    //        ()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();

    //        // Make sure the lettertype is NJ00
    //        mergeData.LetterType.Code = LetterTypeValue.NJ00;
    //        mergeData.ClosingAttorney = null;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.HideAgentInfoForNJLetter;

    //        Assert.AreNotEqual(result, string.Empty);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_Not_NJ00_And_Not_IsOrtrisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Not_Be_Empty
    //        ()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();

    //        mergeData.Agent.isNational = false;

    //        // Make sure the lettertype is not NJ00
    //        mergeData.LetterType.Code = LetterTypeValue.AL00;

    //        // Set LetterTransaction Type
    //        mergeData.ValidatedLetterRequest.LetterTransactionType = LetterTransactionType.Single;

    //        // Set the ClosingAttorney
    //        mergeData.ClosingAttorney.NameLine1 = "Test";

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreNotEqual(result, string.Empty);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void
    //        Specification_Pattern_Agent_Info_For_Letter_Type_Is_NJ00_And_Is_IsOrtrisParentOrNational_And_Not_Blanket_Letter_And_Has_Closing_Attorney_Should_Not_Be_False
    //        ()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();

    //        // Make sure IsOrtrisParentOrNational is True
    //        // (IsParent && IsORTRIS) || IsNational

    //        mergeData.Agent.isNational = true;

    //        // Make sure the lettertype is NJ00
    //        mergeData.LetterType.Code = LetterTypeValue.NJ00;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreNotEqual(result, string.Empty);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }


    //    [TestMethod]
    //    public void Specification_Pattern_Agent_Info_For_HideAgentInfoOnLetter_Should_Be_Empty()
    //    {
    //        var mergeData = GetMergeData();
    //        mergeData.ValidatedLetterRequest.HideAgentInfoOnLetter = true;
    //        var agentRules = new FakeAgentDisplayRule(mergeData);


    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreEqual(string.Empty, result);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void Specification_Pattern_Agent_Info_For_Not_HideAgentInfoOnLetter_Should_Be_DefaultAgentInfoDisplay()
    //    {
    //        //IsOrtrisParentOrNational
    //        var mergeData = GetMergeData();
    //        mergeData.ValidatedLetterRequest.HideAgentInfoOnLetter = false;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreEqual("DefaultAgentInfoDisplay", result);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart)/10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void Specification_Pattern_Agent_Info_For_Not_HideAgentInfoOnLetter_And_Transaction_State_Is_MO_Should_Be_MissouriAgentInfoDisplay()
    //    {
           
    //        var mergeData = GetMergeData();

    //        mergeData.ValidatedLetterRequest.HideAgentInfoOnLetter = false;
    //        mergeData.TransactionPropertyState = "MO";

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreEqual("MissouriAgentInfoDisplay", result);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart) / 10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }

    //    [TestMethod]
    //    public void Specification_Pattern_Agent_Info_For_Not_HideAgentInfoOnLetter_And_Letter_Type_Is_NC01_Should_Be_NCAgentInfoDisplay()
    //    {

    //        var mergeData = GetMergeData();

    //        mergeData.ValidatedLetterRequest.HideAgentInfoOnLetter = false;
    //        mergeData.LetterType.Code = LetterTypeValue.NC01;

    //        var agentRules = new FakeAgentDisplayRule(mergeData);

    //        var testStart = DateTime.Now.Ticks;
    //        var result = agentRules.CPLAgentDisplay;

    //        Assert.AreEqual("NorthCarolinaAgentInfoDisplay", result);

    //        var testEnd = DateTime.Now.Ticks;
    //        var testTotal = ((testEnd - testStart) / 10000);
    //        Console.WriteLine("Executed test in " + testTotal + " milli seconds.");
    //    }
    }
}