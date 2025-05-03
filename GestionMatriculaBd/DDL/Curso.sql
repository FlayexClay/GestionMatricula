CREATE TABLE [dbo].[Curso]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,     -- Clave primaria
    [Nombre] NVARCHAR(100) NOT NULL,
    [Descripcion] NVARCHAR(255) NULL
);