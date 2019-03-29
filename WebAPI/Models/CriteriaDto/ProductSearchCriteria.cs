using System.Collections.Generic;

namespace WebAPI.Models.CriteriaDto
{
    public class ProductSearchCriteria
    {
        public IList<int> Ids { get; set; }
        
        public IList<string> Name { get; set; }
    }
}