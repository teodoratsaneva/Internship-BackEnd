--1--
SELECT TITLE, MOVIEEXEC.NAME
FROM MOVIEEXEC
JOIN MOVIE ON MOVIEEXEC.CERT# = MOVIE.PRODUCERC#
WHERE MOVIEEXEC.CERT# = 
(SELECT MOVIE.PRODUCERC#
FROM MOVIE
WHERE TITLE = 'Star Wars');

--2--
SELECT DISTINCT ME.NAME AS Producer
FROM MOVIE M
JOIN MOVIEEXEC ME ON M.PRODUCERC# = ME.CERT#
JOIN STARSIN SI ON M.TITLE = SI.MOVIETITLE AND M.YEAR = SI.MOVIEYEAR
JOIN MOVIESTAR MS ON SI.STARNAME = MS.NAME
WHERE MS.NAME = 'Harrison Ford';

--3--
SELECT S.NAME AS Studio, MS.NAME AS Actor
FROM STUDIO S
JOIN MOVIE M ON S.NAME = M.STUDIONAME
JOIN STARSIN SI ON M.TITLE = SI.MOVIETITLE AND M.YEAR = SI.MOVIEYEAR
JOIN MOVIESTAR MS ON SI.STARNAME = MS.NAME
ORDER BY S.NAME, MS.NAME;

--4--
SELECT DISTINCT MS.NAME, ME.NETWORTH, M.TITLE
FROM MOVIE M
INNER JOIN MOVIEEXEC ME ON M.PRODUCERC# = ME.CERT#
INNER JOIN STARSIN SI ON M.TITLE = SI.MOVIETITLE AND M.YEAR = SI.MOVIEYEAR
INNER JOIN MOVIESTAR MS ON SI.STARNAME = MS.NAME
WHERE ME.NETWORTH = (SELECT MAX(NETWORTH) FROM MOVIEEXEC)
ORDER BY M.TITLE;

--5--
SELECT MS.NAME, SI.MOVIETITLE
FROM MOVIESTAR MS
LEFT JOIN STARSIN SI ON MS.NAME = SI.STARNAME
WHERE SI.STARNAME IS NULL;

