using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Extension
{
    public static class QueryExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> func)
            where T : class
        {
            if (condition)
            {
                query = query.Where(func);
            }

            return query;
        }
    }
}
