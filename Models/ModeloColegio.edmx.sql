
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/05/2024 22:02:10
-- Generated from EDMX file: C:\Users\tjonh\source\repos\ApiColegio\ApiColegio\Models\ModeloColegio.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ColegiosPublicos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TutorMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_TutorMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_EstudianteMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_EstudianteMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_RolUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_RolUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_RolPermiso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permisos] DROP CONSTRAINT [FK_RolPermiso];
GO
IF OBJECT_ID(N'[dbo].[FK_GradoMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_GradoMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_MateriaCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_MateriaCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_EstudianteCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_EstudianteCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodoMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_PeriodoMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_GradoGradoEnCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradosEnCursos] DROP CONSTRAINT [FK_GradoGradoEnCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_MaestroGradoEnCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradosEnCursos] DROP CONSTRAINT [FK_MaestroGradoEnCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_GradoEnCursoMateria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Materias] DROP CONSTRAINT [FK_GradoEnCursoMateria];
GO
IF OBJECT_ID(N'[dbo].[FK_SeccionGradoEnCurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GradosEnCursos] DROP CONSTRAINT [FK_SeccionGradoEnCurso];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioMatricula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Matriculas] DROP CONSTRAINT [FK_ColegioMatricula];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioEstudiante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estudiantes] DROP CONSTRAINT [FK_ColegioEstudiante];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioMaestro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Maestros] DROP CONSTRAINT [FK_ColegioMaestro];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioSeccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Secciones] DROP CONSTRAINT [FK_ColegioSeccion];
GO
IF OBJECT_ID(N'[dbo].[FK_ColegioUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_ColegioUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Estudiantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estudiantes];
GO
IF OBJECT_ID(N'[dbo].[Maestros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Maestros];
GO
IF OBJECT_ID(N'[dbo].[Matriculas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Matriculas];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Permisos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permisos];
GO
IF OBJECT_ID(N'[dbo].[Tutores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tutores];
GO
IF OBJECT_ID(N'[dbo].[Grados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grados];
GO
IF OBJECT_ID(N'[dbo].[Secciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Secciones];
GO
IF OBJECT_ID(N'[dbo].[Materias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Materias];
GO
IF OBJECT_ID(N'[dbo].[Calificaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calificaciones];
GO
IF OBJECT_ID(N'[dbo].[Periodos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Periodos];
GO
IF OBJECT_ID(N'[dbo].[GradosEnCursos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GradosEnCursos];
GO
IF OBJECT_ID(N'[dbo].[Colegios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colegios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Estudiantes'
CREATE TABLE [dbo].[Estudiantes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoEstudiante] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [Sexo] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Activo] tinyint  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [ColegioId] int  NOT NULL
);
GO

-- Creating table 'Maestros'
CREATE TABLE [dbo].[Maestros] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoMaestro] nvarchar(max)  NOT NULL,
    [Cedula] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [Sexo] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL,
    [Activo] tinyint  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [ColegioId] int  NOT NULL
);
GO

-- Creating table 'Matriculas'
CREATE TABLE [dbo].[Matriculas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TutorId] int  NOT NULL,
    [EstudianteId] int  NOT NULL,
    [GradoId] int  NOT NULL,
    [PeriodoId] int  NOT NULL,
    [CodigoMatricula] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [ColegioProcedencia] nvarchar(max)  NOT NULL,
    [Repitente] tinyint  NOT NULL,
    [Activo] nvarchar(max)  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [ColegioId] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RolId] int  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [NombreDeUsuario] nvarchar(max)  NOT NULL,
    [ClaveUsuario] nvarchar(max)  NOT NULL,
    [CorreoRecuperacion] nvarchar(max)  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [Activo] tinyint  NOT NULL,
    [ColegioId] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreRol] nvarchar(max)  NOT NULL,
    [DescripcionRol] nvarchar(max)  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Permisos'
CREATE TABLE [dbo].[Permisos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RolId] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Tutores'
CREATE TABLE [dbo].[Tutores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [RelacionConElEstudiante] nvarchar(max)  NOT NULL,
    [Cedula] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Grados'
CREATE TABLE [dbo].[Grados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Nivel] nvarchar(max)  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Secciones'
CREATE TABLE [dbo].[Secciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [CapacidadEstudiantes] nvarchar(max)  NOT NULL,
    [Activo] nvarchar(max)  NOT NULL,
    [ColegioId] int  NOT NULL
);
GO

-- Creating table 'Materias'
CREATE TABLE [dbo].[Materias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GradoEnCursoId] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Grado] nvarchar(max)  NOT NULL,
    [Activo] tinyint  NOT NULL,
    [FechaModificacion] datetime  NOT NULL
);
GO

-- Creating table 'Calificaciones'
CREATE TABLE [dbo].[Calificaciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MateriaId] int  NOT NULL,
    [EstudianteId] int  NOT NULL,
    [NotaCualitativa] nvarchar(max)  NOT NULL,
    [NotaNumerica] float  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Periodos'
CREATE TABLE [dbo].[Periodos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Año] int  NOT NULL,
    [FechaModificacion] datetime  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'GradosEnCursos'
CREATE TABLE [dbo].[GradosEnCursos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GradoId] int  NOT NULL,
    [MaestroId] int  NOT NULL,
    [SeccionId] int  NOT NULL,
    [Año] int  NOT NULL,
    [Activo] tinyint  NOT NULL
);
GO

-- Creating table 'Colegios'
CREATE TABLE [dbo].[Colegios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoColegio] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Direccion] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Activo] tinyint  NOT NULL,
    [FechaModificacion] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Maestros'
ALTER TABLE [dbo].[Maestros]
ADD CONSTRAINT [PK_Maestros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [PK_Matriculas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [PK_Permisos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tutores'
ALTER TABLE [dbo].[Tutores]
ADD CONSTRAINT [PK_Tutores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Grados'
ALTER TABLE [dbo].[Grados]
ADD CONSTRAINT [PK_Grados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Secciones'
ALTER TABLE [dbo].[Secciones]
ADD CONSTRAINT [PK_Secciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Materias'
ALTER TABLE [dbo].[Materias]
ADD CONSTRAINT [PK_Materias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Calificaciones'
ALTER TABLE [dbo].[Calificaciones]
ADD CONSTRAINT [PK_Calificaciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Periodos'
ALTER TABLE [dbo].[Periodos]
ADD CONSTRAINT [PK_Periodos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GradosEnCursos'
ALTER TABLE [dbo].[GradosEnCursos]
ADD CONSTRAINT [PK_GradosEnCursos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Colegios'
ALTER TABLE [dbo].[Colegios]
ADD CONSTRAINT [PK_Colegios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TutorId] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_TutorMatricula]
    FOREIGN KEY ([TutorId])
    REFERENCES [dbo].[Tutores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TutorMatricula'
CREATE INDEX [IX_FK_TutorMatricula]
ON [dbo].[Matriculas]
    ([TutorId]);
GO

-- Creating foreign key on [EstudianteId] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_EstudianteMatricula]
    FOREIGN KEY ([EstudianteId])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteMatricula'
CREATE INDEX [IX_FK_EstudianteMatricula]
ON [dbo].[Matriculas]
    ([EstudianteId]);
GO

-- Creating foreign key on [RolId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_RolUsuario]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolUsuario'
CREATE INDEX [IX_FK_RolUsuario]
ON [dbo].[Usuarios]
    ([RolId]);
GO

-- Creating foreign key on [RolId] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [FK_RolPermiso]
    FOREIGN KEY ([RolId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolPermiso'
CREATE INDEX [IX_FK_RolPermiso]
ON [dbo].[Permisos]
    ([RolId]);
GO

-- Creating foreign key on [GradoId] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_GradoMatricula]
    FOREIGN KEY ([GradoId])
    REFERENCES [dbo].[Grados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradoMatricula'
CREATE INDEX [IX_FK_GradoMatricula]
ON [dbo].[Matriculas]
    ([GradoId]);
GO

-- Creating foreign key on [MateriaId] in table 'Calificaciones'
ALTER TABLE [dbo].[Calificaciones]
ADD CONSTRAINT [FK_MateriaCalificacion]
    FOREIGN KEY ([MateriaId])
    REFERENCES [dbo].[Materias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MateriaCalificacion'
CREATE INDEX [IX_FK_MateriaCalificacion]
ON [dbo].[Calificaciones]
    ([MateriaId]);
GO

-- Creating foreign key on [EstudianteId] in table 'Calificaciones'
ALTER TABLE [dbo].[Calificaciones]
ADD CONSTRAINT [FK_EstudianteCalificacion]
    FOREIGN KEY ([EstudianteId])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteCalificacion'
CREATE INDEX [IX_FK_EstudianteCalificacion]
ON [dbo].[Calificaciones]
    ([EstudianteId]);
GO

-- Creating foreign key on [PeriodoId] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_PeriodoMatricula]
    FOREIGN KEY ([PeriodoId])
    REFERENCES [dbo].[Periodos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoMatricula'
CREATE INDEX [IX_FK_PeriodoMatricula]
ON [dbo].[Matriculas]
    ([PeriodoId]);
GO

-- Creating foreign key on [GradoId] in table 'GradosEnCursos'
ALTER TABLE [dbo].[GradosEnCursos]
ADD CONSTRAINT [FK_GradoGradoEnCurso]
    FOREIGN KEY ([GradoId])
    REFERENCES [dbo].[Grados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradoGradoEnCurso'
CREATE INDEX [IX_FK_GradoGradoEnCurso]
ON [dbo].[GradosEnCursos]
    ([GradoId]);
GO

-- Creating foreign key on [MaestroId] in table 'GradosEnCursos'
ALTER TABLE [dbo].[GradosEnCursos]
ADD CONSTRAINT [FK_MaestroGradoEnCurso]
    FOREIGN KEY ([MaestroId])
    REFERENCES [dbo].[Maestros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaestroGradoEnCurso'
CREATE INDEX [IX_FK_MaestroGradoEnCurso]
ON [dbo].[GradosEnCursos]
    ([MaestroId]);
GO

-- Creating foreign key on [GradoEnCursoId] in table 'Materias'
ALTER TABLE [dbo].[Materias]
ADD CONSTRAINT [FK_GradoEnCursoMateria]
    FOREIGN KEY ([GradoEnCursoId])
    REFERENCES [dbo].[GradosEnCursos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradoEnCursoMateria'
CREATE INDEX [IX_FK_GradoEnCursoMateria]
ON [dbo].[Materias]
    ([GradoEnCursoId]);
GO

-- Creating foreign key on [SeccionId] in table 'GradosEnCursos'
ALTER TABLE [dbo].[GradosEnCursos]
ADD CONSTRAINT [FK_SeccionGradoEnCurso]
    FOREIGN KEY ([SeccionId])
    REFERENCES [dbo].[Secciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeccionGradoEnCurso'
CREATE INDEX [IX_FK_SeccionGradoEnCurso]
ON [dbo].[GradosEnCursos]
    ([SeccionId]);
GO

-- Creating foreign key on [ColegioId] in table 'Matriculas'
ALTER TABLE [dbo].[Matriculas]
ADD CONSTRAINT [FK_ColegioMatricula]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioMatricula'
CREATE INDEX [IX_FK_ColegioMatricula]
ON [dbo].[Matriculas]
    ([ColegioId]);
GO

-- Creating foreign key on [ColegioId] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [FK_ColegioEstudiante]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioEstudiante'
CREATE INDEX [IX_FK_ColegioEstudiante]
ON [dbo].[Estudiantes]
    ([ColegioId]);
GO

-- Creating foreign key on [ColegioId] in table 'Maestros'
ALTER TABLE [dbo].[Maestros]
ADD CONSTRAINT [FK_ColegioMaestro]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioMaestro'
CREATE INDEX [IX_FK_ColegioMaestro]
ON [dbo].[Maestros]
    ([ColegioId]);
GO

-- Creating foreign key on [ColegioId] in table 'Secciones'
ALTER TABLE [dbo].[Secciones]
ADD CONSTRAINT [FK_ColegioSeccion]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioSeccion'
CREATE INDEX [IX_FK_ColegioSeccion]
ON [dbo].[Secciones]
    ([ColegioId]);
GO

-- Creating foreign key on [ColegioId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_ColegioUsuario]
    FOREIGN KEY ([ColegioId])
    REFERENCES [dbo].[Colegios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ColegioUsuario'
CREATE INDEX [IX_FK_ColegioUsuario]
ON [dbo].[Usuarios]
    ([ColegioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------