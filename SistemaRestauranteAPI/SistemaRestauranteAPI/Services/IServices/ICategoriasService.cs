using SistemaRestauranteAPI.Dtos.Categorias;

namespace SistemaRestauranteAPI.Services.IServices
{
    public interface ICategoriasService
    {
        Task<ICollection<CategoriasDto>> GetCategorias();
        Task<CategoriasDto> GetCategoriaId(int id);
        bool ExisteCategoriaPorId(int id);
        bool ExisteCategoriaPorNombre(string nombre);
        Task CrearCategoria(CategoriasDto categoria);
        Task ActualizarCategoria(CategoriasDto categoria);
        Task BorrarCategoria(CategoriasDto categoria);
    }
}
