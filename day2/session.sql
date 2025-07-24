-- SELECT m.nom, k.nom
-- FROM mahsulotlar m
-- RIGHT JOIN kategoriyalar k
-- ON m.kategoriyaid = k.kategoriya_id;

-- SELECT m.nom
-- FROM mahsulotlar m
-- LEFT JOIN kategoriyalar k
-- ON m.kategoriyaid = k.kategoriya_id
-- WHERE k.kategoriya_id IS NULL;

-- SELECT m.nom, k.nom
-- FROM mahsulotlar m
-- LEFT JOIN kategoriyalar k
-- ON m.kategoriyaid = k.kategoriya_id;

-- SELECT m.nom AS mahsulot,
-- k.nom AS kategoriya
-- FROM mahsulotlar m
-- INNER JOIN kategoriyalar k
-- ON m.kategoriyaid = k.kategoriya_id;

-- SELECT m.nom, k.nom
-- FROM mahsulotlar m
-- INNER JOIN kategoriyalar k
-- ON m.kategoriyaid = k.kategoriya_id
-- WHERE k.nom = 'Elektronika';

-- 10. Narxi 1000 dan katta yoki miqdori 100 dan ko‘p

-- select * from mahsulotlar where narx > 1000 or miqdor > 100;

-- 9. Miqdori 0 ga teng emas (ya'ni omborda mavjud)

-- select * from mahsulotlar where not miqdor = 0;

-- 8. Narxi 100 dan katta, lekin 500 dan kichik

-- select * from mahsulotlar where narx between 100 and 500;


-- 7. Mahsulot nomi “N” harfi bilan boshlanadi

-- select * from mahsulotlar where nom like 'N%';

-- 6. 1, 2 yoki 5-kategoriya mahsulotlari

-- SELECT * FROM mahsulotlar WHERE kategoriyaid = 1 or kategoriyaid = 2 or kategoriyaid = 5;
-- SELECT * FROM mahsulotlar WHERE kategoriyaid IN (1, 2, 5);

-- 5. Miqdori 10 dan kam bo‘lgan mahsulotlar
-- SELECT * FROM mahsulotlar WHERE miqdor < 10;

-- 4. Nomida "kitob" so‘zi bor mahsulotlar

-- SELECT * FROM mahsulotlar WHERE nom LIKE '%kitob%';

-- 3. Kategoriyasi 'Oziq-ovqat' (kategoriya_id = 3) va narxi 2 dan katta

-- SELECT * FROM mahsulotlar where kategoriyaid = 3 and narx > 2;

-- 2. Narxi 50 dan kichik va miqdori 30 dan katta bo‘lganlar
-- SELECT * FROM mahsulotlar WHERE narx < 50 AND narx > 30;

-- 1. Narxi 200 dan katta bo‘lgan mahsulotlar
-- SELECT * FROM mahsulotlar WHERE narx > 200;

-- SELECT * FROM mahsulotlar
-- WHERE miqdor = 0;

-- SELECT * FROM mahsulotlar
-- WHERE nom LIKE '%TV%';

-- SELECT * FROM mahsulotlar
-- WHERE kategoriyaid IN (1, 4);

-- SELECT * FROM mahsulotlar
-- WHERE narx BETWEEN 50 AND 100;

-- SELECT nom, miqdor FROM mahsulotlar
-- WHERE miqdor < 50;

-- SELECT nom, narx FROM mahsulotlar;

-- SELECT * FROM mahsulotlar;

-- DELETE FROM mahsulotlar
-- WHERE miqdor = 0;

-- UPDATE mahsulotlar
-- SET narx = 900.00
-- WHERE nom = 'Noutbuk Lenovo'mahsulotlar;

-- INSERT INTO mahsulotlar (nom, kategoriyaId, narx, miqdor) VALUES
-- ('Smartfon Samsung', 1, 350.00, 20),
-- ('Noutbuk Lenovo', 1, 800.00, 15),
-- ('Quloqchin JBL', 1, 75.00, 30),
-- ('Smart TV LG', 1, 1200.00, 5),
-- ('Bluetooth Speaker', 1, 45.00, 25),

-- ('Erkaklar ko‘ylagi', 2, 25.00, 50),
-- ('Ayollar yubkasi', 2, 30.00, 40),
-- ('Bolalar futbolkasi', 2, 15.00, 60),
-- ('Kurtka', 2, 70.00, 10),
-- ('Poyabzal', 2, 50.00, 25),

-- ('Non', 3, 1.00, 100),
-- ('Sut', 3, 1.50, 80),
-- ('Go‘sht', 3, 7.00, 30),
-- ('Yog‘', 3, 3.00, 60),
-- ('Shakar', 3, 2.00, 75),

-- ('Badiiy kitob', 4, 10.00, 40),
-- ('Darslik', 4, 20.00, 35),
-- ('Roman', 4, 12.00, 20),

-- ('Futbol to‘pi', 5, 15.00, 10),
-- ('Sport sumkasi', 5, 25.00, 15);

-- INSERT INTO kategoriyalar (nom) VALUES
-- ('Elektronika'),
-- ('Kiyim-kechak'),
-- ('Uy jihozlari'),
-- ('Kitoblar'),
-- ('Sport anjomlari');

-- CREATE TABLE mahsulotlar
-- (
--   mahsulotId SERIAL PRIMARY KEY,
--   nom VARCHAR(100),
--   kategoriyaId INT REFERENCES kategoriyalar(kategoriya_id),
--   narx NUMERIC(10, 2),
--   miqdor INT
-- );

-- CREATE TABLE kategoriyalar
-- (
--   kategoriya_id SERIAL PRIMARY KEY,
--   nom VARCHAR(50)
-- );

