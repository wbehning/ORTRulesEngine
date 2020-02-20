namespace ORTRulesEngine
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            leftSpecification = left;
            rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            var isSatisfiedByLeft = leftSpecification.IsSatisfiedBy(o);

            var isSatisfiedByRight = false;

            if (!isSatisfiedByLeft)
            {
               isSatisfiedByRight = rightSpecification.IsSatisfiedBy(o);
            }

            return isSatisfiedByLeft || isSatisfiedByRight;
        }
    }
}
