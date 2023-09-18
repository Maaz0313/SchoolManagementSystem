DELETE FROM StudentTable
DBCC CHECKIDENT ('SchoolMgtDb.dbo.StudentTable', RESEED, 0)