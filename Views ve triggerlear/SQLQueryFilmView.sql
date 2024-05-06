CREATE VIEW FilmDetayView AS
SELECT
    m.Id AS MovieId,
    m.Name AS MovieName,
    m.Description AS MovieDescription,
    m.Price AS MoviePrice,
    c.Name AS CinemaName
FROM
    Movies m
INNER JOIN
    Cinemas c ON m.CinemaId = c.Id;


