USE master;
GO
IF DB_ID(N'AcaBiblioteca') IS NULL CREATE DATABASE AcaBiblioteca;
GO
USE AcaBiblioteca;
GO

IF OBJECT_ID('dbo.Autores','U') IS NULL
CREATE TABLE dbo.Autores (IdAutor INT IDENTITY(1,1) CONSTRAINT PK_Autores PRIMARY KEY, Nombre VARCHAR(100) NOT NULL, Apellido VARCHAR(100) NOT NULL);
GO
IF OBJECT_ID('dbo.Editoriales','U') IS NULL
CREATE TABLE dbo.Editoriales (IdEditorial INT IDENTITY(1,1) CONSTRAINT PK_Editoriales PRIMARY KEY, Nombre VARCHAR(150) NOT NULL);
GO
IF OBJECT_ID('dbo.Libros','U') IS NULL
CREATE TABLE dbo.Libros (ISBN VARCHAR(20) NOT NULL CONSTRAINT PK_Libros PRIMARY KEY, Titulo VARCHAR(200) NOT NULL, IdAutor INT NOT NULL, IdEditorial INT NOT NULL, Categoria VARCHAR(100) NULL, Anio INT NULL, Existencias INT NOT NULL CONSTRAINT DF_Libros_Existencias DEFAULT 0, CONSTRAINT FK_Libros_Autores FOREIGN KEY(IdAutor) REFERENCES dbo.Autores(IdAutor), CONSTRAINT FK_Libros_Editoriales FOREIGN KEY(IdEditorial) REFERENCES dbo.Editoriales(IdEditorial), CONSTRAINT CK_Libros_Existencias CHECK(Existencias>=0), CONSTRAINT CK_Libros_Anio CHECK(Anio IS NULL OR Anio BETWEEN 0 AND 2100));
GO
IF OBJECT_ID('dbo.Usuarios','U') IS NULL
CREATE TABLE dbo.Usuarios (IdUsuario INT IDENTITY(1,1) CONSTRAINT PK_Usuarios PRIMARY KEY, Nombre VARCHAR(100) NOT NULL, Apellido VARCHAR(100) NOT NULL, Documento VARCHAR(30) NOT NULL, Telefono VARCHAR(30) NULL, Correo VARCHAR(150) NULL, CONSTRAINT UQ_Usuarios_Documento UNIQUE(Documento));
GO
IF OBJECT_ID('dbo.Prestamos','U') IS NULL
CREATE TABLE dbo.Prestamos (IdPrestamo INT IDENTITY(1,1) CONSTRAINT PK_Prestamos PRIMARY KEY, IdUsuario INT NOT NULL, ISBN VARCHAR(20) NOT NULL, FechaPrestamo DATE NOT NULL, FechaDevolucion DATE NULL, Estado VARCHAR(20) NOT NULL CONSTRAINT DF_Prestamos_Estado DEFAULT 'Prestado', CONSTRAINT FK_Prestamos_Usuarios FOREIGN KEY(IdUsuario) REFERENCES dbo.Usuarios(IdUsuario), CONSTRAINT FK_Prestamos_Libros FOREIGN KEY(ISBN) REFERENCES dbo.Libros(ISBN), CONSTRAINT CK_Prestamos_Estado CHECK(Estado IN ('Prestado','Devuelto')), CONSTRAINT CK_Prestamos_Fechas CHECK(FechaDevolucion IS NULL OR FechaDevolucion>=FechaPrestamo), CONSTRAINT CK_Prestamos_EstadoFecha CHECK((Estado='Prestado' AND FechaDevolucion IS NULL) OR (Estado='Devuelto' AND FechaDevolucion IS NOT NULL)));
GO

IF NOT EXISTS(SELECT 1 FROM dbo.Autores)
BEGIN
 INSERT dbo.Autores(Nombre,Apellido) VALUES ('Gabriel','García Márquez'),('Julio','Cortázar'),('Isabel','Allende'),('George','Orwell'),('Miguel','de Cervantes'),('Jane','Austen'),('Mario','Vargas Llosa'),('Jorge Luis','Borges'),('Antoine','de Saint-Exupéry'),('Ernest','Hemingway');
