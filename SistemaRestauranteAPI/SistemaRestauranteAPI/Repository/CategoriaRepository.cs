using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaRestauranteAPI.Data;
using SistemaRestauranteAPI.Dtos.Categorias;
using SistemaRestauranteAPI.Models;
using SistemaRestauranteAPI.Repository.IRepository;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaRestauranteAPI.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SistemaRestauranteContext _context;
        private readonly IMapper _mapper;
        public CategoriaRepository(SistemaRestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task ActualizarCategoria(CategoriasDto categoria)
        {
            var CategoriaMod = await _context.Categoria.FindAsync(categoria.IdCategoria);
            if (CategoriaMod == null)
                throw new Exception("La categoría no existe.");

            //mapea los datos del dto y los agrega al modelo
             _mapper.Map(categoria, CategoriaMod);

            await _context.SaveChangesAsync();
        }

        public async Task BorrarCategoria(CategoriasDto categoria)
        {
            var categoriaDel = await _context.Categoria.FindAsync(categoria.IdCategoria);
            categoriaDel.Activa = false;
            if (categoriaDel == null)
                throw new Exception("La categoría no existe.");

            categoriaDel.Activa = false;

            await _context.SaveChangesAsync();
        }

        public async Task CrearCategoria(CategoriasDto categoria)
        {
            var categoriaNueva = _mapper.Map<Categorias>(categoria);
            await _context.Categoria.AddAsync(categoriaNueva);
            await _context.SaveChangesAsync();
        }

        public bool ExisteCategoriaPorId(int id)
        {
            var CategoriaPorId = _context.Categoria.Any(x => x.IdCategoria == id);
            return CategoriaPorId;
        }

        public  bool ExisteCategoriaPorNombre(string nombre)
        {
            var ExisteCategoriaPorNombre = _context.Categoria.Any(x => x.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return ExisteCategoriaPorNombre;
        }

        public async Task<CategoriasDto> GetCategoriaId(int id)
        {
            var categoriaPorId = await _context.Categoria.FindAsync(id);

            return _mapper.Map<CategoriasDto>(categoriaPorId);
        }

        public async Task<ICollection<CategoriasDto>> GetCategorias()
        {
            var listaCategorias = await _context.Categoria.OrderBy(a=>a.Nombre).ToListAsync();
            var listaRetornada = _mapper.Map<ICollection<CategoriasDto>>(listaCategorias);
            return listaRetornada;
        }

    }
}
