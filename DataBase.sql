
IF NOT EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME = 'Accounting')
BEGIN
	CREATE DATABASE Accounting  
	ON   
	( NAME = Accounting_dat,  
		FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Accounting_dat.mdf',  
		SIZE = 1000MB,  
		FILEGROWTH = 100MB )  
	LOG ON  
	( NAME = Accounting_log,  
		FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Accounting_log.ldf',  
		SIZE = 10MB,   
		FILEGROWTH = 5MB ) ;  
END
GO  
