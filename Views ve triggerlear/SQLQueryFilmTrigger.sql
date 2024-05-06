CREATE TRIGGER trg_FilmDetayView_Insert
ON FilmDetayView
INSTEAD OF INSERT
AS
BEGIN
    
    INSERT INTO Movies (Name, Description, Price, CinemaId)
    SELECT MovieName, MovieDescription, MoviePrice, (SELECT Id FROM Cinemas WHERE Name = inserted.CinemaName)
    FROM inserted;
END;
