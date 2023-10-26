--1--
SELECT DISTINCT maker
FROM product
JOIN PC ON product.model = PC.model
WHERE PC.speed > 500;

--2--
SELECT code, model, price
FROM printer
WHERE price = 
(SELECT MAX(price) 
FROM printer);

--3--
SELECT *
FROM laptop
WHERE speed <
(SELECT min(speed)
FROM PC);

--4--
SELECT TOP 1 p.model, MAX(price) AS price
FROM (
    SELECT model, price FROM pc
    UNION ALL
    SELECT model, price FROM laptop
    UNION ALL
    SELECT model, price FROM printer
) AS p
GROUP BY p.model
ORDER BY price DESC;

--5--
SELECT TOP 1 p.maker
FROM product p
JOIN printer ON p.model = printer.model
WHERE printer.color = 'y'
ORDER BY printer.price ASC;

--6--
SELECT DISTINCT p.maker
FROM product p
JOIN pc ON p.model = pc.model
WHERE pc.ram = 
(SELECT MIN(ram) 
FROM pc 
WHERE speed = 
(SELECT MAX(speed) 
FROM pc));
