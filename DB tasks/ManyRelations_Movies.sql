--1--
SELECT MS.NAME 
FROM MOVIESTAR MS 
INNER JOIN STARSIN SI ON MS.NAME = SI.STARNAME 
WHERE SI.MOVIETITLE = 'The Usual Suspects' AND MS.GENDER = 'M';

--2--
SELECT MS.NAME 
FROM MOVIESTAR MS 
INNER JOIN STARSIN SI ON MS.NAME = SI.STARNAME 
INNER JOIN MOVIE M ON SI.MOVIETITLE = M.TITLE 
WHERE SI.MOVIEYEAR = 1995 AND M.STUDIONAME = 'MGM';

--3--
SELECT DISTINCT ME.NAME 
FROM MOVIEEXEC ME JOIN MOVIE M ON ME.CERT# = M.PRODUCERC# 
JOIN STUDIO S ON S.NAME = M.STUDIONAME 
WHERE S.NAME = 'MGM';

--4--
SELECT TITLE 
FROM MOVIE 
WHERE LEN(TITLE) > LEN('STAR WARS');

--5--
SELECT NAME 
FROM MOVIEEXEC 
WHERE NETWORTH > 
(SELECT NETWORTH 
FROM MOVIEEXEC 
WHERE NAME = 'Stephen Spielberg');

--6--
SELECT M.TITLE 
FROM MOVIE M 
INNER JOIN MOVIEEXEC ME ON ME.CERT# = M.PRODUCERC# 
WHERE ME.NETWORTH > 
(SELECT NETWORTH 
FROM MOVIEEXEC 
WHERE NAME = 'Stephen Spielberg');