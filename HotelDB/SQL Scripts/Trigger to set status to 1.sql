USE [HotelDB]
GO
/****** Object:  Trigger [dbo].[update_room_status_on_checkin]    Script Date: 9.1.2023 г. 13:27:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[update_room_status_on_checkin]
ON [dbo].[Bookings]
AFTER UPDATE
AS
BEGIN
    UPDATE Rooms
    SET status = 1
    WHERE roomNumber IN (SELECT roomNumber FROM inserted)
      AND (SELECT checkIn FROM inserted) = CAST(GETDATE() AS DATE)
END
