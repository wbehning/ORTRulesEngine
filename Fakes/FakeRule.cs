using System;

namespace RulesFakes
{
    public class FakeRule
    {
        private int _processingRuleId;
        private bool propertySet = false;
        public string PropertyName { get; set; }
        public Operator Operator_ { get; set; }
        public object Value { get; set; }

        public FakeRule(Operator ruleOperator, object value, int processingRuleId)
        {
            _processingRuleId = processingRuleId;
            Operator_ = ruleOperator;
            Value = value;
        }

        public FakeRule(string propertyName, Operator ruleOperator, object value, int processingRuleId)
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

        public class ExpressionSpecification<T> : CompositeSpecification<T>
        {
            private Func<T, bool> expression;
            public ExpressionSpecification(Func<T, bool> expression)
            {
                if (expression == null)
                {
                    throw new ArgumentNullException();
                }

                this.expression = expression;
            }

            public override bool IsSatisfiedBy(T o)
            {
                return this.expression(o);
            }
        }

        public abstract class CompositeSpecification<T> : ISpecification<T>
        {
            public abstract bool IsSatisfiedBy(T o);

            public ISpecification<T> And(ISpecification<T> specification)
            {
                return new AndSpecification<T>(this, specification);
            }

            public ISpecification<T> Or(ISpecification<T> specification)
            {
                return new OrSpecification<T>(this, specification);
            }

            public ISpecification<T> Not(ISpecification<T> specification)
            {
                return new NotSpecification<T>(specification);
            }

        }

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
                var isLeft = leftSpecification.IsSatisfiedBy(o);
                var isRight = rightSpecification.IsSatisfiedBy(o);

                return isLeft && isRight;
            }
        }

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
                var isLeft = leftSpecification.IsSatisfiedBy(o);
                var isRight = rightSpecification.IsSatisfiedBy(o);

                return isLeft || isRight;
            }
        }

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
}