﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    /*
     * Domain katmanı, projede hangi varlıkların olacağını tutan katmandır.
     */
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? Stock { get; set; }
        public string? CampaignInfo { get; set; }
        public string? ImageUrl { get; set; }


    }
}
