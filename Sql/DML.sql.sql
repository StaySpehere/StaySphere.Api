     
-- Insert data into the Document table

  INSERT INTO Document (Serial_Number, First_Name, Last_Name, Birth_Date, Gender)
  VALUES
    ('SN001', 'John', 'Doe', '1990-05-15', 'Male'),
    ('SN002', 'Jane', 'Smith', '1985-12-10', 'Female'),
    ('SN003', 'Alice', 'Johnson', '1992-03-20', 'Female'),
    ('SN004', 'Bob', 'Wilson', '1988-08-12', 'Male'),
    ('SN005', 'Eva', 'Williams', '1991-07-18', 'Female'),
    ('SN006', 'Michael', 'Brown', '1987-04-25', 'Male'),
    ('SN007', 'Sophia', 'Wilson', '1991-03-12', 'Female'),
    ('SN008', 'Matthew', 'Johnson', '1986-11-05', 'Male'),
    ('SN009', 'Olivia', 'Clark', '1995-09-30', 'Female'),
    ('SN010', 'Daniel', 'Garcia', '1984-01-08', 'Male'),
    ('SN011', 'Sophie', 'Lee', '1993-06-22', 'Female'),
    ('SN012', 'William', 'Martinez', '1989-02-14', 'Male'),
    ('SN013', 'Ava', 'Anderson', '1994-10-28', 'Female'),
    ('SN014', 'James', 'Taylor', '1990-09-03', 'Male'),
    ('SN015', 'Oliver', 'Moore', '1983-12-05', 'Male'),
    ('SN016', 'Charlotte', 'Brown', '1987-07-19', 'Female'),
    ('SN017', 'Liam', 'Johnson', '1988-04-30', 'Male'),
    ('SN018', 'Mia', 'Davis', '1993-02-14', 'Female'),
    ('SN019', 'Lucas', 'Smith', '1986-11-30', 'Male'),
    ('SN020', 'Isabella', 'Williams', '1992-05-25', 'Female');

/* test
SELECT * FROM Document;
*/

-- Insert data into the Category table

  INSERT INTO Category (Name, Price)
  VALUES
    ('Category1', 100.00),
    ('Category2', 150.00),
    ('Category3', 120.00),
    ('Category4', 180.00),
    ('Category5', 140.00),
    ('Category6', 160.00),
    ('Category7', 130.00),
    ('Category8', 170.00),
    ('Category9', 110.00),
    ('Category10', 200.00),
    ('Category11', 90.00),
    ('Category12', 220.00),
    ('Category13', 80.00),
    ('Category14', 240.00),
    ('Category15', 70.00),
    ('Category16', 260.00),
    ('Category17', 60.00),
    ('Category18', 280.00),
    ('Category19', 50.00),
    ('Category20', 300.00);

/* test
SELECT * FROM Category;
*/

 -- Insert data into the Position table         
  INSERT INTO Position (Name, Salary)
  VALUES
    ('Manager', 5000.00),
    ('Receptionist', 2500.00),
    ('Housekeeping', 2200.00),
    ('Chef', 4500.00),
    ('Waiter', 2000.00),
    ('Bartender', 2200.00),
    ('Security', 2400.00),
    ('Maintenance', 2300.00),
    ('Concierge', 2600.00),
    ('Front Desk Clerk', 2100.00),
    ('Sales Manager', 4800.00),
    ('Accountant', 4000.00),
    ('HR Manager', 4600.00),
    ('Bellhop', 1900.00),
    ('Porter', 1800.00),
    ('Valet', 1700.00),
    ('Spa Therapist', 2300.00),
    ('Fitness Instructor', 2100.00),
    ('Event Planner', 4200.00),
    ('IT Specialist', 3800.00);

/* test 
SELECT * FROM Position;
*/

-- Insert data into the Guest table
INSERT INTO Guest (Document_Id, Phone_Number, Email)
VALUES
    (1, '123-456-7890', 'john.doe@email.com'),
    (2, '555-555-5555', 'jane.smith@email.com'),
    (3, '777-777-7777', 'alice.johnson@email.com'),
    (4, '444-444-4444', 'bob.wilson@email.com'),
    (5, '333-333-3333', 'eva.williams@email.com'),
    (6, '222-222-2222', 'michael.brown@email.com'),
    (7, '111-111-1111', 'sophia.wilson@email.com'),
    (8, '999-999-9999', 'matthew.johnson@email.com'),
    (9, '888-888-8888', 'olivia.clark@email.com'),
    (10, '777-777-7777', 'daniel.garcia@email.com'),
    (11, '666-666-6666', 'sophie.lee@email.com'),
    (12, '555-555-5555', 'william.martinez@email.com'),
    (13, '444-444-4444', 'ava.anderson@email.com'),
    (14, '333-333-3333', 'james.taylor@email.com'),
    (15, '222-222-2222', 'oliver.moore@email.com'),
    (16, '111-111-1111', 'charlotte.brown@email.com'),
    (17, '999-999-9999', 'liam.johnson@email.com'),
    (18, '888-888-8888', 'mia.davis@email.com'),
    (19, '777-777-7777', 'lucas.smith@email.com'),
    (20, '666-666-6666', 'isabella.williams@email.com');

/* test 
SELECT * FROM Guest;
*/

