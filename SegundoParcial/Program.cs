using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;
using SegundoParcial.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SegundoParcialDb"));

builder.Services.AddScoped<ProductoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Categorias.AddRange(
        new Categoria { Id = 1, Nombre = "Computadoras", Descripcion = "Computadoras de sobremesa y portatiles" },
        new Categoria { Id = 2, Nombre = "Celulares", Descripcion = "Telefonos celulares de toda marca" }
    );

    context.Proveedores.AddRange(
        new Proveedor { Id = 1, RazonSocial = "IRIS Computer", Contacto = "67615846" },
        new Proveedor { Id = 2, RazonSocial = "MundoCel", Contacto = "71186598" }
    );

    context.Productos.AddRange(
        new Producto { Id = 1, Nombre = "Lenovo Legion 5Pro", DescripcionCorta = "Laptop bonita y potente", Precio = 12000.50f, Stock = 10, IdCategoria = 1, IdProveedor = 1 },
        new Producto { Id = 2, Nombre = "Redmi Note 14 Pro", DescripcionCorta = "512 GB alamcenamiento interno", Precio = 3800f, Stock = 25, IdCategoria = 2, IdProveedor = 2 }
    );

    context.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
