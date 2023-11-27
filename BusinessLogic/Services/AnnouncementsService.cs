using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using OLX_Ala.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AnnouncementsService : IAnnouncementsServices
    {
        private readonly AlaOlxDbContext ctx;

        public AnnouncementsService(AlaOlxDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Announcement announcement)
        {
            ctx.Announcements.Add(announcement);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) { return; }
            ctx.Announcements.Remove(item);
            ctx.SaveChanges();
        }

        public void Edit(Announcement announcement)
        {
           
            ctx.Announcements.Update(announcement);
            ctx.SaveChanges();
        }

        public List<Announcement> Get()
        {
            return ctx.Announcements.ToList();
        }

        public Announcement? Get(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) { return null; }
            return item;
        }
    }
}
