using MemberShipManage.Repository.ConsumeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.ConsumeService
{
    public class ConsumeRecordService: IConsumeRecordService
    {
        IConsumeRecordRepository consumeRecordRepository;
        public ConsumeRecordService(IConsumeRecordRepository consumeRecordRepository)
        {
            this.consumeRecordRepository = consumeRecordRepository;
        }
    }
}
