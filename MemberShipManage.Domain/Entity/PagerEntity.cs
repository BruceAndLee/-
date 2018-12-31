using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class PagerEntity
    {
        private int pageIndex;
        public int PageIndex
        {
            get
            {
                return pageIndex == 0 ? pageIndex + 1 : pageIndex;
            }
            set
            {
                pageIndex = value;
            }
        }

        private int pageSize;
        public int PageSize
        {
            get
            {
                if (pageSize <= 0)
                {
                    return 10;
                }

                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }
    }
}
