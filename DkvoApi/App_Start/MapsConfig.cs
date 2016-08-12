using AutoMapper;
using BOL;
using DkvoApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DkvoApi
{
    public static class MapsConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonDto>());
        }

        public static T To<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static IEnumerable<T> To<T>(this IEnumerable<object> source)
        {
            return Mapper.Map<IEnumerable<T>>(source);
        }

    }
}