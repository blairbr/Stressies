--Sample Update Products Statement with declared variables
	  
		 DECLARE @Id AS INT = 3
		 DECLARE @Name AS VARCHAR(100) = 'Danny'
		 DECLARE @Description AS VARCHAR(100) = 'Our tiniest stressie'
		 DECLARE @QuantityInStock AS INT = '104'
		 DECLARE @Price AS DECIMAL = 1

		 
		 UPDATE Products 
              SET Name = @Name, Description = @Description, QuantityInStock = @QuantityInStock, Price = @Price
              OUTPUT INSERTED.[Id], INSERTED.[Name], INSERTED.[Description], INSERTED.[QuantityInStock], INSERTED.[Price]
              WHERE Id = @Id


--   Notes on how to use the output clause: https://www.sqlservercentral.com/articles/the-output-clause-for-insert-and-delete-statements
