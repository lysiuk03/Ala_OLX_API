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
        void Create(Announcement announcement);
        void Edit(Announcement announcement);
        void Delete(int id);
    }
}
