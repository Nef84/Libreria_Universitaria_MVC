-- ============================================================
-- Script completo: Sistema de Inventario - Librería Universitaria
-- Instrucciones:
--   1. Abrir SQL Server Management Studio (SSMS)
--   2. Abrir este archivo o copiar y pegar el contenido
--   3. Ejecutar con F5
-- ============================================================

CREATE DATABASE LibreriaUniversitaria;
GO

USE LibreriaUniversitaria;
GO

-- ----------------------
-- Tabla: Categorias
-- ----------------------
CREATE TABLE Categorias (
    CategoriaID  INT IDENTITY(1,1) NOT NULL,
    Nombre       NVARCHAR(100)     NOT NULL,
    Descripcion  NVARCHAR(255)         NULL,
    CONSTRAINT PK_Categorias PRIMARY KEY (CategoriaID)
);
GO

-- ----------------------
-- Tabla: Libros
-- ----------------------
CREATE TABLE Libros (
    LibroID      INT IDENTITY(1,1)  NOT NULL,
    Titulo       NVARCHAR(200)      NOT NULL,
    Autor        NVARCHAR(150)      NOT NULL,
    Precio       DECIMAL(10,2)      NOT NULL,
    Stock        INT                NOT NULL DEFAULT 0,
    CategoriaID  INT                NOT NULL,
    CONSTRAINT PK_Libros          PRIMARY KEY (LibroID),
    CONSTRAINT FK_Libros_Categorias FOREIGN KEY (CategoriaID)
        REFERENCES Categorias(CategoriaID)
);
GO

-- ----------------------
-- Datos de ejemplo
-- ----------------------
INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Programación',  'Libros de desarrollo de software'),
('Matemáticas',   'Cálculo, álgebra y estadística'),
('Literatura',    'Novelas y cuentos universitarios');
GO

INSERT INTO Libros (Titulo, Autor, Precio, Stock, CategoriaID) VALUES
('Introducción a C#',       'Jon Skeet',         350.00, 15, 1),
('Algoritmos con Java',     'Robert Sedgewick',  420.00,  8, 1),
('Cálculo de una variable', 'James Stewart',     510.00, 12, 2),
('Álgebra Lineal',          'Gilbert Strang',    390.00,  5, 2),
('Cien años de soledad',    'Gabriel García M.', 180.00, 20, 3);
GO

------------------------------
-- Para crear usuarios y sus roles
------------------------------
CREATE TABLE Roles (
    RolID   INT IDENTITY(1,1) NOT NULL,
    Nombre  NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY (RolID)
);
GO

CREATE TABLE Usuarios (
    UsuarioID     INT IDENTITY(1,1) NOT NULL,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Contrasena    NVARCHAR(100) NOT NULL,
    Nombre        NVARCHAR(100) NOT NULL,
    RolID         INT NOT NULL,
    Activo        BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_Usuarios PRIMARY KEY (UsuarioID),
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolID)
        REFERENCES Roles(RolID)
);
GO

INSERT INTO Roles (Nombre) VALUES
('Administrador'),
('Jefe de Area'),
('Agente de Servicios');
GO

INSERT INTO Usuarios (NombreUsuario, Contrasena, Nombre, RolID, Activo) VALUES
('admin', '1234', 'Administrador General', 1, 1),
('jefe', '1234', 'Jefe de Area', 2, 1),
('agente', '1234', 'Agente de Servicios', 3, 1);
GO
