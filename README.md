# cSharp-FileUpload

by Luis Cardona

# Progress Log

Monday January 18 2021


Today I was able to start the file upload set up the database and front-end framework with CRUD OPPS.


Tuesday January 19 2021

This morning I was able to have the frontend communicate with the backend successfully. I use the same strategy that I use for the file upload in MERN where the file will be saved to local file storage. I was able to do this using Sytems, IFormFile, Pass two parameters, Loop, conditional statement, and directory.  I also added a timestamp so that I can join it with the file name to have a unique name to upload. I will push these updates and will now work with the db. I was able to save it to the database.  I had to reassign the upload file name before saving it to the database so that it has a unique name. I will push this update to Github and will work on rendering the frontend.

Wednesday January 20 2021

Today I was able to render the images in the frontend. I did this using viewbags and I foreach to loop the database. I was having issues with the image being displayed, however after talking to Josh in dicord we were able to use the dev tool to see that the code was working it was the image was deleted from the file directory. I will push this updates and and work on styling on Thursday.

Tuesday January 26 2021
This morning I got a change to work on the custom CSS style for this fileupload. I still have to implement all edit/delete CRUD opps, however, I will push the code and close this branch since it is stable. 

# Acknowledgement

I would like to thank Josh for helping discover that the image was missing from the file directory.
