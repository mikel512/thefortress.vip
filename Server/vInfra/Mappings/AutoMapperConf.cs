using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vApplication.Mappings;

namespace vInfra.Mappings;

public class AutoMapperConf
{
    public static MapperConfiguration GetConfiguration() =>
        new MapperConfiguration(map =>
        {
            map.AddProfile<AutoMapperProfile>();
        });
}