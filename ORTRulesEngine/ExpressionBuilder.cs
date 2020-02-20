using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ORTRulesEngine
{
    public class ExpressionBuilder
    {
        public Expression BuildExpression<T>(
            Operator ruleOperator, object value, ParameterExpression parameterExpression)
        {
            ExpressionType expressionType = new ExpressionType();
            var leftOperand = parameterExpression;
            var rightOperand = Expression.Constant(Convert.ChangeType(value, typeof(T)));
            var expressionTypeValue = (ExpressionType)expressionType.GetType().GetField(Enum.GetName(typeof(Operator), ruleOperator)).GetValue(ruleOperator);
            var binaryExpression = Expression.MakeBinary(expressionTypeValue, leftOperand, rightOperand);
            return binaryExpression;
        }

        public Expression BuildExpression<T>(
            string propertyName, Operator ruleOperator, object value,ParameterExpression parameterExpression)
        {
            ExpressionType expressionType = new ExpressionType();
            var leftOperand = MemberExpression.Property(parameterExpression, propertyName);
            var rightOperand = Expression.Constant(Convert.ChangeType(value, value.GetType()));
            FieldInfo fieldInfo = expressionType.GetType().GetField(Enum.GetName(typeof(Operator), ruleOperator));
            var expressionTypeValue = (ExpressionType)fieldInfo.GetValue(ruleOperator);
            var binaryExpression = Expression.MakeBinary(expressionTypeValue, leftOperand, rightOperand);
            return binaryExpression;
        }
    }
}
