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

CREATE TABLE [ClienteFornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [Cliente] bit NOT NULL,
    [Fornecedor] bit NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [Cpf] nvarchar(18) NOT NULL,
    [DataDeNascimento] datetime2 NULL,
    [NomeFantasia] nvarchar(50) NOT NULL,
    [RazaoSocial] nvarchar(50) NOT NULL,
    [Cnpj] nvarchar(18) NOT NULL,
    [InscricaoEstadual] nvarchar(18) NOT NULL,
    [OptanteDoSimples] bit NOT NULL,
    [Observacoes] nvarchar(max) NULL,
    [Logradouro] nvarchar(50) NOT NULL,
    [Numero] int NOT NULL,
    [Bairro] nvarchar(50) NOT NULL,
    [Cidade] nvarchar(50) NOT NULL,
    [Estado] nvarchar(2) NOT NULL,
    [Cep] nvarchar(10) NOT NULL,
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_ClienteFornecedor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoDeDespesaReceita] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [Receita] bit NOT NULL,
    [Despesa] bit NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_TipoDeDespesaReceita] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TipoDePagamento] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_TipoDePagamento] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EmpreendimentoModel] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(50) NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [DataOrcamento] datetime2 NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataPrevistaTermino] datetime2 NOT NULL,
    [DataTermino] datetime2 NULL,
    [Logradouro] nvarchar(50) NOT NULL,
    [Numero] int NOT NULL,
    [Bairro] nvarchar(50) NOT NULL,
    [Cidade] nvarchar(50) NOT NULL,
    [Estado] nvarchar(2) NOT NULL,
    [Cep] nvarchar(10) NOT NULL,
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_EmpreendimentoModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmpreendimentoModel_ClienteFornecedor_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [ClienteFornecedor] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ContaModel] (
    [Id] uniqueidentifier NOT NULL,
    [EmpreendimentoId] uniqueidentifier NOT NULL,
    [Vencimento] datetime2 NOT NULL,
    [DataDoPagamento] datetime2 NULL,
    [DataDaCompra] datetime2 NULL,
    [Valor] decimal(18,2) NOT NULL,
    [ValorPago] decimal(18,2) NOT NULL,
    [NumeroDoDocumento] nvarchar(max) NOT NULL,
    [Observacoes] nvarchar(max) NOT NULL,
    [TipoDeDespesaId] uniqueidentifier NULL,
    [TipoDeDespesaReceitaId] uniqueidentifier NOT NULL,
    [TipoDePagamentoId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_ContaModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContaModel_EmpreendimentoModel_EmpreendimentoId] FOREIGN KEY ([EmpreendimentoId]) REFERENCES [EmpreendimentoModel] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId] FOREIGN KEY ([TipoDeDespesaReceitaId]) REFERENCES [TipoDeDespesaReceita] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContaModel_TipoDePagamento_TipoDePagamentoId] FOREIGN KEY ([TipoDePagamentoId]) REFERENCES [TipoDePagamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [FotoEmpreendimentoModel] (
    [Id] uniqueidentifier NOT NULL,
    [EmpreendimentoId] uniqueidentifier NOT NULL,
    [NomeDoArquivo] nvarchar(max) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [UsuarioIdCriacao] uniqueidentifier NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioIdAlteracao] uniqueidentifier NULL,
    [DataExclusao] datetime2 NULL,
    [UsuarioIdExclusao] uniqueidentifier NULL,
    CONSTRAINT [PK_FotoEmpreendimentoModel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FotoEmpreendimentoModel_EmpreendimentoModel_EmpreendimentoId] FOREIGN KEY ([EmpreendimentoId]) REFERENCES [EmpreendimentoModel] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ContaModel_EmpreendimentoId] ON [ContaModel] ([EmpreendimentoId]);
GO

CREATE INDEX [IX_ContaModel_TipoDeDespesaReceitaId] ON [ContaModel] ([TipoDeDespesaReceitaId]);
GO

CREATE INDEX [IX_ContaModel_TipoDePagamentoId] ON [ContaModel] ([TipoDePagamentoId]);
GO

CREATE INDEX [IX_EmpreendimentoModel_ClienteId] ON [EmpreendimentoModel] ([ClienteId]);
GO

CREATE INDEX [IX_FotoEmpreendimentoModel_EmpreendimentoId] ON [FotoEmpreendimentoModel] ([EmpreendimentoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220803005049_Inicial', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'RazaoSocial');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [RazaoSocial] nvarchar(50) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'NomeFantasia');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [NomeFantasia] nvarchar(50) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'Nome');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [Nome] nvarchar(50) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'InscricaoEstadual');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [InscricaoEstadual] nvarchar(18) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'Cpf');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [Cpf] nvarchar(18) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ClienteFornecedor]') AND [c].[name] = N'Cnpj');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ClienteFornecedor] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [ClienteFornecedor] ALTER COLUMN [Cnpj] nvarchar(18) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220809231244_alteracao cadastro', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [EmpreendimentoModel] DROP CONSTRAINT [FK_EmpreendimentoModel_ClienteFornecedor_ClienteId];
GO

ALTER TABLE [FotoEmpreendimentoModel] ADD [Descricao] nvarchar(max) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmpreendimentoModel]') AND [c].[name] = N'ClienteId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [EmpreendimentoModel] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [EmpreendimentoModel] ALTER COLUMN [ClienteId] uniqueidentifier NULL;
GO

ALTER TABLE [EmpreendimentoModel] ADD CONSTRAINT [FK_EmpreendimentoModel_ClienteFornecedor_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [ClienteFornecedor] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220810002153_descricao da foto', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ContaModel] DROP CONSTRAINT [FK_ContaModel_EmpreendimentoModel_EmpreendimentoId];
GO

ALTER TABLE [ContaModel] DROP CONSTRAINT [FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId];
GO

ALTER TABLE [ContaModel] DROP CONSTRAINT [FK_ContaModel_TipoDePagamento_TipoDePagamentoId];
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContaModel]') AND [c].[name] = N'TipoDePagamentoId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ContaModel] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [ContaModel] ALTER COLUMN [TipoDePagamentoId] uniqueidentifier NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContaModel]') AND [c].[name] = N'TipoDeDespesaReceitaId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ContaModel] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [ContaModel] ALTER COLUMN [TipoDeDespesaReceitaId] uniqueidentifier NULL;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ContaModel]') AND [c].[name] = N'EmpreendimentoId');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ContaModel] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [ContaModel] ALTER COLUMN [EmpreendimentoId] uniqueidentifier NULL;
GO

ALTER TABLE [ContaModel] ADD CONSTRAINT [FK_ContaModel_EmpreendimentoModel_EmpreendimentoId] FOREIGN KEY ([EmpreendimentoId]) REFERENCES [EmpreendimentoModel] ([Id]);
GO

ALTER TABLE [ContaModel] ADD CONSTRAINT [FK_ContaModel_TipoDeDespesaReceita_TipoDeDespesaReceitaId] FOREIGN KEY ([TipoDeDespesaReceitaId]) REFERENCES [TipoDeDespesaReceita] ([Id]);
GO

ALTER TABLE [ContaModel] ADD CONSTRAINT [FK_ContaModel_TipoDePagamento_TipoDePagamentoId] FOREIGN KEY ([TipoDePagamentoId]) REFERENCES [TipoDePagamento] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220810010831_alteração de contas', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ClienteFornecedor] ADD [Email] nvarchar(max) NULL;
GO

ALTER TABLE [ClienteFornecedor] ADD [Telefone] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220811223809_contato', N'6.0.7');
GO

COMMIT;
GO

