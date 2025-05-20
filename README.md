# Event Managment System

## Overview
A full-stack event booking system built with ASP.NET Core 8.0, implementing a 3-tier architecture pattern.

### Layers
1. **Presentation Layer** (Event Management System)
   - MVC-based web application
   - User interface and controllers
   - View models and client-side logic

2. **Business Logic Layer** (BLL)
   - Business services and operations
   - DTOs for data transfer
   - Email templates and notifications

3. **Data Access Layer** (DAL)
   - Entity Framework Core implementation
   - Database entities and configurations
   - Repository pattern implementation

## Prerequisites
- .NET 8.0 SDK
- SQL Server (Express or Developer Edition)
- Visual Studio 2022 or Visual Studio Code
- Git

## Required Software
1. **.NET 8.0 SDK**
   - Download from: https://dotnet.microsoft.com/download/dotnet/8.0
   - Verify installation: `dotnet --version`

2. **SQL Server**
   - Download SQL Server Express: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
   - Download SQL Server Management Studio (SSMS): https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms

3. **IDE**
   - Visual Studio 2022: https://visualstudio.microsoft.com/downloads/
   - Visual Studio Code: https://code.visualstudio.com/


## Project Structure

### Event Management System/ **Presentation Layer (ASP.NET Core MVC)**

- Controllers/ *MVC controllers handling HTTP requests (e.g., EventController.cs, BookingController.cs)*
- Models/ *View models for UI data binding and validation (e.g., EventViewModel.cs, BookingViewModel.cs)*
- Views/ *Razor views for rendering the user interface, including shared layouts (_Layout.cshtml)*
- wwwroot/ *Static files like CSS, JavaScript, and images (includes Bootstrap and jQuery libraries)*
- Areas/ *Organized feature modules for Admin and User functionalities*
- appsettings.json *Configuration file for connection strings and application settings*
- Program.cs *Application entry point for service configuration and middleware setup*

### BLL/ **Business Logic Layer**

- Services/ *Business logic for events, bookings, and emails (e.g., EventService.cs, BookingService.cs)*
- DTOs/ *Data Transfer Objects for communication between layers (e.g., EventDto.cs, BookingDto.cs)*
- EmailTemplates/ *HTML and text templates for email notifications (e.g., BookingConfirmation.html)*
- Interfaces/ *Service interfaces for dependency injection (e.g., IEventService.cs)*

### DAL/ **Data Access Layer**

- Entities/ *Database entities representing tables (e.g., Event.cs, Booking.cs, User.cs)*
- Repositories/ *Repository pattern for data access (e.g., EventRepository.cs, BookingRepository.cs)*
- Data/ *Entity Framework Core database context (AppDbContext.cs) and configurations*
- Migrations/ *Entity Framework Core migrations for database schema updates*

## Dependencies

### Main Project (Event Management System)
- ASP.NET Core 8.0
- Entity Framework Core
- Identity Framework
- Bootstrap
- jQuery

### Business Layer (BLL)
- MailKit (4.12.0)
- MimeKit (4.12.0)
- Microsoft.AspNetCore.Http.Features (5.0.17)

### Data Layer (DAL)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.12)
- Microsoft.EntityFrameworkCore.SqlServer (8.0.12)

## Installation Steps

1. **Clone the Repository**
   ```bash
   git clone [repository-url]
   cd Areeb.Event-Booking-System
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure Database**
   - Open `appsettings.json` in the main project
   - Update the connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=EventBookingDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. **Apply Database Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

   ### Using Package Manager Console
1. Open Visual Studio
2. Go to Tools > NuGet Package Manager > Package Manager Console
3. Make sure the Default Project is set to "Areeb.DAL"
4. Run the following commands:
```powershell
# Add a new migration
Add-Migration MigrationName

# Update database
Update-Database
```

Note: When using Package Manager Console, ensure you have the following NuGet packages installed in your DAL project:
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

  ## Email Sending Configuration

The system uses MailKit for sending emails. Here's how to configure email settings:

1. **Update appsettings.json**
```json
{
  "EmailSettings": {
    "Mail": "your-email@gmail.com",
    "DisplayName": "Event Managment System",
    "Password": "your-app-password",
    "Host": "smtp.gmail.com",
    "Port": 587
  }
}
```

2. **Email Templates**
The system includes the following email templates in `Areeb.BLL/EmailTemplates/`:
- Booking Confirmation
- Event Reminder
- Password Reset
- Welcome Email

3. **Gmail Configuration**
If using Gmail:
- Enable 2-Step Verification in your Google Account
- Generate an App Password:
  1. Go to Google Account Settings
  2. Security
  3. 2-Step Verification
  4. App Passwords
  5. Generate a new app password for "Mail"


## Features
- User Authentication and Authorization
- Event Management
- Booking System
- Email Notifications
- Admin Dashboard
- User Profile Management
- Role-based Access Control
- Event Categories
- Booking History
- Email Notifications

## Development

### Running the Project
1. Open the solution in Visual Studio
2. Set the main project (Event Booking System) as the startup project
3. Press F5 or click the Run button

### Database Migrations
```bash
# Add a new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

## Troubleshooting

### Common Issues

1. **Database Connection Issues**
   - Ensure SQL Server is running
   - Verify connection string in appsettings.json
   - Check SQL Server authentication mode

2. **Build Errors**
   - Clean solution: `dotnet clean`
   - Delete bin and obj folders
   - Restore packages: `dotnet restore`
   - Rebuild solution: `dotnet build`

3. **Runtime Errors**
   - Check application logs
   - Verify all required services are running


