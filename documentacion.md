# ACA -- Programación Avanzada

# Sistema de Gestión de Biblioteca

------------------------------------------------------------------------

## PORTADA

**[CUN: Corporación Unificada Nacional de Educación Superior]**

**[INGENIERIA DE SISTEMAS / PROGRAMACION AVANZADA]**

### ACA -- Programación Avanzada

### Sistema de Gestión de Biblioteca

**Presentado por:**  
[BRYAM ERICK FORERO OSORIO]

**Docente:**  
[VERONICA CASTRO]

**Fecha:**  
[Bogotá, 10, 11 y 2026]

------------------------------------------------------------------------

# CONTRAPORTADA

**Sistema de Gestión de Biblioteca**

Proyecto desarrollado como evidencia del curso de **Programación Avanzada**, aplicando Programación Orientada a Objetos, base de datos relacional, arquitectura por capas, operaciones CRUD, validaciones, manejo de excepciones y conexión con SQL Server.

**Estudiante:** [BRYAM ERICK FORERO OSORIO]  
**Programa:** [PROGRACION AVANZADA]  
**Grupo:** [54469]  
**Docente:** [VERONICA CASTRO]  
**Institución:** [CUN: Corporación Unificada Nacional de Educación Superior]  
**Año:** 2026

------------------------------------------------------------------------

# TABLA DE CONTENIDO

1. Introducción
2. Objetivos  
   - 2.1 Objetivo general  
   - 2.2 Objetivos específicos
3. Planteamiento del problema
4. Análisis de requerimientos
5. Casos de uso
6. Diagrama de clases
7. Modelo entidad-relación
8. Diccionario de datos
9. Arquitectura del sistema
10. Explicación de los módulos desarrollados
11. Capturas de pantalla del sistema
12. Pruebas de funcionamiento
13. Conclusiones
14. Recomendaciones
15. Referencias bibliográficas

------------------------------------------------------------------------

# 1. INTRODUCCIÓN

El presente documento describe el desarrollo del **Sistema de Gestión de Biblioteca**, una aplicación de escritorio cuyo propósito es facilitar la administración de los procesos de una biblioteca institucional: gestión de libros, autores, editoriales, usuarios, préstamos, devoluciones y generación de reportes.

El sistema fue desarrollado utilizando **C#**, **Windows Forms** y **SQL Server**, aplicando los principios de la Programación Orientada a Objetos y una arquitectura lógica por capas (Presentación, Lógica de negocio / Entidades y Acceso a datos).

La aplicación permite centralizar la información bibliográfica, administrar los usuarios de la biblioteca, controlar el ciclo de préstamos y devoluciones, mantener la integridad de los datos mediante claves foráneas y transacciones, y consultar información consolidada a través de un módulo de reportes.

------------------------------------------------------------------------

# 2. OBJETIVOS

## 2.1 Objetivo general

Desarrollar una aplicación de escritorio para la gestión integral de una biblioteca utilizando C#, Windows Forms y SQL Server, que permita administrar libros, autores, editoriales y usuarios, gestionar préstamos y devoluciones, y generar reportes mediante operaciones conectadas a una base de datos relacional, aplicando los principios de la Programación Orientada a Objetos.

## 2.2 Objetivos específicos

Al finalizar el proyecto el estudiante deberá ser capaz de:

- Aplicar los principios de Programación Orientada a Objetos.
- Diseñar una base de datos relacional.
- Implementar operaciones CRUD.
- Utilizar SQL Server como gestor de base de datos.
- Implementar arquitectura por capas.
- Validar información ingresada por el usuario (manejar excepciones).
- Utilizar Git y GitHub como sistema de control de versiones.
- Documentar técnicamente el proyecto.
- Implementar formularios que permitan administrar la información de libros, autores, editoriales y usuarios, facilitando las operaciones de registro, consulta, actualización y eliminación de datos.

------------------------------------------------------------------------

# 3. PLANTEAMIENTO DEL PROBLEMA

Una institución educativa requiere una aplicación de escritorio que facilite la administración de los procesos de su biblioteca.

La gestión de libros, autores, editoriales y usuarios, así como el control de préstamos y devoluciones, requiere un sistema organizado que permita registrar, consultar, actualizar y eliminar información, además de realizar el seguimiento del estado de los préstamos y generar reportes.

Para atender esta necesidad, se propone desarrollar un Sistema de Gestión de Biblioteca utilizando C#, Windows Forms y SQL Server. La aplicación permitirá centralizar la información bibliográfica, administrar los usuarios, gestionar los préstamos y devoluciones, y consultar información mediante reportes, garantizando la integridad y consistencia de los datos almacenados.

------------------------------------------------------------------------

# 4. ANÁLISIS DE REQUERIMIENTOS

## 4.1 Requerimientos funcionales

