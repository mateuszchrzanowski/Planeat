using AutoMapper;
using Planeat.Core.Domain;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<MealList, MealListDto>();
                cfg.CreateMap<Meal, MealDto>();
                cfg.CreateMap<Ingredient, IngredientDto>();
                cfg.CreateMap<IngredientDto, Ingredient>();
            }).CreateMapper();

            return config;
        }
    }
}
