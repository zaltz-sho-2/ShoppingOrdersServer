"# ShoppingOrders" 

This project consists of two main parts: the Client-side (front-end) and the Server-side (back-end). Below are the instructions to set up and run the project, including how to connect to the database and run the migrations.

## Prerequisites

Before running the project, make sure you have the following tools installed:

- **.NET 8 SDK**: [Download and install .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server**: Ensure that you have access to a running SQL Server instance, either locally or remotely.
- **Git**: Ensure that Git is installed on your machine for version control.

---

## Server-Side (Back-End) Setup

### 1. Clone the Server Repository
### 2. Database Setup
You need to configure the database connection string for the back-end project.

# a. Configure the Database Connection
Open the appsettings.json file located in the ShoppingOrdersServer directory.

Find the "ConnectionStrings" section and set the connection string to your SQL Server instance:
"ConnectionStrings": {
"DefaultConnection": "Server=your-server-name;Database=ShoppingOrdersDb;User Id=your-username;Password=your-password;"
}

# b. Create the Database and Apply Migrations
Open a terminal and navigate to the ShoppingOrdersServer directory.

Run the following commands to create the database and apply the migrations:
* "dotnet ef database update"


## Client-Side (Front-End) Setup

### 1. Clone the Client Repository

### 2. Install Dependencies
Run the following command to install the required dependencies for the front-end project:
* npm install
### 3. Run the Client
run the client-side application:
* npm start
