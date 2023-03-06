ALTER PROCEDURE CreateReservation
    @RoomId INT,
    @GuestId INT,
    @CheckInDate DATE,
    @CheckOutDate DATE,
    @TotalPrice DECIMAL(18,2) OUTPUT
AS
BEGIN
    DECLARE @ReservationId INT
    
    BEGIN TRY
        BEGIN TRANSACTION
        
        INSERT INTO Reservations (RoomId, GuestId, CheckInDate, CheckOutDate, TotalPrice)
        VALUES (@RoomId, @GuestId, @CheckInDate, @CheckOutDate, @TotalPrice)
        
        SELECT @ReservationId = SCOPE_IDENTITY()
        
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION
        
        SET @ReservationId = NULL
        SET @TotalPrice = NULL
    END CATCH
    
    SELECT @ReservationId, @TotalPrice
END
