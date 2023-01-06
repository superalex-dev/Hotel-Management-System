CREATE TRIGGER update_booking_status
ON Bookings
AFTER UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM INSERTED WHERE checkIn = CURRENT_TIMESTAMP)
    BEGIN
        UPDATE Bookings
        SET [status] = 1
        FROM Bookings INNER JOIN INSERTED
        ON Bookings.bookingId = INSERTED.bookingId
        WHERE INSERTED.checkIn = CURRENT_TIMESTAMP;
    END;
END;
