# Sistema de Inventario – Librería Universitaria
Proyecto académico – Programación 2 – Grupo 4

## Requisitos
- Visual Studio 2022
- SQL Server o LocalDB
- .NET Framework 4.8

## Cómo ejecutar

### 1. Crear la base de datos
- Abre SQL Server Management Studio
- Ejecuta el archivo `ScriptsSQL/BaseDatos.sql`

### 2. Configurar conexión
Abre `Web.config` y ajusta según tu SQL Server:
- **LocalDB:** `Data Source=(localdb)\MSSQLLocalDB`
- **SQL Server Express:** `Data Source=.\SQLEXPRESS`

### 3. Abrir el proyecto
- Abre `Libreria_Universitaria.sln` en Visual Studio
- Presiona F5

## Páginas
- `Default.aspx` — Menú principal
- `Categorias.aspx` — CRUD de categorías
- `Libros.aspx` — CRUD de libros con búsqueda y filtro
- `Registro.aspx` — Formulario de registro
- `Home.aspx` — Listado de productos

## Repositorio
https://github.com/Nef84/Libreria_Universitaria