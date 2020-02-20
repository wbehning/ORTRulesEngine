namespace ORTRulesEngine
{
    public class MyClass<T1, T2>
    {
        public int GroupId { get; set; }
        public ISpecification<ISpecification<T2>> Specification { get; set; }
        public MyClass()
        {
        }
    }
}