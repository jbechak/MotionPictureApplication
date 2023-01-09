DROP PROCEDURE IF EXISTS getAllMovies
DROP PROCEDURE IF EXISTS getMovie
DROP PROCEDURE IF EXISTS createMovie
DROP PROCEDURE IF EXISTS updateMovie
DROP PROCEDURE IF EXISTS deleteMovie

GO
CREATE Procedure getAllMovies
AS
SELECT * from MotionPictures 

GO
CREATE Procedure getMovie(@id INT)
AS
SELECT * from MotionPictures 
WHERE ID = @id;

GO
CREATE Procedure createMovie(@name NVARCHAR(50), @description NVARCHAR(500), @releaseYear INT)
AS
INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES (@name, @description, @releaseYear);

GO
CREATE Procedure updateMovie(@id INT, @name NVARCHAR(50), @description NVARCHAR(500), @releaseYear INT)
AS
UPDATE MotionPictures 
SET Name = @name, Description = @description, [Release Year] = @releaseYear
WHERE ID = @id;

GO
CREATE Procedure deleteMovie(@id INT)
AS
DELETE from MotionPictures 
WHERE ID = @id;

