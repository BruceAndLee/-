using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using System.Linq;
using MemberShipManage.Infrastructure.Extension;

namespace MemberShipManage.Models
{
    public class AutoMapperManager
    {
        public static void InitMapperCollection()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RechargeListRequest, RechargeListModel>();
                cfg.CreateMap<ConsumeRecordListRequest, ConsumeRecordListModel>();
                cfg.CreateMap<Customer, CustomerEntity>().ForMember(c => c.Amount,
                    opt => opt.MapFrom(s => s.CustomerAmount.NotNullOrEmpty() ? s.CustomerAmount.First().Amount : 0));
                cfg.CreateMap<ConsumeRequest, ConsumeRecord>();
            });
        }
    }
}