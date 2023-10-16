--1--
SELECT *
FROM SHIPS
LEFT JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS

--2--
SELECT *
FROM SHIPS
RIGHT JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS

--3--
SELECT COUNTRY, SHIPS.NAME
FROM CLASSES
JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
WHERE SHIPS.NAME NOT IN
(SELECT SHIP
FROM OUTCOMES)
ORDER BY COUNTRY;

--4--
SELECT NAME AS "Ship Name"
FROM SHIPS
LEFT JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS
WHERE CLASSES.NUMGUNS >= 7 AND SHIPS.LAUNCHED = 1916;

--5--
SELECT SHIPS.NAME, BATTLE, BATTLES.DATE
FROM SHIPS
JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
LEFT JOIN BATTLES ON OUTCOMES.BATTLE = BATTLES.NAME
WHERE OUTCOMES.RESULT = 'sunk'
ORDER BY BATTLE;

--6--
SELECT NAME, DISPLACEMENT, LAUNCHED
FROM SHIPS
LEFT JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS
WHERE SHIPS.NAME = SHIPS.CLASS;

--7--
SELECT *
FROM CLASSES
LEFT JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
WHERE SHIPS.NAME IS NULL;


--8--
SELECT NAME, DISPLACEMENT, NUMGUNS, RESULT
FROM CLASSES
LEFT JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
LEFT JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
WHERE BATTLE = 'North Atlantic';