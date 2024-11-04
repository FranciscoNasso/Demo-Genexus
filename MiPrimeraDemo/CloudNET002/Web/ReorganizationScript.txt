CREATE TABLE [Cliente] ([CustomerID] smallint NOT NULL IDENTITY(1,1), [CustomerName] nchar(20) NOT NULL , [CustomerAddress] nvarchar(1024) NOT NULL , [CustomerEmail] nvarchar(100) NOT NULL , PRIMARY KEY([CustomerID]));
SET IDENTITY_INSERT [Cliente] ON;
INSERT INTO [Cliente] ([CustomerID], [CustomerName], [CustomerAddress], [CustomerEmail]) SELECT [CustomerID], [CustomerName], '', '' FROM (SELECT [CustomerID], [CustomerName], ROW_NUMBER() OVER (PARTITION BY CustomerID ORDER BY CustomerID DESC) As _GX_ROW_NUMBER FROM [Transaction1]) T WHERE _GX_ROW_NUMBER = 1;
SET IDENTITY_INSERT [Cliente] OFF;

CREATE NONCLUSTERED INDEX [ITRANSACTION2] ON [Transaction1] ([CustomerID] );
ALTER TABLE [Transaction1] DROP COLUMN [CustomerName];

ALTER TABLE [Transaction1] ADD CONSTRAINT [ITRANSACTION2] FOREIGN KEY ([CustomerID]) REFERENCES [Cliente] ([CustomerID]);

