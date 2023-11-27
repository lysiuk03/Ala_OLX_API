﻿using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiModels.Announcements
{
    public class EditAnnouncementModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
        public int RegionId { get; set; }
        public int? Discount { get; set; }
        public string? Description { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}