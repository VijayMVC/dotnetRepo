USE master
GO
 
CREATE LOGIN DvdLibraryApp WITH PASSWORD='Testing123'
GO

USE DvdList
GO
 
CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON AddDvd TO DvdLibraryApp
GRANT EXECUTE ON DbReset TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectAll TO DvdLibraryApp
GRANT EXECUTE ON EditDvd TO DvdLibraryApp
GRANT EXECUTE ON GetDvd TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByDate TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByDirector TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByRating TO DvdLibraryApp
GRANT EXECUTE ON GetDvdsByTitle TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO


