# 🏫 **Sistema de Gestión de Matrículas** 🎓

Este es un sistema para gestionar matrículas de alumnos en un colegio o universidad. Permite crear, actualizar, eliminar y consultar matrículas, además de manejar las relaciones entre alumnos y cursos.

---

## 📜 **Funcionalidades** 

### 1. **Matrícula de Alumnos** 📚
   - **Crear matrícula**: Asociar un alumno a un curso con estado "Activa".
   - **Modificar matrícula**: Cambiar el estado de una matrícula entre "Activa", "Cancelada" y "Finalizada".
   - **Eliminar matrícula**: Solo si está en estado "Cancelada".
   - **Consultar matrículas**: Por ID de matrícula, ID de estudiante, ID de curso y estado.

### 2. **Gestión de Alumnos** 👩‍🎓👨‍🎓
   - **Crear alumno**: Registrar nuevos alumnos en el sistema.
   - **Consultar alumnos**: Obtener todos los alumnos registrados.
   - **Eliminar alumno**: Borrar alumnos si no están asociados a ninguna matrícula activa.

### 3. **Gestión de Cursos** 📖
   - **Crear curso**: Registrar nuevos cursos en el sistema.
   - **Consultar cursos**: Obtener todos los cursos disponibles.


## 🔧 **Tecnologías Usadas**

- **.NET 9** 🖥️: Framework principal para la aplicación backend.
- **Entity Framework Core** 💾: ORM para la gestión de la base de datos SQL.
- **SQL Server** 🏢: Base de datos para almacenar los datos de alumnos, cursos y matrículas.
- **Blazor** 🔥: Framework de componentes para construir aplicaciones web interactivas.

---
## 🦖 **Autor: Alexander Palacios Quinteros**
