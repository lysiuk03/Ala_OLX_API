﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dtos
{
    public class AnnouncementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string? ImageURL { get; set; }
        public string CategoryName { get; set; }
        public string RegionName { get; set; }
        public int? Discount { get; set; }
        public string? Description { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}
