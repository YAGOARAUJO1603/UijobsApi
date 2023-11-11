IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Candidatos] (
    [Id] int NOT NULL IDENTITY,
    [NomeMae] nvarchar(max) NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL UNIQUE,
    [Cep] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Candidatos] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cep', N'Email', N'Nome', N'NomeMae') AND [object_id] = OBJECT_ID(N'[Candidatos]'))
    SET IDENTITY_INSERT [Candidatos] ON;
INSERT INTO [Candidatos] ([Id], [Cep], [Email], [Nome], [NomeMae])
VALUES (1, N'02124050', N'yago.pereira7@etec.sp.gov.br', N'Yago', N'Elaine'),
(2, N'02124040', N'Daniel@etec.sp.gov.br', N'Daniel', N'Maria'),
(3, N'02179010', N'Lara@etec.sp.gov.br', N'Lara', N'Maria Beatriz');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cep', N'Email', N'Nome', N'NomeMae') AND [object_id] = OBJECT_ID(N'[Candidatos]'))
    SET IDENTITY_INSERT [Candidatos] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230714013917_InicialCreate', N'7.0.9');
GO

COMMIT;
GO

