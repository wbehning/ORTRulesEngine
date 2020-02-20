namespace ORTRulesEngine
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !specification.IsSatisfiedBy(o);
        }
    }
}
