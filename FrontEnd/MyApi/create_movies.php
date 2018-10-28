<!DOCTYPE html>
<html>
<head>
	<!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">

    <script type="text/javascript" src="js/jquery-3.3.1.js"></script>
	<title>Reviews</title>
</head>
<body>

	<!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <!-- <div ng-app="newMovieModule" ng-controller="newMovieController"> Hi </div> -->
    <form method="POST" enctype="multipart/form-data">
    	<br>Movie Name : <input type="text" id="name" placeholder="ex : Forrest Gump" required>
    	<br>Duration : <input type="text" id="duration" placeholder="ex : 2h 22min" required>
    	<br>Category : <input type="text" id="category" placeholder="ex : Drama,Romance" required>
    	<br>Release Date : <input type="text" id="releaseDate" placeholder="ex : 7 October 1994 (UK)" required>
    	<br>Director : <input type="text" id="director" placeholder="ex : Robert Zemeckis" required>
    	<br>Writers : <input type="text" id="writer" placeholder="ex : Winston Groom (novel),Eric Roth (screenplay)" required>
    	<br>Stars : <input type="text" id="star_Actors" placeholder="ex : Tom Hanks,Robin Wright,Gary Sinise" required>
    	<br>Trailer : <input type="text" id="trailer" placeholder="ex : Any valid link (preferred : youtube)" required>
    	<br><label for="file">Upload File:</label><input type="file" name="file" id="file" accept="image/*" onchange="loadFile(event)" />
        <img id="output" width="200" height="200"/>
        <br><input type="button" value="Refresh" onClick="window.location.reload()">
    	<br><br><input type="Submit" value="Submit" onclick="validate()"> &nbsp &nbsp <font size="4"> <a href="movies.html"> Back </a> </font>
    </form>



    <script>

    	var imageChanged = false; // if another image is selected in imagePreview

    	//Showing image
    	var loadFile = function (event) {
                        var output = document.getElementById('output');
                        output.src = URL.createObjectURL(event.target.files[0]);
                        imageChanged = true;
                    };

    	function validate()
    	{
    		var name = $('#name').val();
    		var duration = $('#duration').val();
    		var category = $('#category').val();
    		var releaseDate = $('#releaseDate').val();
    		var director = $('#director').val();
    		var writer = $('#writer').val();
    		var stars = $('#star_Actors').val();
    		var trailer = $('#trailer').val();

    		if(name != "" && duration != "" && category != "" && releaseDate != "" && director != "" && writer != "" && stars != "" && trailer != "")
    		{
    			var fullImagePath;

    			//getting imagepath
	    		
	    		if(imageChanged) //if another image is selected in Image Preview
	    		{
	    			var fileInput = document.getElementById('file');   
					var filename = fileInput.files[0].name;

					fullImagePath = './Poster/' + filename;
	    		}
	    		else // or imagepath will be previous one
	    		{
	    			fullImagePath = null;
	    		}

	    		$.ajax({
					    contentType: 'application/json',
					    data: JSON.stringify({
					    	"name": name,
					        "duration": duration,
					        "categoryName": category,
					        "releaseDate": releaseDate,
					        "director": director,
					        "writer": writer,
					        "star_Actors": stars,
					        "imagePath": fullImagePath,
					        "trailer": trailer
					    }),
					    dataType: 'json',
					    success: function(data){
					        //console.log(data);
					    },
					    error: function(){
					        //console.log("Failed");
					    },
					    type: 'POST',
					    url: 'http://localhost:59826/api/movies/'
					});
    		}
    	
    	}

    </script>

</body>
</html>

<?php
		if($_SERVER['REQUEST_METHOD'] == 'POST')
		{
			if(isset($_FILES['file']['name']))
			{
				$uploaddir = './Poster/';
				$uploadfile = $uploaddir . basename($_FILES['file']['name']);

				move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile);
			}

			echo "<script> alert('201 Created'); </script>";
		}
?>