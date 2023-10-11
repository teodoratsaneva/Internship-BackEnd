--1--
SELECT COUNT(CLASS) AS NO_Classes
FROM CLASSES
WHERE TYPE = 'bb';

--2--
SELECT CLASS, AVG(NUMGUNS) AS avgGuns
FROM CLASSES
WHERE TYPE = 'bb'
GROUP BY CLASS;

--3--
SELECT AVG(NUMGUNS) AS avgGuns
FROM CLASSES
WHERE TYPE = 'bb';

--4--
SELECT CLASSES.CLASS, MIN(SHIPS.LAUNCHED), MAX(SHIPS.LAUNCHED)
FROM CLASSES
JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
GROUP BY CLASSES.CLASS;

--5--
SELECT CLASSES.CLASS, COUNT(SHIPS.NAME) AS No_Sunk
FROM CLASSES
JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
WHERE OUTCOMES.RESULT = 'sunk'
GROUP BY CLASSES.CLASS;

--6--
SELECT CLASSES.CLASS, COUNT(OUTCOMES.SHIP) AS No_Sunk
FROM CLASSES
LEFT JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
LEFT JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
WHERE OUTCOMES.RESULT = 'sunk'
GROUP BY CLASSES.CLASS
HAVING COUNT(OUTCOMES.SHIP) > 2;

--7--
SELECT COUNTRY, AVG(BORE) AS avg_bore
FROM CLASSES
JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
WHERE CLASSES.CLASS = SHIPS.CLASS
GROUP BY COUNTRY;