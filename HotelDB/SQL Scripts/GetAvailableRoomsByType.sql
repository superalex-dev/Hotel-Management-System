CREATE FUNCTION GetAvailableRoomsByType (@RoomTypeId INT, @StartDate DATE, @EndDate DATE)
RETURNS TABLE
AS
RETURN (
    SELECT Rooms.RoomId, Rooms.RoomNumber, Rooms.Status
    FROM Rooms
    WHERE RoomTypeId = @RoomTypeId
        AND NOT EXISTS (
            SELECT 1
            FROM Reservations
            WHERE Reservations.RoomId = Rooms.RoomId
                AND Reservations.CheckInDate < @EndDate
                AND Reservations.CheckOutDate > @StartDate
        )
)
