/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Naziv]
      ,[Ime]
      ,[Stanje]
  FROM [BozicniPokloni].[dbo].[Pokloni]


  use BozicniPokloni;
  insert into Pokloni (naziv,ime, stanje) values ('ivan', 'ivan', 0);

 UPDATE pokloni SET (naziv,ime,stanje) VALUES ('SSSSS', 'SSSSSS', 0) where id = 1