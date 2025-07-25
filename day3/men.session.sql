SELECT category, COUNT(*) AS mahsulotsoni
FROM products
GROUP BY category
HAVING COUNT(*) > 4;

SELECT category, MAX(price) AS engarzon
FROM products
GROUP BY category;

SELECT category, AVG(price)
AS ortachanarx
FROM products
GROUP BY category;

SELECT category, SUM(price) AS umumiynarx
FROM products
GROUP BY category;

SELECT category, COUNT(*) AS mahsulotnomi
FROM products
GROUP BY category;

INSERT INTO products (productname, category, price) VALUES
('Telefon', 'Elektronika', 500),
('Noutbuk', 'Elektronika', 1200),
('Kir yuvish', 'Maishiy', 800),
('Sovutgich', 'Maishiy', 950),
('Blender', 'Maishiy', 200),
('Kamera', 'Elektronika', 700),
('Changyutgich', 'Maishiy', 400),
('Mikrotolqin', 'Maishiy', 300);

CREATE TABLE products
(
  productid SERIAL PRIMARY KEY,
  productname VARCHAR(50),
  category VARCHAR(50),
  price INTEGER
);

SELECT MAX(studentid) FROM students;
SELECT MIN(studentid) FROM students;
SELECT AVG(studentid) FROM students;
SELECT SUM(studentid) FROM students;
SELECT COUNT(*) FROM students;
SELECT students.name, courses.courseName
FROM students
INNER JOIN enrollments ON students.studentid = enrollments.studentid
INNER JOIN courses ON enrollments.courseid = courses.courseid;
SELECT students.name,
enrollments.courseid
FROM students
INNER JOIN enrollments
ON students.studentid = enrollments.courseid;
SELECT students.name, enrollments.courseid
FROM students
INNER JOIN enrollments
ON students.studentid = enrollments.studentid;
INSERT INTO courses (courseName) VALUES
('Biology');
SELECT * FROM students;
INSERT INTO students(name, age) VALUES
('Jasur', 56);
SELECT s.name, c.courseName
FROM students s
FULL JOIN enrollments e ON s.studentid = e.studentid
FULL JOIN courses c ON e.courseid = c.courseid;
SELECT * FROM enrollments;
INSERT INTO enrollments (studentId, courseId) VALUES
(1, 1),
(1, 2),
(2, 1),
(3, 3),
(4, 4);
CREATE TABLE enrollments
(
  studentId INT,
  courseId INT,
  FOREIGN KEY (studentId) REFERENCES students(studentId),
  FOREIGN KEY (courseId) REFERENCES courses(courseId)
);
SELECT *
FROM courses;
INSERT INTO courses (courseName) VALUES
('Mathematics'),
('Physics'),
('English'),
('History');
CREATE TABLE courses
(
  courseId SERIAL PRIMARY KEY,
  courseName VARCHAR(100)
);
CREATE TABLE students
(
  studentId SERIAL PRIMARY KEY,
  name VARCHAR(100),
  age INT
);
INSERT INTO students(name, age) VALUES
('Ali', 20),
('Malika', 22),
('Rustam', 19),
('Aziza', 21)
