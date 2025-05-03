CREATE TABLE [dbo].[Alumno]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,     -- Clave primaria
    [Nombre] NVARCHAR(100) NOT NULL,
    [Apellido] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE
);