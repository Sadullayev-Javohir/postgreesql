-- SELECT * FROM employees;
-- CALL icrease_salary(3, 1000);
-- CREATE OR REPLACE PROCEDURE icrease_salary(emp_id INT, amount NUMERIC)
-- LANGUAGE plpgsql
-- AS $$
-- BEGIN
--   UPDATE employees SET salary = salary + amount WHERE id = emp_id;
-- END;
-- $$;

-- SELECT * FROM employee_age_category;
-- CREATE VIEW employee_age_category AS
-- SELECT name,
-- CASE
--   WHEN age < 30 THEN 'Young'
--   WHEN age BETWEEN 30 AND 50 THEN 'Mid-age'
--   ELSE 'Senior'
-- END AS age_category
-- FROM employees;

-- SELECT * FROM department_employee_count;
-- CREATE VIEW department_employee_count AS
-- SELECT d.name AS department, COUNT(e.id) AS employee_count
-- FROM departments d
-- LEFT JOIN employees e ON d.id = e.department_id
-- GROUP BY d.name;

-- SELECT * FROM highsalaryemployee;

-- CREATE VIEW highsalaryemployee AS
-- SELECT id, name, salary FROM employees WHERE salary > 10000;


-- SELECT * FROM high_salary_employees;

-- CREATE VIEW high_salary_employees AS
-- SELECT id, name, salary FROM employees WHERE salary > 10000;

-- SELECT * FROM highSalary;
-- CREATE VIEW highSalary AS
-- SELECT name,
--   salary
-- FROM emloyees
-- WHERE salary > 4000;
-- WITH topSalaries AS
-- (
--   SELECT * FROM emloyees WHERE salary > 5000
-- )
-- SELECT name FROM topSalaries WHERE departmentId = 2;
-- SELECT name FROM emloyees
-- WHERE departmentid =
-- (
--   SELECT id FROM departments WHERE name = 'IT'
-- );
-- INSERT INTO emloyees (name, age, salary, departmentId) VALUES
-- ('Ali', 28, 9000.00, 1),
-- ('Zafar', 45, 12000.00, 1),
-- ('Dilnoza', 34, 8000.00, 2),
-- ('Sardor', 50, 11000.00, 3),
-- ('Gulbahor', 29, 7000.00, 2);
-- INSERT INTO departments (name) VALUES
-- ('IT'),
-- ('HR'),
-- ('Finance');
-- CREATE TABLE emloyees
-- (
--   id SERIAL PRIMARY KEY,
--   name TEXT NOT NULL,
--   age INT,
--   salary NUMERIC(10, 2),
--   departmentId INT REFERENCES departments(id)
-- );
-- CREATE TABLE departments
-- (
--   id SERIAL PRIMARY KEY,
--   name TEXT NOT NULL
-- );
