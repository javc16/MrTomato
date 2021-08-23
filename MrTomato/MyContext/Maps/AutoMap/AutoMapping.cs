using AutoMapper;
using MrTomato.Models;
using MrTomato.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrTomato.MyContext.Maps.AutoMap
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO,Category>();

        }
    }
}