
CREATE DATABASE [Member]
GO

USE [Member]
GO

CREATE TABLE [dbo].[Member](
	[id]   [int] Not NULL,
	[name] [varchar](255) NOT NULL,
	[email][varchar](255) NOT NULL,
	[age][int] Not NULL,
	[sex][varchar](5) Not NULL,
	[account]  [varchar](50) NOT NULL,
	[password]  [varchar](50) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[Member] ([id], [name], [email],[age],[sex],[account],[password]) VALUES (1,'陳豪震','haozhen1106@gmail.com',21,'男','manager','manager');

GO
