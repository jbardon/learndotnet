using System;
using System.Linq;
using System.Reflection;
using Autofac.Util;
using WebAPI.Utils;

namespace WebAPI
{
    public class MapsterConfig
    {
        public static void InitMappings()
        {
            // Manual way to register mappings
            //ProductMapping.RegisterMapping();
            
            var projectAssembly = Assembly.GetExecutingAssembly();
            
            var mappers = projectAssembly
                .GetLoadableTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(IMapper)))
                .ToList();

            foreach (var mapper in mappers)
            {
                var mapperInstance = (IMapper) Activator.CreateInstance(mapper);
                mapperInstance.RegisterMapping();
            }
        }
    }
}