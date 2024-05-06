# Leave Management API Solution:
This project is a .NET Core API solution for Leave Management, built with a clean architecture approach using API, Core, and Infrastructure layers. The solution utilizes various technologies and best practices including Swagger for API documentation, AutoMapper for object mapping, EF Core for database access, CORS for API security, Async/Await for asynchronous programming, separation of concerns for better code organization, and migration with EF Core for database schema management. The latest .NET 7 version is used to leverage the newest features and improvements.

### Purpose and Architecture:
The purpose of adopting a clean architecture for this Leave Management API is to ensure modularity, scalability, and ease of extension for future needs. By adhering to the principles of clean architecture, the project maintains a clear separation of concerns, making it easier to understand, maintain, and extend the codebase.

### The architecture follows these main layers:

- ``API Layer``: Exposes RESTful endpoints for interacting with the Leave Management system.
- ``Core Layer``: Contains the business logic, domain entities, DTOs, interfaces, and services.
- ``Infrastructure Layer``: Handles data access, including database repositories, EF Core configurations, and migrations.

### Technologies Used:
- ``Swagger``: Integrated for API documentation, providing a user-friendly interface to explore and test endpoints.
- ``AutoMapper``: Used for mapping between domain entities and DTOs, reducing manual mapping efforts.
- ``EF Core``: Employs Entity Framework Core for database interactions, including migrations for database schema changes.
- ``CORS``: Configured for API security, allowing controlled access to API resources from different origins.
- ``Async/Await``: Utilized extensively for asynchronous programming, enhancing performance by leveraging non-blocking operations.
- ``Exception Handling``: (in progress) Implements robust exception handling strategies to ensure graceful error handling and application stability.

## Getting Started
To get started with the API, follow these steps:

- Clone this repository to your local machine:
`git clone https://github.com/msh-10/LeaveManagement.BE.git`

- Navigate to the API project directory:
``cd LeaveManagement.BE/LeaveManagement.API``

- Configure the Database Connection:
Open ``appsettings.json`` and update the connection string in the ``DefaultConnection`` section with your SQL Server database connection details.

- Run Migrations:
Open Package Manager Console and run the following commands to apply migrations and create the database:
``Update-Database``

- Start the API:
Build and run the API project using Visual Studio or the command line:
``dotnet run``

- Access Swagger API Documentation:
Once the API is running, navigate to ``https://localhost:7026/swagger`` in your web browser to view and test the API endpoints using Swagger UI.

### CORS Configuration

The Leave Management API is configured to allow Cross-Origin Resource Sharing (CORS) for security purposes. CORS allows controlled access to API resources from different origins. In this project, CORS is configured to only allow requests from ``http://localhost:4200``, which is the default port for Angular applications during development.

#### To modify CORS settings:

- 1. Open the `appsettings.json` file in the API project.
- 2. Locate the CORS policy configuration section.
- 3. Update the allowed origins to include http://localhost:4200 or your specific frontend application URL.

#### Example CORS configuration in `appsettings.json`:

``json
"AllowedOrigins": [
    "http://localhost:4200"
]``
By restricting CORS to specific origins, the API ensures that only trusted frontend applications can make requests, enhancing security and preventing unauthorized access.

### To get started with the Leave Management API, follow these steps:

- Clone the repository to your local machine.
- Install the necessary dependencies using NuGet Package Manager.
- Update the connection string in the appsettings.json file to point to your SQL Server database.
- Run the EF Core migration commands (dotnet ef migrations add InitialMigration, dotnet ef database update) to apply database migrations and create the database schema.
- Build and run the API project to start the application.
- Access the Swagger documentation at [https://localhost:7026/]/swagger to view and test the API endpoints.

### LeaveManagement API Endpoints:
- GET ``/api/v1/leaveapplications``: Retrieves all leave applications.
- GET ``/api/v1/leaveapplications/{id}``: Retrieves a leave application by ID.
- POST ``/api/v1/leaveapplications``: Creates a new leave application.
- PUT ``/api/v1/leaveapplications/{id}``: Updates a leave application by ID.
- DELETE ``/api/v1/leaveapplications/{id}``: Deletes a leave application by ID.
For detailed request and response formats, refer to the Swagger documentation.

### Users API Endpoints:
- GET ``/api/v1/users`` - Get all users
- GET ``/api/v1/users/{id}`` - Get user by ID
- POST ``/api/v1/users`` - Add a new user
- PUT ``/api/v1/users/{id}`` - Update user by ID
- DELETE ``/api/v1/users/{id}`` - Delete user by ID

### Contributing:
Contributions to the Leave Management API solution are welcome! Feel free to fork the repository, make changes, and submit pull requests for review.

### License
This project is licensed under the MIT License, which allows for both personal and commercial use with proper attribution.
