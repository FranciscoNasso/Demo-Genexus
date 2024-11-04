CREATE TABLE [Transaction1Product] ([InvoiceID] smallint NOT NULL , [ProductID] smallint NOT NULL , [ProductName] nchar(20) NOT NULL , [ProductPrice] smallmoney NOT NULL , [InvoiceProductQuantity] smallint NOT NULL , PRIMARY KEY([InvoiceID], [ProductID]));

CREATE TABLE [Transaction1] ([InvoiceID] smallint NOT NULL IDENTITY(1,1), [InvoiceDate] datetime NOT NULL , [CustomerID] smallint NOT NULL , [CustomerName] nchar(20) NOT NULL , PRIMARY KEY([InvoiceID]));

ALTER TABLE [Transaction1Product] ADD CONSTRAINT [ITRANSACTION1PRODUCT1] FOREIGN KEY ([InvoiceID]) REFERENCES [Transaction1] ([InvoiceID]);

