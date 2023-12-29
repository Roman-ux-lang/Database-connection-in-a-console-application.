using Domain;
using Infrastructure;

var _connectionString = "Data Source=**;Initial Catalog=***;User ID=***;Password=***;";
var _empleadosDbContext = new EmpleadosDbContext(_connectionString);

var empleado = new Empleado
{
    Id = Guid.NewGuid(),
    Nombre = "Prueba 999999",
    Edad = 99
};
_empleadosDbContext.Create(empleado);

var list = _empleadosDbContext.List();
foreach (var e in list)
{
    Console.Write($"\tId: {e.Id} \tNombre: {e.Nombre} \tEdad: {e.Edad}\n");
}