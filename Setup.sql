/* Schema : Table 
Creating a Table
  We only need to this at the start of the database the very first time
   Required : NOT NULL
 */
CREATE TABLE artists (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'artist name',
  birthYear int comment 'artist birth year',
  deceased TINYINT comment 'artist is deceased'
) default charset utf8;
/* REVIEW */
CREATE TABLE pieces (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'artist name',
  artistId int NOT NULL,
  FOREIGN KEY (artistId) REFERENCES artists(id) ON DELETE CASCADE
);
INSERT INTO
  pieces (name, artistId)
VALUES
  ('Mona Lisa', 1);
SELECT
  *
FROM
  pieces
WHERE
  artistId = 1;
  /* 
    SECTION AlterTable 
    */
  /* ALTER TABLE
    ALTER COLUMN name varchar(255) comment 'artist name'; */
  /* SECTION CREATE */
INSERT INTO
  artists (name, birthYear, deceased)
VALUES
  ('Leonardo DiCaprio', 1974, 0);
  /* SECTION READ
                    '*' is all columns
                     */
  /* getALL */
SELECT
  *
FROM
  artists;
  /* getBy */
SELECT
  *
from
  artists
WHERE
  id = 2
LIMIT
  1;
  /* UPDATE */
UPDATE
  artists
SET
  name = "Leonardo W DiCaprio"
WHERE
  id = 2;
  /* DESTROY */
DELETE FROM
  artists
WHERE
  id = 2
LIMIT
  1;
  /* DANGER ZONE */
  /* Removes all rows if not provided a where */
DELETE FROM
  artists;
  /* Removes whole table */
  DROP TABLE artists;
  /* Removes entire Database */
  DROP DATABASE Classroom;