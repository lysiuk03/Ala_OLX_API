using AutoMapper;
using BusinessLogic.ApiModels.Announcements;
using BusinessLogic.Dtos;
using Core.Entities;

namespace BusinessLogic.Helpers
{
    public class MapperConfigs:Profile
    {
        public MapperConfigs()
        {
            CreateMap<CreateAnnouncementModel,Announcement>();
            CreateMap<EditAnnouncementModel, Announcement>();

            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
        }

    }
}
