using ProductCatalog.Entities.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Entities.DTOs.Offer
{
    public class GetUserOfferDto
    {
        public int Id { get; set; }
        public GetProductUserDto Product { get; set; }
        public double OfferedPrice { get; set; }
        public bool IsApproved { get; set; }
    }
}
