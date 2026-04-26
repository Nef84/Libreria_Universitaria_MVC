# Sistema de Inventario - Libreria Universitaria

Proyecto academico para Programacion 2, Unidad 3, desarrollado en **ASP.NET MVC (.NET Framework)** con **ADO.NET** y **SQL Server**.

## Que incluye

- Proyecto MVC clasico con `Controllers`, `Models` y `Views`
- Layout compartido con navegacion simple
- CRUD completo para `Categorias` y `Libros`
- Login basico con usuarios de prueba
- Validaciones con `DataAnnotations`
- Acceso a datos sencillo con `SqlConnection` y `SqlCommand`

## Como probarlo

1. Abre `BaseDatos.sql` en **SQL Server Management Studio**
2. Ejecuta el script completo con **F5**
3. Abre `Libreria_Universitaria.sln` en **Visual Studio**
4. Deja `LibreriaUniversitariaMVC` como proyecto de inicio
5. Revisa la cadena de conexion en `LibreriaUniversitariaMVC/Web.config`
6. Ejecuta con **F5**

## Usuarios de prueba

- `admin` / `1234`
- `jefe` / `1234`
- `agente` / `1234`

## Estructura principal

```text
Libreria_Universitaria/
├── LibreriaUniversitariaMVC/
│   ├── Controllers/
│   ├── Models/
│   ├── Data/
│   ├── Views/
│   └── Web.config
├── BaseDatos.sql
├── Libreria_Universitaria.sln
└── README.md
```

## Tecnologias

- Visual Studio 2022
- ASP.NET MVC 5
- Razor
- ADO.NET
- SQL Server / LocalDB
