using Microsoft.AspNetCore.Mvc;
using SegundoParcial.Models.DTOs;
using SegundoParcial.Services;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ProductoDto>> Get()
        {
            return Ok(_service.ListarProductos());
        }

        [HttpPost]
        public ActionResult<ProductoDto> Post([FromBody] ProductoDto productoDto)
        {
            var producto = _service.CrearProducto(productoDto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductoDto> Put(int id, [FromBody] ProductoDto productoDto)
        {
            var producto = _service.EditarProducto(id, productoDto);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eliminado = _service.EliminarProducto(id);
            if (!eliminado) return NotFound();
            return NoContent();
        }

        [HttpGet("categoria/{categoriaId}")]
        public ActionResult<List<ProductoDto>> GetPorCategoria(int categoriaId)
        {
            return Ok(_service.ObtenerPorCategoria(categoriaId));
        }

        [HttpGet("buscar")]
        public ActionResult<List<ProductoDto>> GetPorNombre([FromQuery] string nombre)
        {
            return Ok(_service.BuscarPorNombre(nombre));
        }

        [HttpGet("proveedor/{proveedorId}")]
        public ActionResult<List<ProductoDto>> GetPorProveedor(int proveedorId)
        {
            return Ok(_service.ListarPorProveedor(proveedorId));
        }
    }
}
