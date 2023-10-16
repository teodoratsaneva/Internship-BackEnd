--1--
SELECT DISTINCT NAME
FROM SHIPS
RIGHT JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
WHERE NAME LIKE 'C%' OR NAME LIKE 'K%';

--2--
SELECT NAME, COUNTRY
FROM SHIPS
JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS
WHERE NAME NOT IN 
(SELECT SHIP
FROM OUTCOMES
WHERE RESULT = 'sunk');

--3--
SELECT COUNTRY, COUNT(SHIP) AS num_sunk_ships
FROM CLASSES 
LEFT JOIN SHIPS ON CLASSES.CLASS = SHIPS.CLASS
LEFT JOIN OUTCOMES ON SHIPS.NAME = OUTCOMES.SHIP
WHERE RESULT = 'sunk' OR RESULT IS NULL
GROUP BY COUNTRY;

--4--
SELECT NAME
FROM BATTLES
WHERE 
(SELECT COUNT(SHIP)
FROM OUTCOMES
WHERE BATTLE = NAME) > 
(SELECT COUNT(SHIP)
FROM OUTCOMES
WHERE BATTLE = 'Guadalcanal');

--5--
SELECT NAME 
FROM BATTLES
WHERE 
(SELECT COUNT(SHIP)
FROM OUTCOMES
WHERE BATTLE = NAME) > 
(SELECT COUNT(SHIP)
FROM OUTCOMES
WHERE BATTLE = 'Surigao Strait');


--6--
SELECT TOP 4 NAME, MIN(DISPLACEMENT) AS displacement, MAX(NUMGUNS) AS numGuns
FROM SHIPS
JOIN CLASSES ON SHIPS.CLASS = CLASSES.CLASS
GROUP BY NAME
ORDER BY DISPLACEMENT ASC;

--7--
SELECT DISTINCT COUNT(S1.NAME)
FROM SHIPS AS S1
JOIN OUTCOMES AS O1 ON S1.NAME = O1.SHIP AND O1.RESULT = 'damaged'
JOIN BATTLES AS B1 ON O1.BATTLE = B1.NAME
JOIN SHIPS AS S2 ON S1.NAME = S2.NAME
JOIN OUTCOMES AS O2 ON S2.NAME = O2.SHIP AND O2.RESULT = 'ok'
JOIN BATTLES AS B2 ON O2.BATTLE = B2.NAME
WHERE B2.DATE > B1.DATE

--8--
SELECT DISTINCT S1.NAME
FROM SHIPS AS S1
JOIN OUTCOMES AS O1 ON S1.NAME = O1.SHIP AND O1.RESULT = 'damaged'
JOIN BATTLES AS B1 ON O1.BATTLE = B1.NAME
JOIN SHIPS AS S2 ON S1.NAME = S2.NAME
JOIN OUTCOMES AS O2 ON S2.NAME = O2.SHIP AND O2.RESULT = 'ok'
JOIN BATTLES AS B2 ON O2.BATTLE = B2.NAME
WHERE B2.DATE > B1.DATE