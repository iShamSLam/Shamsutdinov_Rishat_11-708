use ControlWork;
GO

ALTER TABLE PAT
DROP COLUMN ADRES;
GO 

ALTER TABLE PAT
ADD GOROD nvarchar(30);
GO
ALTER TABLE PAT
ADD ULICA nvarchar(50);
GO

/*ъ опнярн ме сяоек!*/