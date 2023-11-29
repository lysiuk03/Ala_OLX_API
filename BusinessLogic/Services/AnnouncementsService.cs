using AutoMapper;
using BusinessLogic.ApiModels.Announcements;
using BusinessLogic.Dtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Core.Entities;
using Core.Repositories;
using System.Net;

namespace BusinessLogic.Services
{
    public class AnnouncementsService : IAnnouncementsServices
    {
        //private readonly AlaOlxDbContext ctx;
        private readonly IRepository<Announcement> repository;
        private readonly IMapper mapper;

        public AnnouncementsService(IRepository<Announcement> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void Create(CreateAnnouncementModel announcement)
        {
           repository.Insert(mapper.Map<Announcement>(announcement));
           repository.Save();
        }

        public void Delete(int id)
        {
            var item = repository.GetByID(id);
            if (item == null) throw new HttpException("Announcement not found by Id!", HttpStatusCode.NotFound);

           repository.Delete(item);
            repository.Save();
        }

        public void Edit(EditAnnouncementModel announcement)
        {
            repository.Update(mapper.Map<Announcement>(announcement));
            repository.Save();
        }

        public List<AnnouncementDto> Get()
        {
            var items = repository.Get(includeProperties: "category,region");
            return mapper.Map<List<AnnouncementDto>>(items);
        }

        public AnnouncementDto? Get(int id)
        {
            var item = repository.GetByID(id);
            if (item == null) throw new HttpException("Announcement not found by Id!", HttpStatusCode.NotFound);
            return mapper.Map<AnnouncementDto>(item);
        }
    }
}
