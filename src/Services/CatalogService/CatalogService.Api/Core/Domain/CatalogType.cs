using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogService.Api.Core.Domain.Entities
{
    public class CatalogType
    {
        public int Id{ get; set; }
        
        public string Type { get; set; }
    }
}