# Sensor Data API

This is a RESTful API developed using ASP.NET Core. It is designed to handle data related to sensor measurements and their locations.

## Features

- Create, read, update and delete (CRUD) operations for Locations, Sensors and Measurements.
- Handles relationships between Locations, Sensors and their Measurements.
- Provides search functionality for locations.
- Provides pagination for the retrieval of locations.
- Implements input validation and error handling.

## Endpoints

The API provides the following endpoints:

- `GET /Locations`: Retrieve all locations. Supports pagination with query parameters `pageNumber` and `pageSize`.
- `GET /Locations/{id}`: Retrieve a specific location by ID.
- `POST /Locations`: Create a new location.
- `PUT /Locations/{id}`: Update an existing location.
- `DELETE /Locations/{id}`: Delete a specific location.

- `GET /Sensors`: Retrieve all sensors.
- `GET /Sensors/{id}`: Retrieve a specific sensor by ID.
- `POST /Sensors`: Create a new sensor.
- `PUT /Sensors/{id}`: Update an existing sensor.
- `DELETE /Sensors/{id}`: Delete a specific sensor.

- `GET /Measurements`: Retrieve all measurements.
- `GET /Measurements/{id}`: Retrieve a specific measurement by ID.
- `POST /Measurements`: Create a new measurement.
- `PUT /Measurements/{id}`: Update an existing measurement.
- `DELETE /Measurements/{id}`: Delete a specific measurement.

## Setup and Running

1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet restore`.
4. Adjust the database connection string in `appsettings.json`.
5. Run `dotnet ef database update` to apply migrations to your database.
6. Run `dotnet run` to start the API.

## Future Plans

- Add more search capabilities.
- Implement more advanced error handling.

