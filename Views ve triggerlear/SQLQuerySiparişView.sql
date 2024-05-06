CREATE VIEW Siparis_Goruntule AS 
SELECT
    o.Id,
    o.Email,
    oi.Amount,
    oi.Price
FROM 
    Orders o
JOIN 
    OrderItems oi ON o.Id = oi.OrderId;
