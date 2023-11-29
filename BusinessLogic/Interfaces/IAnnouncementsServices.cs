using BusinessLogic.ApiModels.Announcements;
using BusinessLogic.Dtos;

namespace BusinessLogic.Interfaces
{
    public interface IAnnouncementsServices
    {
        List<AnnouncementDto> Get();
        AnnouncementDto? Get(int id);
        void Create(CreateAnnouncementModel announcement);
        void Edit(EditAnnouncementModel announcement);
        void Delete(int id);
    }
}
