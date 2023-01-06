CREATE TRIGGER update_booking_status_CheckOut
ON Bookings
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE checkOut = CURRENT_TIMESTAMP)
    BEGIN
        UPDATE Bookings
        SET [status] = 0
        FROM Bookings INNER JOIN INSERTED
        ON Bookings.bookingId = INSERTED.bookingId
        WHERE INSERTED.checkOut = CURRENT_TIMESTAMP;
    END;
END;
