using SmartAdLibrary.Model;

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
    
    /**
     * CREATE TABLE [dbo].[Product]
        (
            [id] INT NOT NULL PRIMARY KEY, 
            [name] NVARCHAR(50) NULL, 
            [manufacturer] NVARCHAR(MAX) NULL, 
            [price] DECIMAL NULL
        )
     */
}