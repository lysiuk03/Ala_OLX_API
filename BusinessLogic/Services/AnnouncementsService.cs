using AutoMapper;
using BusinessLogic.ApiModels.Announcements;
using BusinessLogic.Interfaces;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;

        public AnnouncementsService(AlaOlxDbContext ctx,IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public void Create(CreateAnnouncementModel announcement)
        {
            ctx.Announcements.Add(mapper.Map<Announcement>(announcement));
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
            ctx.Announcements.Update(mapper.Map<Announcement>(announcement));
            ctx.SaveChanges();
        }

        public List<Announcement> Get()
        {
            return ctx.Announcements
                     .Include(x => x.region)
                     .Include(x => x.category)
                     .ToList();
        }

        public Announcement? Get(int id)
        {
            var item = ctx.Announcements.Find(id);
            if (item == null) { return null; }
            return item;
        }
    }
}
