CREATE TRIGGER trg_Siparis_Goruntule_Insert
ON Siparis_Goruntule
INSTEAD OF INSERT
AS
BEGIN
    -- Orders tablosuna ekleme yap
    INSERT INTO Orders (Id, Email)
    SELECT Id, Email
    FROM inserted;

    -- OrderItems tablosuna ekleme yap
    INSERT INTO OrderItems (OrderId, Amount, Price)
    SELECT Id, Amount, Price
    FROM inserted;
END;
