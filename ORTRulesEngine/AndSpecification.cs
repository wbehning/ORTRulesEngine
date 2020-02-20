namespace ORTRulesEngine
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            leftSpecification = left;
            rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            var isSatisfiedByLeft = leftSpecification.IsSatisfiedBy(o); 
            var isSatisfiedByRight = rightSpecification.IsSatisfiedBy(o);
            return isSatisfiedByLeft && isSatisfiedByRight;
        }
    }
}
