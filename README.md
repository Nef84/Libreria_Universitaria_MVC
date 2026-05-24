# Sistema de Inventario - Libreria Universitaria

Proyecto academico de **Programacion 2** desarrollado en **ASP.NET MVC 5 (.NET Framework)** con **ADO.NET**, **Razor**, **SQL Server** y un modulo simple de reportes con **LINQ**.

## Descripcion general

El sistema fue preparado para la entrega final del curso y permite:

- iniciar sesion con usuarios de prueba
- administrar categorias
- administrar libros
- consultar reportes y listados finales
- mostrar seguridad minima, validaciones, CRUD y consultas LINQ

## Estructura del proyecto

```text
Libreria_Universitaria/
├── LibreriaUniversitariaMVC/
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   ├── Views/
│   ├── Content/
│   ├── Scripts/
│   └── Web.config
├── BaseDatos.sql
├── Libreria_Universitaria.sln
└── README.md
```

## Tecnologias usadas

- Visual Studio 2022
- ASP.NET MVC 5
- Razor
- ADO.NET
- LINQ
- SQL Server / LocalDB
- Bootstrap

## Pasos para implementarlo y ejecutarlo

1. Abrir `BaseDatos.sql` en **SQL Server Management Studio**.
2. Ejecutar el script completo con **F5** para crear la base `LibreriaUniversitaria`.
3. Abrir `Libreria_Universitaria.sln` en **Visual Studio 2022**.
4. Verificar que `LibreriaUniversitariaMVC` quede como proyecto de inicio.
5. Revisar la cadena de conexion en `LibreriaUniversitariaMVC/Web.config`.
6. Ejecutar el proyecto con **F5**.

## Cadena de conexion

El proyecto usa una conexion simple con LocalDB:

```xml
<add name="LibreriaDB"
     connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibreriaUniversitaria;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

Si tu base esta en otra instancia de SQL Server, solo cambia el `Data Source`.

## Usuarios de prueba

- `admin` / `1234`
- `jefe` / `1234`
- `agente` / `1234`

## Modulos del sistema

### 1. Inicio
Pantalla principal del sistema. Desde aqui se accede a los modulos de categorias, libros y reportes.

### 2. Categorias
CRUD completo para registrar, editar, consultar y eliminar categorias de libros.

### 3. Libros
CRUD completo para registrar, editar, consultar y eliminar libros del inventario.

### 4. Reportes
Pantalla final para mostrar consultas del inventario. Incluye:

- filtro por titulo o autor
- filtro por categoria
- listado filtrado
- libros con bajo stock
- resumen por categoria
- calculo de stock total y valor del inventario

## Evidencia de seguridad minima

El sistema cuenta con:

- login basico
- validacion de usuario contra la base de datos
- manejo de sesion
- restriccion de acceso a los modulos principales mientras no haya sesion iniciada

## Evidencia de LINQ

La evidencia de LINQ se muestra principalmente en:

- `LibreriaUniversitariaMVC/Controllers/ReportesController.cs`

En ese controlador se usan consultas como:

- `Where` para filtrar libros
- `OrderBy` y `ThenBy` para ordenar resultados
- `GroupBy` para resumir por categoria
- `Select` para proyectar datos del resumen
- `Sum` y `Count` para totales del inventario

## Validaciones

Se usan validaciones simples con `DataAnnotations` en los modelos:

- campos obligatorios
- limites de longitud
- validacion de rangos para precio y stock

## Flujo de uso

1. Ingresar con un usuario de prueba.
2. Entrar a `Categorias` y registrar o editar categorias.
3. Entrar a `Libros` y registrar o editar libros.
4. Ir a `Reportes` para aplicar filtros y mostrar listados finales.
5. Usar estas pantallas para capturas del PDF y defensa en video.

## Archivos clave para explicar en la defensa

- `BaseDatos.sql`
- `LibreriaUniversitariaMVC/Web.config`
- `LibreriaUniversitariaMVC/Controllers/AccesoController.cs`
- `LibreriaUniversitariaMVC/Controllers/CategoriasController.cs`
- `LibreriaUniversitariaMVC/Controllers/LibrosController.cs`
- `LibreriaUniversitariaMVC/Controllers/ReportesController.cs`
- `LibreriaUniversitariaMVC/Data/CategoriaDatos.cs`
- `LibreriaUniversitariaMVC/Data/LibroDatos.cs`
- `LibreriaUniversitariaMVC/Data/UsuarioDatos.cs`
- `LibreriaUniversitariaMVC/Views/Shared/_Layout.cshtml`

## Nota final

El proyecto fue mantenido con una estructura sencilla y coherente con lo visto en clase, evitando herramientas avanzadas para que sea facil de explicar, defender y ejecutar en el entorno del curso.
