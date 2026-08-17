using AutoMapper;
using SistemaRestauranteAPI.Dtos.Categorias;
using SistemaRestauranteAPI.Models;

namespace SistemaRestauranteAPI.RestaurantMappers
{
    public class RestaurantMappers:Profile
    {
        public RestaurantMappers()
        {
            CreateMap<Categorias, CategoriasDto>().ReverseMap();
        }

    }
}
