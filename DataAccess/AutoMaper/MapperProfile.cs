using AutoMapper;
using BusinessObject;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            #region Category
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId.ToString()));
            #endregion
            #region Product
            #endregion
            #region User
            #endregion
        }
    }
}
