CREATE PROCEDURE CheckRoomAvailability
    @RoomId INT,
    @CheckInDate DATE,
    @CheckOutDate DATE
AS
BEGIN
    SELECT COUNT(*) AS NumReservations
    FROM Reservations
    WHERE RoomId = @RoomId
        AND CheckInDate <= @CheckOutDate
        AND CheckOutDate >= @CheckInDate
END
