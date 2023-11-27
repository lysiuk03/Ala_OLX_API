using BusinessLogic.ApiModels.Announcements;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAnnouncementsServices
    {
        List<Announcement> Get();
        Announcement? Get(int id);
        void Create(CreateAnnouncementModel announcement);
        void Edit(EditAnnouncementModel announcement);
        void Delete(int id);
    }
}
