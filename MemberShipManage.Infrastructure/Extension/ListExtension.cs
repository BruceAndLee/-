using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Extension
{
    public static class ListExtension
    {
        public static bool NotNullOrEmpty<T>(this ICollection<T> sourceList)
        {
            return sourceList != null && sourceList.Count > 0;
        }
    }
}
