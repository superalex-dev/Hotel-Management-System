CREATE PROCEDURE UpdateRoomStatus
AS
BEGIN
  SET NOCOUNT ON;

  UPDATE Rooms
  SET status = 1
  WHERE roomNumber IN (
    SELECT roomNumber
    FROM Bookings
    WHERE checkIn <= GETDATE() AND checkOut > GETDATE()
  );

  UPDATE Rooms
  SET status = 0
  WHERE roomNumber NOT IN (
    SELECT roomNumber
    FROM Bookings
    WHERE checkIn <= GETDATE() AND checkOut > GETDATE()
  );
END