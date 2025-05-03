CREATE TABLE [dbo].[Matricula]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY,      -- Clave primaria
    [AlumnoId] INT NOT NULL,                  -- Clave foránea con Alumno
    [CursoId] INT NOT NULL,                   -- Clave foránea con Curso
    [Estado] NVARCHAR(50) NOT NULL,           -- Estado de la matrícula (ej: "Activa", "Cancelada", "Finalizada")
    [FechaMatricula] DATETIME NOT NULL,       -- Fecha de la matrícula
    
    CONSTRAINT FK_Matricula_Alumno FOREIGN KEY ([AlumnoId]) 
        REFERENCES [dbo].[Alumno]([Id]) 
        ON DELETE NO ACTION,                   -- Comportamiento en caso de eliminación (equivalente a RESTRICT)
    
    CONSTRAINT FK_Matricula_Curso FOREIGN KEY ([CursoId]) 
        REFERENCES [dbo].[Curso]([Id]) 
        ON DELETE NO ACTION                    -- Comportamiento en caso de eliminación (equivalente a RESTRICT)
);