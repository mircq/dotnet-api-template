﻿using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Utils;

public static class FilteringExtensions
{
    public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, List<ConditionEntity> filters)
    {
        if (filters == null || filters.Count == 0)
            return query;

        ParameterExpression param = Expression.Parameter(typeof(T), "x");
        Expression? predicate = null;

        foreach (ConditionEntity filter in filters)
        {
            string propertyName = filter.Key;
            object value = filter.Value;

            MemberExpression property = Expression.Property(expression: param, propertyName: propertyName);
            ConstantExpression constant = Expression.Constant(value: value);

            UnaryExpression converted = Expression.Convert(expression: constant, type: property.Type);

            BinaryExpression? comparison = null;

            switch (filter.Operator)
            {
                case var op when op == Operator.Equal:
                    comparison = Expression.Equal(left: property, right: converted);
                    break;
                // TODO
                //case var op when op == Operator.Contains:
                //    comparison = Expression
                case var op when op == Operator.GreaterOrEqual:
                    comparison = Expression.GreaterThanOrEqual(left: property, right: converted);
                    break;
                case var op when op == Operator.Greater:
                    comparison = Expression.GreaterThan(left: property, right: converted);
                    break;
                case var op when op == Operator.LowerOrEqual:
                    comparison = Expression.LessThanOrEqual(left: property, right: converted);
                    break;
                case var op when op == Operator.Lower:
                    comparison = Expression.LessThan(left: property, right: converted);
                    break;
            }

            if (comparison == null)
            {
                continue;
            }

            predicate = predicate == null ? comparison : Expression.AndAlso(left: predicate, right: comparison);
        }

        if (predicate == null)
            return query;

        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body: predicate, parameters: param);
        return query.Where(predicate: lambda);
    }

    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> source, string? sortField, string sortOrder)
    {
        if (string.IsNullOrWhiteSpace(value: sortField))
            return source; 

        ParameterExpression param = Expression.Parameter(type: typeof(T), name: "x");
        MemberExpression property = Expression.Property(expression: param, propertyName: sortField);
        LambdaExpression lambda = Expression.Lambda(body: property, parameters: param);

        string methodName = sortOrder == "desc" ? "OrderByDescending" : "OrderBy";

        var result = typeof(Queryable)
            .GetMethods()
            .First(method => method.Name == methodName && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), property.Type)
            .Invoke(null, new object[] { source, lambda });

        return (IQueryable<T>)result;
    }

    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, uint? pageSize, uint? pageNumber)
    {
        if (pageSize == null || pageNumber == null)
        {
            return source;
        }

        return source.Skip(count: (int)((pageNumber - 1) * pageSize)).Take(count: (int)pageSize);
    }
}
