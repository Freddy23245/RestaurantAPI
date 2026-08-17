using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaRestauranteAPI.Dtos.Categorias;
using SistemaRestauranteAPI.Services.IServices;
using System.Reflection.Metadata.Ecma335;

namespace SistemaRestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _service;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriasService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetCategorias")]
        public async Task<IActionResult> GetCategorias()
        {
            var listaCategorias = await _service.GetCategorias();
            return Ok(listaCategorias);
        }

        [HttpGet("GetCategoriasId")]
        public async Task<IActionResult> GetCategoriasId(int id)
        {
            var listaCategorias = await _service.GetCategoriaId(id);
            return Ok(listaCategorias);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria (CategoriasDto categoria)
        {
            await _service.CrearCategoria(categoria);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria(CategoriasDto categoria)
        {
            await _service.ActualizarCategoria(categoria);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarCategoria(CategoriasDto categoria)
        {
            await _service.BorrarCategoria(categoria);
            return Ok();
        }

    }
}
