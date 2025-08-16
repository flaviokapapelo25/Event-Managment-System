# Event Management System 🎉

Welcome to the **Event Management System** repository! This project is designed to simplify the process of managing and booking events. Built with ASP.NET Core 8.0, this full-stack web application leverages a robust 3-tier architecture to deliver a seamless user experience.

[![Download Releases](https://img.shields.io/badge/Download%20Releases-blue.svg)](https://github.com/flaviokapapelo25/Event-Managment-System/releases)

## Table of Contents

1. [Overview](#overview)
2. [Key Features](#key-features)
3. [Architecture](#architecture)
4. [Technologies Used](#technologies-used)
5. [Getting Started](#getting-started)
6. [Usage](#usage)
7. [Contributing](#contributing)
8. [License](#license)
9. [Contact](#contact)

## Overview

The **Event Management System** allows users to easily create, manage, and book events. Whether you're an organizer looking to set up an event or a user wanting to book a spot, this application provides the tools you need. The use of ASP.NET Core ensures high performance and scalability, while the 3-tier architecture keeps the code organized and maintainable.

## Key Features

- **User Authentication**: Secure user login and registration using ASP.NET Identity.
- **Event Management**: Create, update, and delete events with ease.
- **Admin Dashboard**: Monitor events and manage users from a dedicated admin panel.
- **Email Notifications**: Stay informed with email updates using MailKit.
- **Role-Based Access Control**: Different user roles ensure proper access levels.
- **Responsive Design**: Enjoy a user-friendly interface on any device.

## Architecture

The system follows a **3-tier architecture**:

1. **Presentation Layer**: The user interface built with ASP.NET MVC and Razor Pages.
2. **Business Logic Layer**: Contains the core application logic and handles data processing.
3. **Data Access Layer**: Interacts with the database using Entity Framework Core and LINQ.

This structure enhances maintainability and scalability, allowing for easier updates and modifications.

## Technologies Used

- **ASP.NET Core 8.0**: The framework for building the web application.
- **Entity Framework Core**: An ORM for database operations.
- **MailKit**: For sending email notifications.
- **SQL Server**: The database management system.
- **Dependency Injection**: To manage dependencies throughout the application.
- **Repository Pattern**: For abstracting data access logic.
- **LINQ**: For querying data in a more readable format.
- **ASP.NET Identity**: For user authentication and authorization.
- **Role-Based Access Control**: To manage user permissions effectively.

## Getting Started

To set up the **Event Management System** locally, follow these steps:

### Prerequisites

- .NET SDK 8.0 or higher
- SQL Server
- A code editor like Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/flaviokapapelo25/Event-Managment-System.git
   ```

2. Navigate to the project directory:

   ```bash
   cd Event-Managment-System
   ```

3. Restore the NuGet packages:

   ```bash
   dotnet restore
   ```

4. Set up the database:

   - Open SQL Server Management Studio.
   - Create a new database named `EventManagementDB`.
   - Update the connection string in `appsettings.json` to point to your database.

5. Run the migrations to create the necessary tables:

   ```bash
   dotnet ef database update
   ```

6. Start the application:

   ```bash
   dotnet run
   ```

### Accessing the Application

Once the application is running, open your web browser and navigate to `http://localhost:5000`. You will see the home page of the Event Management System.

## Usage

### User Registration and Login

1. Click on the **Register** link to create a new account.
2. Fill in the required details and submit the form.
3. After registration, log in using your credentials.

### Managing Events

- **Create an Event**: Navigate to the event management section and fill in the event details.
- **Edit an Event**: Click on the event you wish to modify and make the necessary changes.
- **Delete an Event**: Select the event and choose the delete option.

### Admin Dashboard

As an admin, you can:

- View all registered users.
- Monitor events and manage user roles.
- Send email notifications to users.

## Contributing

We welcome contributions! If you would like to help improve the Event Management System, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your branch to your forked repository.
5. Open a pull request detailing your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, feel free to reach out:

- **Email**: your-email@example.com
- **GitHub**: [flaviokapapelo25](https://github.com/flaviokapapelo25)

Explore the **Releases** section for the latest updates and versions of the Event Management System. [Download Releases](https://github.com/flaviokapapelo25/Event-Managment-System/releases) to get started today!