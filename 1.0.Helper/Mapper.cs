using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0._0.DataTransfer.DTO;
using _0._0.DataTransfer.Request.Student;
using AutoMapper;

namespace _1._0.Helper;

public static class MapperExtensions
{
    private static readonly IMapper Mapper;

    static MapperExtensions()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DtoStudent, InsertStudentRequest>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            cfg.CreateMap<InsertStudentRequest, DtoStudent>()
           .IgnoreAllPropertiesWithAnInaccessibleSetter()
           .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        });

        Mapper = configuration.CreateMapper();
    }

    public static TDestination Map<TDestination>(this object source)
    {
        return Mapper.Map<TDestination>(source);
    }
}