namespace RulesFakes
{
    public class SpecificationInfo<T>
    {
        public int MainGroup { get; set; }
        public string DefaultValue { get; set; }
        public string RuleValue { get; set; }
        public int SubGroup { get; set; }
        public string MainJoin { get; set; }
        public ISpecification<T> Specification { get; set; }
        public string SubJoin { get; set; }
        public string EvalProperty { get; set; }
        public string RuleProperty { get; set; }
        public int ProcessingRuleId { get; set; }
    }
}