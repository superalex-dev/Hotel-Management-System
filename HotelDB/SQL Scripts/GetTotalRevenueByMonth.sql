CREATE FUNCTION GetTotalRevenueByMonth (@Month INT, @Year INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1)
    DECLARE @EndDate DATE = DATEADD(day, -1, DATEADD(month, 1, @StartDate))
    DECLARE @TotalRevenue DECIMAL(18,2) = 0
    
    SELECT @TotalRevenue = SUM(TotalPrice)
    FROM Reservations
    WHERE CheckInDate >= @StartDate AND CheckOutDate <= @EndDate
    
    RETURN @TotalRevenue
END