END;
IF NOT EXISTS(SELECT 1 FROM dbo.Editoriales)
BEGIN
 INSERT dbo.Editoriales(Nombre) VALUES ('Planeta'),('Alfaguara'),('Penguin Random House'),('Debolsillo'),('Anagrama'),('Seix Barral'),('Tusquets Editores');
END;
IF NOT EXISTS(SELECT 1 FROM dbo.Usuarios)
BEGIN
 INSERT dbo.Usuarios(Nombre,Apellido,Documento,Telefono,Correo) VALUES ('Ana','Pérez','1001001001','3001234567','ana@gmail.com'),('Carlos','Gómez','1001001002','3012345678','carlos@gmail.com'),('María','Rodríguez','1001001003','3023456789','maria@gmail.com'),('Laura','Martínez','1001001004','3034567890','laura.martinez@gmail.com'),('Andrés','López','1001001005','3045678901','andres.lopez@gmail.com'),('Sofía','Hernández','1001001006','3056789012','sofia.hernandez@gmail.com'),('Daniel','Torres','1001001007','3067890123','daniel.torres@gmail.com'),('Mariana','Ramírez','1001001008','3078901234','mariana.ramirez@gmail.com'),('Felipe','Castro','1001001009','3089012345','felipe.castro@gmail.com'),('Valentina','Morales','1001001010','3090123456','valentina.morales@gmail.com');
END;
IF NOT EXISTS(SELECT 1 FROM dbo.Libros)
BEGIN
 INSERT dbo.Libros(ISBN,Titulo,IdAutor,IdEditorial,Categoria,Anio,Existencias) VALUES ('9780307474728','Cien años de soledad',1,1,'Novela',1967,5),('9780451524935','1984',4,3,'Distopía',1949,4),('9780060934347','Don Quijote de la Mancha',5,1,'Novela',1605,3),('9780141439518','Orgullo y prejuicio',6,4,'Novela romántica',1813,5),('9788437604947','Rayuela',2,2,'Novela',1963,2),('9788401352836','La casa de los espíritus',3,1,'Realismo mágico',1982,4),('9788420471839','La ciudad y los perros',7,6,'Novela',1963,3),('9788420633114','Ficciones',8,7,'Cuentos',1944,2),('9780156012195','El principito',9,3,'Literatura infantil',1943,6),('9780684830490','El viejo y el mar',10,5,'Novela',1952,3),('9780307389732','El amor en los tiempos del cólera',1,1,'Novela',1985,4);
END;

IF NOT EXISTS(SELECT 1 FROM dbo.Prestamos)
BEGIN
 INSERT dbo.Prestamos(IdUsuario,ISBN,FechaPrestamo,FechaDevolucion,Estado) VALUES (1,'9780307474728',CONVERT(date,GETDATE()),NULL,'Prestado'),(2,'9780451524935','2026-08-05','2026-08-14','Devuelto'),(3,'9780060934347','2026-08-07',NULL,'Prestado'),(5,'9780307389732','2026-08-08','2026-08-16','Devuelto'),(6,'9780156012195','2026-08-09',NULL,'Prestado'),(7,'9780684830490','2026-08-10','2026-08-15','Devuelto'),(8,'9788420633114','2026-08-11',NULL,'Prestado'),(9,'9788401352836','2026-08-12','2026-08-17','Devuelto'),(10,'9788420471839','2026-08-13',NULL,'Prestado');

 UPDATE l SET Existencias = Existencias - x.Activos
 FROM dbo.Libros l INNER JOIN (SELECT ISBN, COUNT(*) AS Activos FROM dbo.Prestamos WHERE Estado='Prestado' GROUP BY ISBN) x ON x.ISBN=l.ISBN;
END;
GO
CREATE OR ALTER VIEW dbo.vw_HistorialPrestamos AS
SELECT p.IdPrestamo,p.FechaPrestamo,p.FechaDevolucion,p.Estado,u.IdUsuario,u.Documento,CONCAT(u.Nombre,' ',u.Apellido) AS Usuario,l.ISBN,l.Titulo AS Libro
FROM dbo.Prestamos p INNER JOIN dbo.Usuarios u ON u.IdUsuario=p.IdUsuario INNER JOIN dbo.Libros l ON l.ISBN=p.ISBN;
GO
PRINT 'Base de datos AcaBiblioteca verificada y lista.';
GO