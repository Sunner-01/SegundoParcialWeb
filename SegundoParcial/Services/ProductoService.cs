using SegundoParcial.Data;
using SegundoParcial.Models;
using SegundoParcial.Models.DTOs;

namespace SegundoParcial.Services
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductoDto> ListarProductos()
        {
            return _context.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    DescripcionCorta = p.DescripcionCorta,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor
                }).ToList();
        }

        public Producto CrearProducto(ProductoDto productoDto)
        {
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                DescripcionCorta = productoDto.DescripcionCorta,
                Precio = productoDto.Precio,
                Stock = productoDto.Stock,
                IdCategoria = productoDto.IdCategoria,
                IdProveedor = productoDto.IdProveedor
            };
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return producto;
        }

        public Producto EditarProducto(int id, ProductoDto productoDto)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return null;

            producto.Nombre = productoDto.Nombre;
            producto.DescripcionCorta = productoDto.DescripcionCorta;
            producto.Precio = productoDto.Precio;
            producto.Stock = productoDto.Stock;
            producto.IdCategoria = productoDto.IdCategoria;
            producto.IdProveedor = productoDto.IdProveedor;

            _context.SaveChanges();
            return producto;
        }

        public bool EliminarProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return true;
        }

        public List<ProductoDto> ObtenerPorCategoria(int categoriaId)
        {
            return _context.Productos
                .Where(p => p.IdCategoria == categoriaId)
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    DescripcionCorta = p.DescripcionCorta,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor
                }).ToList();
        }

        public List<ProductoDto> BuscarPorNombre(string nombre)
        {
            return _context.Productos
                .Where(p => p.Nombre.Contains(nombre))
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    DescripcionCorta = p.DescripcionCorta,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor
                }).ToList();
        }

        public List<ProductoDto> ListarPorProveedor(int proveedorId)
        {
            return _context.Productos
                .Where(p => p.IdProveedor == proveedorId)
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    DescripcionCorta = p.DescripcionCorta,
                    Precio = p.Precio,
                    Stock = p.Stock,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor
                }).ToList();
        }
    }
}
