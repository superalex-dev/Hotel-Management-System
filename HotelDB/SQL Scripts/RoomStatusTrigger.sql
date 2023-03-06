CREATE TRIGGER RoomStatusTrigger ON Reservations
AFTER INSERT, DELETE
AS
BEGIN
    IF EXISTS(SELECT 1 FROM inserted) -- reservation inserted
    BEGIN
        UPDATE Rooms SET Status = 'Occupied' WHERE RoomId IN (SELECT RoomId FROM inserted)
    END
    ELSE -- reservation deleted
    BEGIN
        UPDATE Rooms SET Status = 'Vacant' WHERE RoomId IN (SELECT RoomId FROM deleted)
    END
END
