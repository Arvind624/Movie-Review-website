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

    <div><h2><font color="red">Are you sure ?</font></h2></div> <div><h4><a href="movies.html"> Go Back </a></h4><div>

    <!-- <div ng-app="newMovieModule" ng-controller="newMovieController"> Hi </div> -->
    <form method="POST" enctype="multipart/form-data">
        <br>Movie Id : <div id="id"></div>
    	<br>Movie Name : <div id="name"></div>
    	<br>Duration : <div id="duration"></div>
    	<br>Category : <div id="category"></div>
    	<br>Release Date : <div id="releaseDate"></div>
    	<br>Director : <div id="director"></div>
    	<br>Writers : <div id="writer"></div>
    	<br>Stars : <div id="star_Actors"></div>
    	<br>Trailer : <div id="trailer"></div>
        <img src="" id="output" width="200" height="200"/>
    	<br><br><input type="Submit" value="Delete" onclick="validate()">
    </form>

    <script type="text/javascript">
    	//extracting movie id from url
    	var url = ((window.location.href).split('=')); //getting movie id
			url = url[url.length-1];
			//console.log(url);
			var requestString = 'http://localhost:59826/api/movies/' + url;

    	//script to get a movie details
    	$.ajax({
        url: requestString,
        type: 'GET',
        dataType: 'json', // added data type
        success: function(res) {
            console.log(res.imagePath);
            //alert(res);

            //Set html textbox with movies info
            $('#id').html(res.id);
            $('#name').html(res.name);
    		$('#duration').html(res.duration);
    		$('#category').html(res.categoryName);
    		$('#releaseDate').html(res.releaseDate);
    		$('#director').html(res.director);
    		$('#writer').html(res.writer);
    		$('#star_Actors').html(res.star_Actors);
            $('#trailer').html(res.trailer);
    		$('#output').attr('src', res.imagePath);
        }
    });

    </script>



    <script>

    	function validate() //Deleting ..
    	{
            $.ajax({
                url: requestString,
                type: 'DELETE',
                dataType: 'json', // added data type
                success: function(res) {
                    //console.log(res);
                    alert("204 No Content");
                    window.location = "movies.html";
                }
            });
    	}

    </script>

</body>
</html>