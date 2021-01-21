using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Common
{
    public static class ExtensionMethod
    {

        public static IQueryable<TResult> Paging<TEntity, TResult>(this IQueryable<TResult> query, TEntity entity, ref Paging pg)
        {
            GetFilter(entity, ref pg);

            if (!string.IsNullOrEmpty(pg.filter))
                query = query.Where(pg.filter, pg.values.ToArray());

            if (!string.IsNullOrEmpty(pg.order))
                query = query.OrderBy(pg.order);

            pg.rowCount = query.Count();
            pg.pageNumber = pg.pageNumber ?? 1;
            pg.pageSize = pg.pageSize ?? pg.rowCount;

            return query.Skip<TResult>((pg.pageNumber.Value - 1) * pg.pageSize.Value).Take<TResult>(pg.pageSize.Value);
        }

        public static void GetFilter<T>(T entity, ref Paging pg)
        {
            string Expression = "{0}.Contains(@{1})";

            foreach (var item in entity.GetType().GetProperties())
            {
                object itemValue = item.GetValue(entity, null);

                if (itemValue != null && itemValue.ToString() != "" && !(item.Name == "Id" && Convert.ToInt64(itemValue) == 0))
                {
                    if (predefinedTypes.Any(i => i.Name == item.PropertyType.Name))
                    {
                        if (item.PropertyType.Name.ToUpper() != "STRING")
                            Expression = "{0} = @{1}";
                        else
                            Expression = "{0}.Contains(@{1})";

                        if (pg.filter == "")
                        {
                            pg.filter = string.Format(Expression, item.Name, pg.values.Count());
                        }
                        else
                        {
                            pg.filter += string.Format(" and " + Expression, item.Name, pg.values.Count());
                        }
                        pg.values.Add(itemValue);
                    }
                    else
                    {
                        foreach (PropertyInfo childItem in item.PropertyType.GetProperties())
                        {
                            object childItemValue = childItem.GetValue(item.GetValue(entity, null), null);

                            if (childItemValue != null && childItemValue.ToString() != "" && !(childItem.Name == "Id" && Convert.ToInt64(childItemValue) == 0))
                            {
                                if (childItem.PropertyType.Name.ToUpper() != "STRING")
                                    Expression = "{0} = @{1}";
                                else
                                    Expression = "{0}.Contains(@{1})";

                                if (pg.filter == "")
                                {
                                    pg.filter = string.Format(Expression, item.Name + "." + childItem.Name, pg.values.Count());
                                }
                                else
                                {
                                    pg.filter += string.Format(" and " + Expression, item.Name + "." + childItem.Name, pg.values.Count());
                                }

                                pg.values.Add(childItemValue);

                                pg.searchItems.Add(item.Name + "." + childItem.Name, childItemValue);
                            }
                        }
                    }
                }
            }
        }

        public static string GetSqlFilterDynamic<T>(T entity, string className)
        {
            string filter = " ";
            string and = "";

            foreach (var item in entity.GetType().GetProperties())
            {
                object itemValue = item.GetValue(entity, null);

                if (itemValue == null || item.Name == "Id")
                    continue;

                if (item.PropertyType == typeof(Nullable<DateTime>))
                    continue;

                if (itemValue != null && item.Name == "Id" && Convert.ToInt64(itemValue) == 0)
                    continue;

                if (item.PropertyType != typeof(string))
                {
                    filter += and;
                    filter += className + "." + item.Name + " = '" + itemValue + "'";
                    and = " AND ";
                    continue;
                }

                if (item.PropertyType == typeof(string))
                {
                    filter += and;
                    filter += className + "." + item.Name + " LIKE N'%" + itemValue + "%'";
                    and = " AND ";
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
                typeof(Guid),
                typeof(Math),
                typeof(Convert)
            };
    }
}
