using SistemaRestauranteAPI.Dtos.Categorias;
using SistemaRestauranteAPI.Repository.IRepository;
using SistemaRestauranteAPI.Services.IServices;

namespace SistemaRestauranteAPI.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriaRepository _repository;
        public CategoriasService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public Task ActualizarCategoria(CategoriasDto categoria)
        {
            return _repository.ActualizarCategoria(categoria);
        }

        public Task BorrarCategoria(CategoriasDto categoria)
        {
            return _repository.BorrarCategoria(categoria);
        }

        public Task CrearCategoria(CategoriasDto categoria)
        {
            return _repository.CrearCategoria(categoria);
        }

        public bool ExisteCategoriaPorId(int id)
        {
            return _repository.ExisteCategoriaPorId(id);
        }

        public bool ExisteCategoriaPorNombre(string nombre)
        {
            return _repository.ExisteCategoriaPorNombre(nombre);
        }

        public Task<CategoriasDto> GetCategoriaId(int id)
        {
            return _repository.GetCategoriaId(id);
        }

        public Task<ICollection<CategoriasDto>> GetCategorias()
        {
            return _repository.GetCategorias();
        }
    }
}
