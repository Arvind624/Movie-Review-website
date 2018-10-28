var app = angular.module('movieModule', []);

app.controller('movieController', function($scope, $http){
	
	$scope.loginVisible = true;

	//Basic Authentication

	$scope.login = function(){

		$http.get('http://localhost:59826/api/movies/', {
			headers: {Authorization: 'Basic ' + btoa($scope.username + ':' + $scope.password)}
		})
		.then(function(response){
			console.log(response);
			if(response.status == 401)
			{

				alert('Invalid username or password');
			}
			else
			{
				$scope.loginVisible = false;

				if($scope.username == "user")
				{
					$scope.userLogin = true;
					$scope.adminLogin = false;
				}
				else
				{
					$scope.userLogin = false;
					$scope.adminLogin = true;
				}

				$scope.movieList = response.data;

				alert("Success");
			}
		});
		
	}
});

app.controller('categoryController', function($scope,$http){
	$http.get('http://localhost:59826/api/categories/')
	.then(function(response){
		console.log(response);
		$scope.categoryList = response.data;
	});
});