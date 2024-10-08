﻿namespace Domain;

public class Empleado
{
    public Guid Id {get; set; }
    public string? Nombre {get; set; }
    public byte Edad {get; set; }
}

/*
CREATE TABLE [Empleados](
	[Id] [uniqueidentifier] PRIMARY KEY,
	[Nombre] [nvarchar](128) NOT NULL,
	[Edad] [tinyint] NOT NULL
)
*/
