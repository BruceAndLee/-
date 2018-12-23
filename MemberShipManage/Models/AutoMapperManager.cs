using AutoMapper;
using MemberShipManage.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipManage.Models
{
    public class AutoMapperManager
    {
        public static void InitMapperCollection()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RechargeListRequest, RechargeListModel>();
            });
        }
    }
}