-- Insert data into the Room table
INSERT INTO Room (Category_Id, Number, Floor)
VALUES
    (1, 101, 1),
    (2, 102, 1),
    (3, 201, 2),
    (4, 202, 2),
    (5, 301, 3),
    (6, 302, 3),
    (7, 401, 4),
    (8, 402, 4),
    (9, 501, 5),
    (10, 502, 5),
    (11, 601, 6),
    (12, 602, 6),
	(13, 702, 7),
    (14, 801, 8),
    (15, 802, 8),
    (16, 901, 9),
    (17, 902, 9),
    (18, 1001, 10),
    (19, 1002, 10),
    (20, 1101, 11);

/* test 
SELECT * FROM Room;
*/
   -- Insert data into the Employee table
INSERT INTO Employee (Position_Id, First_Name, Last_Name, Phone_Number, Salary)
VALUES
    (1, 'Michael', 'Johnson', '987-654-3210', 4500.00),
    (2, 'Emily', 'Brown', '111-222-3333', 2200.00),
    (3, 'William', 'Clark', '123-987-6543', 2900.00),
    (4, 'Sarah', 'Anderson', '555-123-4567', 3800.00),
    (5, 'David', 'Lee', '999-888-7777', 2900.00),
    (6, 'Ava', 'Martinez', '888-777-6666', 4000.00),
    (7, 'James', 'Taylor', '222-333-4444', 3100.00),
    (8, 'Olivia', 'Davis', '777-888-9999', 4200.00),
    (9, 'Matthew', 'Johnson', '666-555-4444', 3600.00),
    (10, 'Sophia', 'Wilson', '555-666-7777', 3400.00),
    (11, 'Daniel', 'Garcia', '777-555-4444', 3700.00),
    (12, 'Sophie', 'Lee', '555-777-8888', 3200.00),
    (13, 'Liam', 'Johnson', '444-555-6666', 3500.00),
    (14, 'Mia', 'Davis', '555-666-7777', 3300.00),
    (15, 'Lucas', 'Smith', '666-777-8888', 4100.00),
    (16, 'Isabella', 'Williams', '777-888-9999', 3900.00),
    (17, 'Oliver', 'Moore', '555-444-3333', 2800.00),
    (18, 'Charlotte', 'Brown', '333-222-1111', 2600.00),
    (19, 'Aiden', 'Wilson', '555-666-7777', 3100.00),
    (20, 'Ella', 'Smith', '777-666-5555', 2700.00);

/* test 
SELECT * FROM Employee;
*/

-- Insert data into the Booking table
INSERT INTO Booking (Guest_Id, Employee_Id, Room_Id, Check_In_Date, Check_Out_Date, Total_Price)
VALUES
    (1, 1, 1, '2023-10-01', '2023-10-05', 400.00),
    (2, 2, 2, '2023-09-28', '2023-10-02', 600.00),
    (3, 3, 3, '2023-10-10', '2023-10-15', 600.00),
    (4, 4, 4, '2023-10-05', '2023-10-09', 720.00),
    (5, 5, 5, '2023-10-20', '2023-10-25', 700.00),
    (6, 6, 6, '2023-10-15', '2023-10-19', 800.00),
    (7, 7, 7, '2023-10-28', '2023-11-01', 850.00),
    (8, 8, 8, '2023-11-01', '2023-11-05', 750.00),
    (9, 9, 9, '2023-11-10', '2023-11-15', 920.00),
    (10, 10, 10, '2023-11-05', '2023-11-09', 780.00),
    (11, 11, 11, '2023-11-20', '2023-11-25', 1050.00),
    (12, 12, 12, '2023-11-15', '2023-11-19', 880.00),
	(13, 13, 13,'2023-11-5', '2023-11-9', 889.00),
	(14, 13, 13, '2023-11-28', '2023-12-03', 960.00),
    (15, 14, 14, '2023-12-01', '2023-12-05', 880.00),
    (16, 15, 15, '2023-12-10', '2023-12-15', 1020.00),
    (17, 16, 16, '2023-12-05', '2023-12-09', 920.00),
    (18, 17, 17, '2023-12-20', '2023-12-25', 1250.00),
    (19, 18, 18, '2023-12-15', '2023-12-19', 980.00),
    (20, 19, 19, '2023-12-28', '2023-12-31', 1150.00);

/* test  
SELECT * FROM Booking;
*/

-- Insert data into the Review table
INSERT INTO Review (Booking_Id, Comment, Grade)
VALUES
    (21, 'Great stay!', 5),
    (2, 'Nice hotel!', 4),
    (3, 'Enjoyed my stay!', 4),
    (4, 'Fantastic service!', 5),
    (5, 'Lovely experience!', 4),
    (6, 'Outstanding hotel!', 5),
    (7, 'Wonderful stay!', 5),
    (8, 'Excellent service!', 4),
    (9, 'Highly recommended!', 5),
    (10, 'Friendly staff!', 4),
    (11, 'Beautiful room!', 5),
    (12, 'Perfect vacation!', 5),
    (13, 'Cozy atmosphere!', 4),
    (14, 'Excellent hospitality!', 5),
    (15, 'Amazing views!', 4),
    (16, 'Clean and comfortable!', 5),
    (17, 'Great location!', 4),
    (18, 'Top-notch service!', 5),
    (19, 'Impressive amenities!', 4),
    (20, 'Memorable experience!', 5);
  
/* test
SELECT * FROM Review
*/