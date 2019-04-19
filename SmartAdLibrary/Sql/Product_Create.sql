/*
DECLARE 
  @Name nvarchar(50) = 'Name',
  @Manufacturer nvarchar(50) = 'Make',
  @Price DECIMAL = 12.45,
  @QuantityValue DECIMAL = 1.2,
  @QuantityUnit nvarchar(50) = 'Liter'
*/

INSERT INTO [dbo].[Product] (name, manufacturer, price)
VALUES (@Name, @Manufacturer, @Price)

DECLARE @Id INT = SCOPE_IDENTITY();
SELECT @Id;