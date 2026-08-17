using SistemaRestauranteAPI.Dtos.Categorias;

namespace SistemaRestauranteAPI.Repository.IRepository
{
    public interface ICategoriaRepository
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
