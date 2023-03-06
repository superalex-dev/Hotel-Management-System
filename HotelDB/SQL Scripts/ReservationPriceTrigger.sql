CREATE TRIGGER ReservationPriceTrigger ON Reservations
AFTER INSERT
AS
BEGIN
    UPDATE Reservations SET TotalPrice = DATEDIFF(day, CheckInDate, CheckOutDate) * (SELECT Rate FROM RoomTypes WHERE RoomTypeId = (SELECT RoomTypeId FROM inserted)) WHERE ReservationId IN (SELECT ReservationId FROM inserted)
END
