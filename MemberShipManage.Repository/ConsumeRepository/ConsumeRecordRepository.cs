using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.ConsumeRepository
{
    public class ConsumeRecordRepository : BaseRepository<ConsumeRecord>, IConsumeRecordRepository
    {
        public ConsumeRecordRepository(IUnitOfWork dbcontext)
              : base(dbcontext)
        {

        }
    }
}
