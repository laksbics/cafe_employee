# Cafe Employee

## Used Technologies.
- `Visual Studio 2022`
- `SqlLite`
- `ReactJs`
- `Docker`

## How to run the program in Visual Studio 2022
Open the solution in Visual Studio 2022
Run the following command
devenv CafeEmployee.sln  
devenv /rebuild CafeEmployee.sln

The ReatJs application will run on the port 5173 (https://localhost:5173/)

The Web API will run on port 7197 (https://localhost:7197/swagger/index.html)


The web api can be tested with the swagger URL https://localhost:7197/swagger/index.html 


## How to run the program in Docker
- `Run the docker file which will build and publish the docker image to the Docker desktop`
- `After that start the docker image`
- `once it is started ensure the same port is used in React Application`
- `build and run the react application which will consume the Api deployed in Docker`

