# AirlineAPI - Flight Booking System

AirlineAPI is a web API developed for flight reservations and ticketing operations. This API provides basic functionalities such as managing flights, purchasing tickets, registering passengers, and checking in for flights. The project is built using the .NET Core framework and stores flight and ticket data in a PostgreSQL database. The API allows users to purchase tickets for flights and check in for those flights.

## Features

- **Flight Management**: Admins can create, edit, and view flight information.
- **Ticket Purchase**: Passengers can purchase tickets for available flights.
- **Check-In**: Passengers can check in for their flights after purchasing tickets.
- **Flight Information Viewing**: Information about available flights and their capacity can be retrieved.

## API Usage

The API enables users to easily perform functions such as purchasing tickets and managing passenger operations. Admins can create flights and make tickets available for sale. Passengers can purchase tickets for flights and perform check-ins. The API is designed with a RESTful architecture and supports all basic flight management operations.

## Technologies

- **.NET Core** framework for developing the web API.
- **PostgreSQL** database for storing flight and ticket data.
- **Entity Framework Core** to manage the API and database operations.
- **Swagger UI** integration for visualizing and testing the API.

## Database Configuration

Flight and ticket data are stored in a PostgreSQL database. The application connects to the database and manages the relationships between flights and tickets. The database connection string is defined in the application’s configuration file, and the database schema is updated through migration processes managed by Entity Framework Core.
