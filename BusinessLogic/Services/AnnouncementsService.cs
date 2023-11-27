using BusinessLogic.ApiModels.Announcements;
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
        public void Create(CreateAnnouncementModel announcement)
        {
            var entity = new Announcement()
            {
                Name = announcement.Name,
                Price = announcement.Price,
                InStock = announcement.InStock,
                ImageURL = announcement.ImageURL,
                CategoryId = announcement.CategoryId,
                RegionId = announcement.RegionId,
                Discount = announcement.Discount,
                Description = announcement.Description,
                ContactName = announcement.ContactName,
                Phone = announcement.Phone
            };
            ctx.Announcements.Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) { return; }
            ctx.Announcements.Remove(item);
            ctx.SaveChanges();
        }

        public void Edit(EditAnnouncementModel announcement)
        {
            var entity = new Announcement()
            {
                Id = announcement.Id,
                Name = announcement.Name,
                Price = announcement.Price,
                InStock = announcement.InStock,
                ImageURL = announcement.ImageURL,
                CategoryId = announcement.CategoryId,
                RegionId = announcement.RegionId,
                Discount = announcement.Discount,
                Description = announcement.Description,
                ContactName = announcement.ContactName,
                Phone = announcement.Phone
            };
            ctx.Announcements.Update(entity);
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