| Código | Descripción |
|--------|-------------|
| **RF01** | Gestión de Libros: registrar, consultar, editar, eliminar, buscar por ISBN/título/autor y relacionar con autores y editoriales. Control de existencias. |
| **RF02** | Gestión de Autores: registrar, consultar, editar y eliminar autores (respetando integridad referencial). |
| **RF03** | Gestión de Editoriales: registrar, consultar, editar y eliminar editoriales. |
| **RF04** | Gestión de Usuarios: registrar, consultar, editar y eliminar usuarios. Campos: nombre, apellido, documento (único), teléfono y correo. |
| **RF05** | Gestión de Préstamos: asociar usuario y libro, registrar fecha de préstamo, controlar existencias y estado. |
| **RF06** | Gestión de Devoluciones: actualizar fecha de devolución, cambiar estado a «Devuelto» y restaurar existencias. |
| **RF07** | Consultas y Reportes: préstamos activos, préstamos devueltos, historial, inventario de libros y listado de usuarios. |
| **RF08** | Navegación del Sistema: formulario principal con acceso a Inicio, Libros, Usuarios, Autores, Editoriales, Préstamos y Reportes. |

## 4.2 Requerimientos no funcionales

- Interfaz gráfica clara, organizada y fácil de utilizar.
- Validación de campos obligatorios.
- Prevención de registros duplicados (documento de usuario, ISBN).
- Mensajes claros de éxito y error.
- Manejo adecuado de excepciones.
- Código fuente organizado y legible.
- Uso de nombres descriptivos.
- Mantenimiento de la integridad de los datos.
- Conexión adecuada con SQL Server.
- Uso de consultas parametrizadas.
- Separación de responsabilidades (arquitectura por capas).

------------------------------------------------------------------------

# 5. CASOS DE USO

**Actores principales:** Bibliotecario / Administrador del sistema.

**Casos de uso principales:**

1. Gestionar Libros (CRUD + búsqueda)
2. Gestionar Autores (CRUD)
3. Gestionar Editoriales (CRUD)
4. Gestionar Usuarios (CRUD)
5. Registrar Préstamo
6. Registrar Devolución
7. Consultar Reportes
8. Navegar entre módulos

*(Insertar aquí el Diagrama de Casos de Uso disponible en la carpeta Diagramas del repositorio).*

------------------------------------------------------------------------

# 6. DIAGRAMA DE CLASES

El sistema utiliza las siguientes clases principales:

**Capa de Entidades:**
- `Autor` (IdAutor, Nombre, Apellido, NombreCompleto)
- `Editorial` (IdEditorial, Nombre)
- `Libro` (ISBN, Titulo, IdAutor, IdEditorial, Categoria, Anio, Existencias)
- `Usuario` (IdUsuario, Nombre, Apellido, Documento, Telefono, Correo, NombreCompleto)
- `Prestamo` (IdPrestamo, IdUsuario, ISBN, FechaPrestamo, FechaDevolucion, Estado)

**Capa de Acceso a Datos:**
- `Conexion` (cadena de conexión y método ObtenerConexion)
- `PrestamoDAO` (ListarTodos, Insertar, RegistrarDevolucion, Eliminar, ObtenerExistencias)
- `ReporteDAO` (PrestamosActivos, PrestamosDevueltos, InventarioLibros, HistorialPrestamos, UsuariosRegistrados)

**Capa de Presentación:**
- `FrmPrincipal`, `FrmInicio`, `FrmLibros`, `FrmAutores`, `FrmEditoriales`, `FrmUsuarios`, `FrmPrestamos`, `FrmReportes`

*(Insertar el Diagrama de Clases del repositorio).*

------------------------------------------------------------------------

# 7. MODELO ENTIDAD-RELACIÓN

**Entidades y relaciones:**

- **Autores** 1 ── * **Libros** (un autor tiene muchos libros)
- **Editoriales** 1 ── * **Libros** (una editorial publica muchos libros)
- **Usuarios** 1 ── * **Prestamos** (un usuario puede tener muchos préstamos)
- **Libros** 1 ── * **Prestamos** (un libro puede prestarse muchas veces)

**Cardinalidades principales:**
- Libro → Autor: N:1
- Libro → Editorial: N:1
- Prestamo → Usuario: N:1
- Prestamo → Libro: N:1

*(Insertar el Modelo Entidad-Relación / Análisis BD disponible en el repositorio).*

------------------------------------------------------------------------

# 8. DICCIONARIO DE DATOS

### Tabla: Autores
| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| IdAutor | INT IDENTITY | No | Clave primaria |
| Nombre | VARCHAR(100) | No | Nombre del autor |
| Apellido | VARCHAR(100) | No | Apellido del autor |

