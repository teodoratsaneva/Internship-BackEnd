--1--
SELECT TITLE, YEAR, LENGTH
FROM MOVIE
WHERE (LENGTH > 120 OR LENGTH IS NULL) AND YEAR < 2000;

--2--
SELECT NAME, GENDER 
FROM MOVIESTAR
WHERE NAME LIKE 'J%' AND BIRTHDATE > 1948
ORDER BY NAME DESC;

--3--
SELECT STUDIONAME, COUNT(STARNAME) AS num_movies
FROM MOVIE
JOIN STARSIN ON MOVIE.TITLE = STARSIN.MOVIETITLE
GROUP BY STUDIONAME;

--4--
SELECT STARNAME, COUNT(MOVIETITLE) AS num_movies
FROM STARSIN
GROUP BY STARNAME;

--5--
SELECT NAME AS StudioName, TITLE, YEAR
FROM STUDIO
INNER JOIN MOVIE ON STUDIO.NAME = MOVIE.STUDIONAME
WHERE YEAR = (SELECT MAX(YEAR) FROM MOVIE WHERE STUDIONAME = NAME);

--6--
SELECT NAME
FROM MOVIESTAR
WHERE BIRTHDATE = (SELECT MAX(BIRTHDATE) FROM MOVIESTAR WHERE GENDER = 'M');

--7--
SELECT TITLE, YEAR, COUNT(STARNAME) AS num_actors
FROM MOVIE
JOIN STARSIN ON MOVIE.TITLE = STARSIN.MOVIETITLE AND MOVIE.YEAR = STARSIN.MOVIEYEAR
GROUP BY TITLE, YEAR
HAVING COUNT(STARNAME) > 2;