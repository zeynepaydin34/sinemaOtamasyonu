CREATE TRIGGER trg_CinemaDetailView_Insert
ON SinemaDetayView
INSTEAD OF INSERT
AS
BEGIN
    -- ��eri eklenen verileri Cinemas tablosuna ekle
    INSERT INTO Cinemas (Name, Description)
    SELECT CinemaName, CinemaDescription
    FROM inserted;
END;