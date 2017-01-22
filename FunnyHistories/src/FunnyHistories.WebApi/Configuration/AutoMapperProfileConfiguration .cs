using AutoMapper;
using FunnyHistories.Core.Models.Histories;
using GoGiftApi.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FunnyHistories.WebApi.Configuration
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<History, HistoryDto>();
            //CreateMap<ApplicationViewModel, Application>();
        }

    }
}
