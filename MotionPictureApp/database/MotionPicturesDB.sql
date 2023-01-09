BEGIN TRANSACTION;

DROP TABLE IF EXISTS MotionPictures;

CREATE TABLE MotionPictures (
	ID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(500) NOT NULL,
	[Release Year] INT NOT NULL
);

INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES ('Star Wars', 'Sci-Fi Classic', 1977);

INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES ('Back to the Future', 'Marty McFly and Doc at their Best', 1985);

INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES ('Pulp Fiction', 'A Tarantino gem of the 90''s. Is that the correct release year?', 1997);

INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES ('Parasite', 'Excellent Korean dark comedy thriller', 2019);

INSERT INTO MotionPictures (Name, Description, [Release Year])
VALUES ('Terrible Movie', 'This would be a great movie to delete', 2022);

COMMIT;