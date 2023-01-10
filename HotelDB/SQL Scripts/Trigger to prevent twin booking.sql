CREATE TRIGGER tr_PreventDoubleBooking
ON Bookings
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @bookedRoom INT;
    DECLARE @checkIn DATE;
    DECLARE @checkOut DATE;

    SELECT @bookedRoom = roomNumber, @checkIn = checkIn, @checkOut = checkOut
    FROM inserted;

    IF EXISTS (SELECT roomNumber FROM Bookings WHERE roomNumber = @bookedRoom AND @checkIn BETWEEN checkIn AND checkOut OR @checkOut BETWEEN checkIn AND checkOut)
    BEGIN
        RAISERROR ('This room is already booked during the specified dates', 16, 1);
        ROLLBACK TRANSACTION;
    END

END
