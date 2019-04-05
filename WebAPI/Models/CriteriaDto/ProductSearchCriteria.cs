using System;
using System.Collections.Generic;

namespace WebAPI.Models.CriteriaDto
{
    public class ProductSearchCriteria
    {
        public IList<string> Make { get; set; }
        
        public IList<string> Name { get; set; }
        
        public double? MinPrice { get; set; }
        
        public double? MaxPrice { get; set; }
    }
}