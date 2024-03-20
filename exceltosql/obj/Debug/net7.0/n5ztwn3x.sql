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

CREATE TABLE [emp] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Gender] bit NOT NULL,
    CONSTRAINT [PK_emp] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [his_icd_diagnosis1] (
    [IcdID] int NOT NULL IDENTITY,
    [IcdCode] nvarchar(200) NOT NULL,
    [LD] nvarchar(255) NULL,
    CONSTRAINT [PK_his_icd_diagnosis1] PRIMARY KEY ([IcdID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240306041128_first', N'7.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240306161053_A1', N'7.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240306161819_A2', N'7.0.16');
GO

COMMIT;
GO

