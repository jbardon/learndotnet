namespace SmartAdLibrary.Models
{
    public class Product
    {
        public int UniqueId { get; set; }
        
        public string FullName { get; set; }
        
        public string Manufacturer { get; set; }
        
        public double Price { get; set; }
        
        public Quantity Quantity { get; set; }
    }
}