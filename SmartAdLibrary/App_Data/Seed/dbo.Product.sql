DROP TABLE IF EXISTS [dbo].[Product];

CREATE TABLE [dbo].[Product]
(
	[id] INT NOT NULL PRIMARY KEY, 
  [name] NVARCHAR(50) NULL, 
  [manufacturer] NVARCHAR(MAX) NULL, 
  [price] DECIMAL(10,5) NULL
)

INSERT INTO [dbo].[Product] (id, manufacturer, [name], price) VALUES
  (1, 'Mir', 'Lessive liquide Mir Raviveur de Blancheur', 4.93),
  (2, 'Aquafresh', 'Dentifrice Aquafresh Night repair', 1.97),
  (3, 'Plantation', 'Café en capsule Plantation Cappuccino - x8', 2.84),
  (4, 'Nos régions ont du talent', 'Fromage Brillat Savarin 38%mg', 2.70),
  (5, 'Nestea', 'Thé glacé Nestea Thé vert,citron, vert,menthe', 1.50);