### Tabla: Editoriales
| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| IdEditorial | INT IDENTITY | No | Clave primaria |
| Nombre | VARCHAR(150) | No | Nombre de la editorial |

### Tabla: Libros
| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| ISBN | VARCHAR(20) | No | Clave primaria |
| Titulo | VARCHAR(200) | No | Título del libro |
| IdAutor | INT | No | FK → Autores |
| IdEditorial | INT | No | FK → Editoriales |
| Categoria | VARCHAR(100) | Sí | Categoría / género |
| Anio | INT | Sí | Año de publicación |
| Existencias | INT | No | Cantidad disponible (≥ 0) |

### Tabla: Usuarios
| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| IdUsuario | INT IDENTITY | No | Clave primaria |
| Nombre | VARCHAR(100) | No | Nombre |
| Apellido | VARCHAR(100) | No | Apellido |
| Documento | VARCHAR(30) | No | Documento único |
| Telefono | VARCHAR(30) | Sí | Teléfono |
| Correo | VARCHAR(150) | Sí | Correo electrónico |

### Tabla: Prestamos
| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| IdPrestamo | INT IDENTITY | No | Clave primaria |
| IdUsuario | INT | No | FK → Usuarios |
| ISBN | VARCHAR(20) | No | FK → Libros |
| FechaPrestamo | DATE | No | Fecha del préstamo |
| FechaDevolucion | DATE | Sí | Fecha de devolución |
| Estado | VARCHAR(20) | No | 'Prestado' o 'Devuelto' |

------------------------------------------------------------------------

# 9. ARQUITECTURA DEL SISTEMA

Se implementó una **arquitectura lógica por capas**:

```
┌─────────────────────────────────────────────┐
│           PRESENTACIÓN (Windows Forms)      │
│  FrmPrincipal, FrmLibros, FrmPrestamos,     │
│  FrmReportes, FrmUsuarios, etc.             │
└────────────────────┬────────────────────────┘
                     │
┌────────────────────▼────────────────────────┐
│     LÓGICA / ENTIDADES (POO)                │
│  Autor, Editorial, Libro, Usuario, Prestamo │
└────────────────────┬────────────────────────┘
                     │
┌────────────────────▼────────────────────────┐
│         ACCESO A DATOS (DAO)                │
│  Conexion, PrestamoDAO, ReporteDAO          │
│  Consultas parametrizadas + transacciones   │
└────────────────────┬────────────────────────┘
                     │
┌────────────────────▼────────────────────────┐
│         BASE DE DATOS (SQL Server)          │
│              AcaBiblioteca                  │
└─────────────────────────────────────────────┘
```

**Beneficios:**
- Separación de responsabilidades.
- Código más mantenible y escalable.
- Facilita pruebas y reutilización.
- Cumple con el requerimiento de arquitectura por capas del ACA.

------------------------------------------------------------------------

# 10. EXPLICACIÓN DE LOS MÓDULOS DESARROLLADOS

## 10.1 Módulo Inicio
Formulario de bienvenida que se muestra al iniciar la aplicación. Facilita la navegación desde el menú principal.

## 10.2 Módulo Libros
Permite registrar, consultar, editar y eliminar libros. Incluye relación con autores y editoriales mediante ComboBox, control de existencias y búsqueda por ISBN.

## 10.3 Módulo Autores
CRUD completo de autores. Impide la eliminación cuando existen libros relacionados (integridad referencial).

## 10.4 Módulo Editoriales
CRUD completo de editoriales. Respeta las relaciones con la tabla Libros.

## 10.5 Módulo Usuarios
Registro de usuarios de la biblioteca con validación de documento único. Campos: nombre, apellido, documento, teléfono y correo.

## 10.6 Módulo Préstamos y Devoluciones
- Registro de préstamo asociando usuario + libro.
- Validación de existencias antes de prestar.
- Disminución automática de existencias.
- Registro de devolución (actualiza fecha, estado y restaura existencias).
- Uso de transacciones para garantizar consistencia.
- Solo se pueden eliminar préstamos en estado «Devuelto».

## 10.7 Módulo Reportes
Genera los siguientes reportes:
- Préstamos activos
- Préstamos devueltos
- Historial completo de préstamos
- Inventario de libros (con autor y editorial)
- Listado de usuarios registrados

------------------------------------------------------------------------

# 11. CAPTURAS DE PANTALLA DEL SISTEMA

> **Instrucción para el estudiante:**  
> Insertar aquí capturas reales de cada formulario en ejecución:
> - FrmPrincipal (menú lateral)
> - FrmLibros (listado y formulario)
> - FrmAutores
> - FrmEditoriales
> - FrmUsuarios
> - FrmPrestamos (registro y devolución)
> - FrmReportes (al menos dos reportes generados)

------------------------------------------------------------------------

# 12. PRUEBAS DE FUNCIONAMIENTO

