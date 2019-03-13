SET DATEFORMAT dmy;

INSERT INTO [dbo].[Author]
VALUES 
	(1, 'Pierce Brown'),
	(2, 'Anthony Robbins'),
	(3, 'Michał Szafrański');

INSERT INTO [dbo].[Book]
VALUES
	(1, 'Red Rising', 1, 'Boy turns from red to gold', '28/01/2014', 1),
	(2, 'Golden Son', 1, 'Golden boy becomes leader', '06/01/2015' , 1),
	(3, 'Morning Star', 1, 'Golden boy takes his own fleet', '09/02/2016', 1),
	(4, 'Finansowy Ninja', 3, 'Get some moneyyyy', '01/01/2016', 0);

INSERT INTO [dbo].[Rating]
VALUES
	(1, 9, 1),
	(2, 8, 2),
	(3, 6, 3);