INSERT INTO CITIES(UPDATE_COUNTER, [NAME], REGION)
VALUES(0, N'Русе', N'България'),
		(0, N'Пловдив', N'България'),
		(0, N'Бургас', N'България'),
		(0, N'София', N'България'),
		(0, N'Варна', N'България');
GO

INSERT INTO FIELD_TYPES(FIELD_TYPE)
VALUES(N'Маркетинг'),
		(N'ИТ');
GO

INSERT INTO FIELDS(UPDATE_COUNTER,FIELD_TYPE_ID,[NAME])
VALUES(0, 1, N'ПР'),
		(0, 1, N'Реклама'),
		(0, 2, N'Клауд Услуги'),
		(0, 2, N'Уеб приложения');
GO

INSERT INTO COMPANIES(UPDATE_COUNTER, [NAME], CITY_ID, FIELD_ID, [ADDRESS])
VALUES(0, N'Strategic Objectives', 4, 1, N'България'),
		(0, N'Firecracker PR', 1, 1, N'България'),
		(0, N'Matter Communications', 2, 1, N'България'),
		(0, N'Bateman Group', 4, 1, N'България'),
		(0, N'Jelly Digital Marketing & PR', 3, 1, N'България'),
		(0, N'Bob Gold & Associates', 4, 1, N'България');
GO

INSERT INTO PROJECT_SIZES(PROJECT_SIZE)
VALUES(N'SMALL'),
		(N'MEDIUM'),
		(N'LARGE'),
		(N'Co-Project');
GO

INSERT INTO PROJECTS(UPDATE_COUNTER,[NAME], COMPANY_ID, PROJECT_SIZE_ID, [START_DATE], END_DATE, BUDGET)
VALUES(0, N'France PR', 1, 4, '20191010', '20191010', 25000),
		(0, N'Trump Campaign', 1, 4, '20190110', '20190808', 35000),
		(0, N'UAE Project', 1, 3, DEFAULT, '20191212', 15000),
		(0, N'Coke Winter Campaign', 1, 2, DEFAULT, '20190210', 7000),
		(0, N'Global Foods Regional', 1, 1, DEFAULT, '20190305', 1500);
GO

INSERT INTO ACCOUNT_TYPES([NAME])
VALUES(N'Income'),
		(N'Expenses');
GO

INSERT INTO USERS (USERNAME, [PASSWORD], COMPANY_ID)
VALUES (N'Daniel', N'140194',1)
GO

INSERT INTO ACCOUNTS(UPDATE_COUNTER,[NAME], ACCOUNT_TYPE_ID, COMPANY_ID)
VALUES(0, N'Salaries', 2, 1),
		(0, N'Maintenance', 2, 1),
		(0, N'Campaign Expenses', 2, 1),
		(0, N'Projects Income', 1, 1);
GO

INSERT INTO TRANSACTION_TYPES([NAME])
VALUES(N'Deduction'),
		(N'Revenue'),
		(N'Tax Free');
GO

INSERT INTO TRANSACTIONS(UPDATE_COUNTER,[NAME], TRANSACTION_TYPE_ID, ACCOUNT_ID, AMOUNT, [DATE], PROJECT_ID)
VALUES(0, N'Employee Salaries', 1, 1, -10000, DEFAULT, 1),
		(0, N'Employee Salaries', 1, 1, -12000, DEFAULT, 2),
		(0, N'Maintenance', 1, 2, -3500, DEFAULT, 2),
		(0, N'Party Funding', 2, 4, 15000, DEFAULT, 2),
		(0, N'Trump Personal', 2, 4, 50000, DEFAULT, 2),
		(0, N'Traven Expenses', 1, 3, -25000, DEFAULT, 2),
		(0, N'Donations', 3, 4, 23000, DEFAULT, 2);
GO
