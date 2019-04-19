-- sqlcmd -S "(LocalDB)\learndotnet" -i C:\smartdays\learndotnet\SmartAdLibrary\App_Data\Seed\dbo.Product.sql

DROP TABLE IF EXISTS [dbo].[Product];

CREATE TABLE [dbo].[Product]
(
	[id] INT IDENTITY PRIMARY KEY, 
  [name] NVARCHAR(50) NULL, 
  [manufacturer] NVARCHAR(MAX) NULL, 
  [price] DECIMAL(10,5) NULL
)

INSERT INTO [dbo].[Product] (manufacturer, [name], price) VALUES
  ('Mir', 'Lessive liquide Mir Raviveur de Blancheur', 4.93),
  ('Aquafresh', 'Dentifrice Aquafresh Night repair', 1.97),
  ('Plantation', 'Café en capsule Plantation Cappuccino - x8', 2.84),
  ('Nos régions ont du talent', 'Fromage Brillat Savarin 38%mg', 2.70),
  ('Nestea', 'Thé glacé Nestea Thé vert,citron, vert,menthe', 1.50);