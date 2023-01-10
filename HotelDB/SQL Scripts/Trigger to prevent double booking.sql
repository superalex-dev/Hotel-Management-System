CREATE TRIGGER prevent_double_booking
ON Bookings
AFTER INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Rooms WHERE roomNumber IN (SELECT roomNumber FROM inserted) AND status = 1)
    BEGIN
        RAISERROR('This room is already booked!', 16, 1)
        ROLLBACK TRANSACTION
    END
END