| Prueba | Descripción | Resultado esperado | Resultado obtenido |
|--------|-------------|--------------------|--------------------|
| P01 | Registrar un nuevo libro | Se inserta y aparece en el grid | [Completar] |
| P02 | Intentar prestar libro sin existencias | Mensaje de advertencia | [Completar] |
| P03 | Registrar préstamo válido | Se crea el préstamo y se restan existencias | [Completar] |
| P04 | Registrar devolución | Estado = Devuelto y se suman existencias | [Completar] |
| P05 | Eliminar préstamo activo | Mensaje de error (solo se eliminan devueltos) | [Completar] |
| P06 | Generar reporte de préstamos activos | Se muestra solo estado = Prestado | [Completar] |
| P07 | Documento de usuario duplicado | Error de unicidad | [Completar] |
| P08 | Navegación entre módulos | Se abren correctamente todos los formularios | [Completar] |

------------------------------------------------------------------------

# 13. CONCLUSIONES

El desarrollo del Sistema de Gestión de Biblioteca permitió aplicar de manera práctica los conceptos de Programación Orientada a Objetos, el diseño de bases de datos relacionales y la implementación de una arquitectura por capas.

Se logró construir una aplicación funcional que cubre los procesos principales de una biblioteca (libros, autores, editoriales, usuarios, préstamos, devoluciones y reportes), manteniendo la integridad de los datos mediante claves foráneas, restricciones y transacciones.

El uso de consultas parametrizadas, validaciones y manejo de excepciones fortalece la robustez del sistema. La separación entre formularios, entidades y clases de acceso a datos facilita el mantenimiento y posibles ampliaciones futuras.

------------------------------------------------------------------------

# 14. RECOMENDACIONES

1. Implementar autenticación de usuarios (login) para controlar el acceso al sistema.
2. Agregar paginación o filtros avanzados en los listados de libros y préstamos.
3. Generar reportes exportables a PDF o Excel.
4. Incorporar un módulo de historial de cambios (auditoría).
5. Migrar progresivamente la lógica de los formularios restantes (Libros, Usuarios, etc.) hacia la capa DAO para mantener consistencia arquitectónica.
6. Realizar pruebas unitarias sobre las clases de acceso a datos.

------------------------------------------------------------------------

# 15. REFERENCIAS BIBLIOGRÁFICAS

Microsoft. (2024). *Windows Forms documentation*. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/desktop/winforms/

Microsoft. (2024). *Microsoft.Data.SqlClient documentation*. Microsoft Learn. https://learn.microsoft.com/en-us/sql/connect/ado-net/

Microsoft. (2024). *SQL Server documentation*. Microsoft Learn. https://learn.microsoft.com/en-us/sql/sql-server/

Troelsen, A. & Japikse, P. (2022). *Pro C# 10 with .NET 6*. Apress.

------------------------------------------------------------------------

# ANEXOS

## Anexo A. Repositorio GitHub
**Repositorio:** https://github.com/VeronicaRep/AcaBiblioteca

## Anexo B. Script de base de datos
**Archivo:** `01_CrearBaseDatos_AcaBiblioteca.sql`

## Anexo C. Evidencia de Git y GitHub
*(Insertar capturas de commits, estructura del repositorio y README).*

## Anexo D. Estructura de carpetas del proyecto
```
AcaBiblioteca/
├── Datos/
│   ├── Conexion.cs
│   ├── PrestamoDAO.cs
│   └── ReporteDAO.cs
├── Entidades/
│   ├── Autor.cs
│   ├── Editorial.cs
│   ├── Libro.cs
│   ├── Usuario.cs
│   └── Prestamo.cs
├── FrmPrincipal.cs
├── FrmInicio.cs
├── FrmLibros.cs
├── FrmAutores.cs
├── FrmEditoriales.cs
├── FrmUsuarios.cs
├── FrmPrestamos.cs
├── FrmReportes.cs
└── Program.cs
```

------------------------------------------------------------------------

# LISTA DE VERIFICACIÓN ANTES DE ENTREGAR

- [x] Portada y contraportada
- [x] Introducción y objetivos
- [x] Planteamiento del problema
- [x] Análisis de requerimientos
- [x] Casos de uso
- [ ] Diagrama de casos de uso (insertar imagen del repo)
- [ ] Diagrama de clases (insertar imagen del repo)
- [x] Modelo entidad-relación (descripción)
- [x] Diccionario de datos
- [x] Arquitectura del sistema
- [x] Explicación de cada módulo
- [ ] Capturas de pantalla (tomar en ejecución)
- [ ] Pruebas de funcionamiento (completar resultados)
- [x] Conclusiones y recomendaciones
- [x] Referencias bibliográficas (APA)
- [x] Script SQL
- [x] Código fuente completo
- [ ] Evidencia de commits en GitHub
