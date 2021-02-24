using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Common
{
    public static class ExtentionMethods
    {
        public static string ToTSQL<T>(this IQueryable<T> query) where T : class
        {
            var enumerator = query.Provider.Execute<IEnumerable<T>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator.Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);

            string sql = command.CommandText;
            return sql;
        }

        public static IQueryable<TResult> Paging<TEntity, TResult>(this IQueryable<TResult> query, TEntity entity, ref Paging pg)
        {
            entity.DynamicFiltering(ref pg);

            if (!string.IsNullOrEmpty(pg.filter))
                query = query.Where(pg.filter, pg.values.ToArray());

            if (!string.IsNullOrEmpty(pg.order))
                query = query.OrderBy(pg.order);

            pg.rowCount = query.Count();
            pg.pageNumber = pg.pageNumber ?? 1;
            pg.pageSize = pg.pageSize ?? pg.rowCount;

            return query.Skip<TResult>((pg.pageNumber.Value - 1) * pg.pageSize.Value).Take<TResult>(pg.pageSize.Value);
        }

        public static void DynamicFiltering<T>(this T entity, ref Paging pg)
        {
            string expression;

            foreach (var item in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object itemValue = item.GetValue(entity, null);

                if (itemValue != null && itemValue.ToString() != "")
                {
                    if (predefinedTypes.Any(i => i.Name == item.PropertyType.Name))
                    {
                        if (item.PropertyType.Name.ToUpper() == "STRING")
                            expression = "{0}.Contains(@{1})";
                        else
                            expression = "{0} = @{1}";

                        if (pg.filter != "")
                            pg.filter += " And ";

                        pg.filter += string.Format(expression, item.Name, pg.values.Count());
                        pg.values.Add(itemValue);

                        pg.searchItems.Add(item.Name, itemValue);
                    }
                    else
                    {
                        //item.DynamicFiltering(ref pg);

                        foreach (PropertyInfo childItem in item.PropertyType.GetProperties())
                        {
                            object childItemValue = childItem.GetValue(itemValue, null);

                            if (childItemValue != null && childItemValue.ToString() != "")
                            {
                                if (childItem.PropertyType.Name.ToUpper() == "STRING")
                                    expression = "{0}.Contains(@{1})";
                                else
                                    expression = "{0} = @{1}";

                                if (pg.filter != "")
                                    pg.filter += " And ";

                                pg.filter += string.Format(expression, item.Name + "." + childItem.Name, pg.values.Count());
                                pg.values.Add(childItemValue);

                                pg.searchItems.Add(item.Name + "." + childItem.Name, childItemValue);
                            }
                        }
                    }
                }
            }
        }

        public static string DynamicTSQLFiltering<T>(this T entity, string className)
        {
            string filter = " ";
            string and = "";

            foreach (var item in entity.GetType().GetProperties())
            {
                object itemValue = item.GetValue(entity, null);

                if (itemValue == null)
                    continue;

                if (item.PropertyType == typeof(Nullable<DateTime>))
                    continue;

                if (item.PropertyType == typeof(string))
                {
                    filter += and;
                    filter += className + "." + item.Name + " LIKE N'%" + itemValue + "%'";
                    and = " AND ";
                }
                else
                {
                    filter += and;
                    filter += className + "." + item.Name + " = '" + itemValue + "'";
                    and = " AND ";
                    continue;
                }

            }

            return filter;
        }

        public static List<Type> predefinedTypes = new List<Type>() {
                typeof(Object),
                typeof(object),
                typeof(Boolean),
                typeof(bool),
                typeof(bool?),
                typeof(Char),
                typeof(char),
                typeof(String),
                typeof(string),
                typeof(SByte),
                typeof(Byte),
                typeof(byte),
                typeof(byte?),
                typeof(Int16),
                typeof(UInt16),
                typeof(Int32),
                typeof(int?),
                typeof(UInt32),
                typeof(Int64),
                typeof(long),
                typeof(long?),
                typeof(UInt64),
                typeof(Single),
                typeof(Double),
                typeof(double),
                typeof(double?),
                typeof(Decimal),
                typeof(decimal),
                typeof(decimal?),
                typeof(DateTime),
                typeof(TimeSpan),
                typeof(Guid)
            };

        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
    }
}
