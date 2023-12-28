-- 1. Select the guests who have booked rooms on multiple occasions:
SELECT Guest.*, COUNT(Booking.Id) AS BookingCount
FROM Guest
INNER JOIN Booking ON Guest.Id = Booking.GuestId
GROUP BY Guest.Id
HAVING COUNT(Booking.Id) > 1;

-- 2. Select the average grade for each room from reviews:
SELECT Room.Id, AVG(Review.Grade) AS AverageGrade
FROM Room
LEFT JOIN Booking ON Room.Id = Booking.RoomId
LEFT JOIN Review ON Booking.Id = Review.BookingId
GROUP BY Room.Id;

-- 3. Select the employees who earn more than the average salary:
SELECT * FROM Employee WHERE Salary > (SELECT AVG(Salary) FROM Employee);

-- 4. Select the guests who have made a booking in the last month:
SELECT Guest.*, Booking.*
FROM Guest
INNER JOIN Booking ON Guest.Id = Booking.GuestId
WHERE Booking.Check_In_Date >= DATEADD(MONTH, -1, GETDATE());

-- 5. Select the rooms with the highest total booking price:
SELECT Room.*, SUM(Booking.Total_Price) AS TotalBookingPrice
FROM Room
LEFT JOIN Booking ON Room.Id = Booking.RoomId
GROUP BY Room.Id
ORDER BY TotalBookingPrice DESC;

-- 6. Select the bookings with the earliest check-in date:
SELECT TOP 1 * FROM Booking ORDER BY Check_In_Date;

-- 7. Select the guests who have booked a room on the highest floor:
SELECT Guest.*
FROM Guest
INNER JOIN Booking ON Guest.Id = Booking.GuestId
INNER JOIN Room ON Booking.RoomId = Room.Id
WHERE Room.Floor = (SELECT MAX(Floor) FROM Room);

-- 8. Select the documents of guests whose last name starts with a specific letter:
SELECT Document.*
FROM Document
INNER JOIN Guest ON Document.Id = Guest.DocumentId
WHERE Guest.LastName LIKE 'Letter%';

-- 9. Select the categories with no associated rooms:
SELECT Category.*
FROM Category
LEFT JOIN Room ON Category.Id = Room.CategoryId
WHERE Room.Id IS NULL;

-- 10. Select the employees with the highest salary in each position:
SELECT Employee.*
FROM (
    SELECT PositionId, MAX(Salary) AS MaxSalary
    FROM Employee
    GROUP BY PositionId
) AS MaxSalaries
INNER JOIN Employee ON MaxSalaries.PositionId = Employee.PositionId AND MaxSalaries.MaxSalary = Employee.Salary;

-- 11. Select the average grade for each employee based on reviews of bookings they managed:
SELECT Employee.Id, AVG(Review.Grade) AS AverageGrade
FROM Employee
LEFT JOIN Booking ON Employee.Id = Booking.EmployeeId
LEFT JOIN Review ON Booking.Id = Review.BookingId
GROUP BY Employee.Id;

-- 12. Select the bookings where the check-in date is within the next week:
SELECT * FROM Booking WHERE Check_In_Date BETWEEN GETDATE() AND DATEADD(WEEK, 1, GETDATE());

-- 13. Select the guests with the highest number of bookings:
SELECT Guest.Id, COUNT(Booking.Id) AS BookingCount
FROM Guest
LEFT JOIN Booking ON Guest.Id = Booking.GuestId
GROUP BY Guest.Id
ORDER BY BookingCount DESC;

-- 14. Select the rooms that have never been booked:
SELECT Room.*
FROM Room
LEFT JOIN Booking ON Room.Id = Booking.RoomId
WHERE Booking.Id IS NULL;

-- 15. Select the guests with a document issued before a specific date:
SELECT Guest.*
FROM Guest
INNER JOIN Document ON Guest.DocumentId = Document.Id
WHERE Document.BirthDate < '2022';

-- 16. Select the rooms with a price above the average category price:
SELECT Room.*
FROM Room
INNER JOIN Category ON Room.CategoryId = Category.Id
WHERE Room.Price > (SELECT AVG(Price) FROM Category);

-- 17. Select the bookings with a total price below a specific threshold:
SELECT * FROM Booking WHERE Total_Price < [ThresholdPrice];

-- 18. Select the guests who have booked a room with a specific category name:
SELECT Guest.*
FROM Guest
INNER JOIN Booking ON Guest.Id = Booking.GuestId
INNER JOIN Room ON Booking.RoomId = Room.Id
INNER JOIN Category ON Room.CategoryId = Category.Id
WHERE Category.Name = 'Expensive';

-- 19. Select the total number of bookings for each room:
SELECT Room.Id, COUNT(Booking.Id) AS BookingCount
FROM Room
LEFT JOIN Booking ON Room.Id = Booking.RoomId
GROUP BY Room.Id;

-- 20. Select the bookings with check-out dates in the past and order them by check-out date:
SELECT * FROM Booking WHERE Check_Out_Date < GETDATE() ORDER BY Check_Out_Date DESC;
