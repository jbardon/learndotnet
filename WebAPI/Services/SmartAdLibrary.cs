using WebAPI.Models.Domain;

namespace WebAPI.Services
{
    public class SmartAdLibrary
    {
        public static Product Get()
        {
            return new Product()
            {
                UniqueId = 1,
                FullName = "Name",
                IsOld = true
            };
        }
    }
}