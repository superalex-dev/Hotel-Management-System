USE [HotelDB]
GO
/****** Object:  Trigger [dbo].[update_room_status_on_checkout]    Script Date: 9.1.2023 г. 13:28:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[update_room_status_on_checkout]
ON [dbo].[Bookings]
AFTER UPDATE
AS
BEGIN
    UPDATE Rooms
    SET status = 0
    WHERE roomNumber IN (SELECT roomNumber FROM inserted)
      AND (SELECT checkOut FROM inserted) < CAST(GETDATE() AS DATE)
END