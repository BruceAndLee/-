using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure.Extension
{
    public static class ObjectExtension
    {
        public static void SetObjectValue<T>(this T tEntity, string propertyName, object value)
            where T : class, new()
        {
            var property = tEntity.GetType().GetProperty(propertyName);
            if (property != null
                && property.CanWrite
                && property.GetValue(tEntity, null) == null)
            {
                property.SetValue(tEntity, value);
            }
        }
    }
}
