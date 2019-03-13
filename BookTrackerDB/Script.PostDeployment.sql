/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET DATEFORMAT dmy;

MERGE INTO Author AS Target
USING (VALUES
	(1, 'Pierce Brown'),
	(2, 'Anthony Robbins'),
	(3, 'Michał Szafrański')
)
AS Source (Id, FullName)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY Target THEN
INSERT (FullName)
VALUES (FullName);

MERGE INTO Book AS Target
USING (VALUES
	(1, 'Red Rising', 1, 'Boy turns from red to gold', '28/01/2014', 1),
	(2, 'Golden Son', 1, 'Golden boy becomes leader', '06/01/2015' , 1),
	(3, 'Morning Star', 1, 'Golden boy takes his own fleet', '09/02/2016', 1),
	(4, 'Finansowy Ninja', 3, 'Get some moneyyyy', '01/01/2016', 0)
)
AS Source (Id, Name, AuthorID, Description, PublishingDate, IsRead)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY Target THEN
INSERT (Name, AuthorID, Description, PublishingDate, IsRead)
VALUES (Name, AuthorID, Description, PublishingDate, IsRead);

MERGE INTO Rating AS Target
USING (VALUES 
	(1, 9, 1),
	(2, 8, 2),
	(3, 6, 3)
)
AS Source (Id, Rate, BookID)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY Target THEN
INSERT (Rate, BookID)
VALUES (Rate, BookID);