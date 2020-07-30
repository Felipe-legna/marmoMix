IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Categorias] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Documento] varchar(14) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Telefone] varchar(12) NOT NULL,
    [TipoCliente] varchar(100) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Materiais] (
    [Id] uniqueidentifier NOT NULL,
    [CategoriaId] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(200) NOT NULL,
    [Custo] DECIMAL(10,3) NOT NULL,
    [Valor] DECIMAL(10,3) NOT NULL,
    CONSTRAINT [PK_Materiais] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Materiais_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [TipoEndereco] varchar(100) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(250) NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Orcamentos] (
    [Id] uniqueidentifier NOT NULL,
    [Observacoes] VARCHAR(300) NULL,
    [ValorTotal] DECIMAL(10,3) NOT NULL,
    [ClienteId] int NULL,
    CONSTRAINT [PK_Orcamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orcamentos_Clientes_ClienteId1] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Itens] (
    [Id] uniqueidentifier NOT NULL,
    [OrcamentoId] uniqueidentifier NOT NULL,
    [MaterialId] uniqueidentifier NOT NULL,
    [Saia] DECIMAL(10,3) NOT NULL,
    [Frontao] DECIMAL(10,3) NOT NULL,
    [Profundidade] DECIMAL(10,3) NOT NULL,
    [Borda] DECIMAL(10,3) NOT NULL,
    [Tampao] DECIMAL(10,3) NOT NULL,
    [Rodape] DECIMAL(10,3) NOT NULL,
    [RodapeComprimento] DECIMAL(10,3) NOT NULL,
    [RodapeTotal] DECIMAL(10,3) NOT NULL,
    [MetroQuadradoTotal] DECIMAL(10,3) NOT NULL,
    [Descricao] VARCHAR(250) NOT NULL,
    [QuantidadeItens] INTEGER NOT NULL,
    [ValorUnitario] DECIMAL(10,3) NOT NULL,
    [ValorTotal] DECIMAL(10,3) NOT NULL,
    CONSTRAINT [PK_Itens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Itens_Materiais_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [Materiais] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Itens_Orcamentos_OrcamentoId] FOREIGN KEY ([OrcamentoId]) REFERENCES [Orcamentos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [OrcamentoId] uniqueidentifier NOT NULL,
    [Nome] VARCHAR(250) NOT NULL,
    [Descricao] VARCHAR(250) NOT NULL,
    [Custo] DECIMAL(10,3) NOT NULL,
    [Valor] DECIMAL(10,3) NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Orcamentos_OrcamentoId] FOREIGN KEY ([OrcamentoId]) REFERENCES [Orcamentos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Pecas] (
    [Id] uniqueidentifier NOT NULL,
    [ItemId] uniqueidentifier NOT NULL,
    [LarguraPeca] DECIMAL(10,3) NOT NULL,
    [ApoioLargura] DECIMAL(10,3) NOT NULL,
    [ComprimentoPeca] decimal(18,2) NOT NULL,
    [ApoioComprimento] DECIMAL(10,3) NOT NULL,
    [MetroQuadradoPeca] DECIMAL(10,3) NOT NULL,
    CONSTRAINT [PK_Pecas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pecas_Itens_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Itens] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Servicos] (
    [Id] uniqueidentifier NOT NULL,
    [OrcamentoId] uniqueidentifier NOT NULL,
    [ItemId] uniqueidentifier NOT NULL,
    [Descricao] VARCHAR(250) NOT NULL,
    [Valor] DECIMAL(10,3) NOT NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Servicos_Itens_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Itens] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Servicos_Orcamentos_OrcamentoId] FOREIGN KEY ([OrcamentoId]) REFERENCES [Orcamentos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Enderecos_ClienteId] ON [Enderecos] ([ClienteId]);

GO

CREATE INDEX [IX_Itens_MaterialId] ON [Itens] ([MaterialId]);

GO

CREATE INDEX [IX_Itens_OrcamentoId] ON [Itens] ([OrcamentoId]);

GO

CREATE INDEX [IX_Materiais_CategoriaId] ON [Materiais] ([CategoriaId]);

GO

CREATE INDEX [IX_Orcamentos_ClienteId1] ON [Orcamentos] ([ClienteId1]);

GO

CREATE INDEX [IX_Pecas_ItemId] ON [Pecas] ([ItemId]);

GO

CREATE INDEX [IX_Produtos_OrcamentoId] ON [Produtos] ([OrcamentoId]);

GO

CREATE INDEX [IX_Servicos_ItemId] ON [Servicos] ([ItemId]);

GO

CREATE INDEX [IX_Servicos_OrcamentoId] ON [Servicos] ([OrcamentoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200617132142_Initial', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Itens] DROP CONSTRAINT [FK_Itens_Materiais_MaterialId];

GO

DROP INDEX [IX_Itens_MaterialId] ON [Itens];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Itens]') AND [c].[name] = N'MaterialId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Itens] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Itens] DROP COLUMN [MaterialId];

GO

ALTER TABLE [Pecas] ADD [MaterialId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

GO

CREATE INDEX [IX_Pecas_MaterialId] ON [Pecas] ([MaterialId]);

GO

ALTER TABLE [Pecas] ADD CONSTRAINT [FK_Pecas_Materiais_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [Materiais] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200619131347_Ajustado relacoes entre as entidades', N'2.2.6-servicing-10079');

GO

