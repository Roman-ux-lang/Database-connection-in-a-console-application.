01-cmd.ps1
dotnet new classlib -o .\p01e00\Domain
rm .\p01e00\Domain\Class1.cs
echo 'namespace Domain;' > .\p01e00\Domain\Empleado.cs

dotnet new classlib -o .\p01e00\Infrastructure
rm .\p01e00\Infrastructure\Class1.cs
echo 'namespace Infrastructure;' > .\p01e00\Infrastructure\EmpleadosDbContext.cs
dotnet add .\p01e00\Infrastructure reference .\p01e00\Domain
dotnet add .\p01e00\Infrastructure package Microsoft.Data.SqlClient

dotnet new console -o .\p01e00\ConsoleApp
dotnet add .\p01e00\ConsoleApp reference .\p01e00\Domain
dotnet add .\p01e00\ConsoleApp reference .\p01e00\Infrastructure

code .\p01e00\
