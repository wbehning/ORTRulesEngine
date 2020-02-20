namespace RulesFakes
{
    public class Agent
    {
        public bool IsORTRIS;
        public bool isNational;
        public object Company { get; set; }
        public object IsParent { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public Address DisplayAddress { get; set; }
        public string GetDisplayDoingBusinessAsName()
        {
            return "";
        }

    }
}