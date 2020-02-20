namespace ORTRulesEngine
{
    public class Rule
    {
        private int _processingRuleId;
        private bool propertySet = false;
        public string PropertyName { get; set; }
        public Operator Operator_ { get; set; }
        public object Value { get; set; }

        public Rule(Operator ruleOperator, object value,int processingRuleId)
        {
            _processingRuleId = processingRuleId;
            Operator_ = ruleOperator;
            Value = value;
        }

        public Rule(string propertyName, Operator ruleOperator, object value, int processingRuleId)
        {
            _processingRuleId = processingRuleId;
            Operator_ = ruleOperator;
            Value = value;
            PropertyName = propertyName;
            if (!string.IsNullOrEmpty(propertyName))
            {
                propertySet = true;
            }
        }
    }
}
