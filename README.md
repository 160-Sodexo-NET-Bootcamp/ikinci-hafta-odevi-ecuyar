# Trash Management System API ⚡

This project is second homework that made for Sodexo .NET Bootcamp. It has not `bonus part` that make grouppings.

Main goal is to create an API that can perform some operations on the DB. 

Program is created with `Entity Framework` + `Unit of Work` with `Repository Pattern`.


## How to use 🔑

### Container Controller 🗝️

- Get all containers
  - Send a `GET` request to `https://localhost:44384/api/Containers` 

- Create a container
  - Send a `POST` request to `https://localhost:44384/api/Containers` with a JSON on the body 
  
  ```
  {
  "containerName": "string",
  "latitude": 0,
  "longitude": 0,
  "vehicleId": 0
  }
  ```
  
- Update a container
  - Send a `PUT` request to `https://localhost:44384/api/Containers` with a JSON on the body. You can't update `container id` or `vehicle id`. 
  
  ```
  {
  "containerName": "string",
  "latitude": 0,
  "longitude": 0
  }
  ```
  
 - Delete a container
   - Send a `DELETE` request to `https://localhost:44384/api/Containers?id=[id]`. Give a `container id` as query parameter.

- Get containers of a vehicle
  - Send a `GET` request to `https://localhost:44384/api/Containers/byVehicle?id=[id]`. Give a `vehicle id` as query parameter.

### Vehicle Controller 🗝️

- Get all vehicles
  - Send a `GET` request to `https://localhost:44384/api/Vehicles` 

- Create a vehicle
  - Send a `POST` request to `https://localhost:44384/api/Vehicles` with a JSON on the body 
  
  ```
  {
  "vehicleName": "string",
  "vehiclePlate": "string"
  }
  ```
  
- Update a vehicle
  - Send a `PUT` request to `https://localhost:44384/api/Vehicles` with a JSON on the body. You can't update `vehicle id`. Vehicle plate MUST be 7 letters.
  
  ```
  {
  "id": 0,
  "vehicleName": "string",
  "vehiclePlate": "string"
  }
  ```
  
 - Delete a vehicle
   - Send a `DELETE` request to `https://localhost:44384/api/Vehicles?id=[id]`. Give a `vehicle id` as query parameter. If vehicle has containers, related containers will be without vehicle info.

- Get group of containers which belong to a vehicle
  - Send a `GET` request to `https://localhost:44384/api/Vehicles/containerGroup?vehicleId=5&groupCount=5`. Give a `vehicle id` and `group count` as query parameters. Program will sent a group of containers based on your wish.

