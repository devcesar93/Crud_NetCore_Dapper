# Crud_NetCore_Dapper

Exemplo de um programa de cadastro utilizando o Micro ORM Dapper para fazer a comunicação com banco de dados SQL Server.
Também foi utilizada a extensão Dapper.Contrib para facilitar algumas tarefas do CRUD.


Script das tabelas utilizadas:

CREATE TABLE [dbo].[Veiculo_Marca](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Veiculo_Marca] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]





CREATE TABLE [dbo].[Veiculo_Modelo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ano] [int] NOT NULL,
	[MarcaId] [int] NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[PrecoFipe] [float] NOT NULL,
	[Tipo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Veiculo_Modelo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Veiculo_Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Veiculo_Modelo_Veiculo_Marca_MarcaId] FOREIGN KEY([MarcaId])
REFERENCES [dbo].[Veiculo_Marca] ([Id])
GO

ALTER TABLE [dbo].[Veiculo_Modelo] CHECK CONSTRAINT [FK_Veiculo_Modelo_Veiculo_Marca_MarcaId]
GO
