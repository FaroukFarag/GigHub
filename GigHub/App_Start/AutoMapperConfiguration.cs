using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.App_Start
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static void Initialize()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}