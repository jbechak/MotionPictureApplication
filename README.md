# MotionPictureApplication
Motion Picture Data Management Application

To run the application:

1. Set up the Database: MotionPictureApp/database/MotionPicturesDB.sql contains the scripts 
	to create the database.	Run this script in SQL Server Management Studio and connect the 
	project to the database.

2. Run the API: Open MotionPictureApplication/MotionPictureApp/MotionPictureApp.sln in MS 
	Visual Studio Community 2019. Run MotionPictureApp. The API should run at the Base URL of
	https://localhost:5001.

3. Run the client: Open MotionPictureApplication/MotionPictureApp/Vue in MS Visual Studio 
	Code. In a terminal	window, type 'npm install'. Next type 'npm run serve'. The client
	should run at http://localhost:8080.
