using AutoMapper;
using BusinessLogic.ApiModels.Announcements;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    public class MapperConfigs:Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateAnnouncementModel,Announcement>();
            CreateMap<EditAnnouncementModel, Announcement>();
        }

    }
}
