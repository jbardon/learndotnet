namespace WebAPI.Models.Domain
{
    public class Product
    {
        public int UniqueId { get; set; }
        
        public string FullName { get; set; }
        
        public bool IsOld { get; set; }
    }
}