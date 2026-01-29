# Airport Management System 

A specialized backend solution for aviation management, built with **C#** and **ASP.NET Core**. This project demonstrates advanced software engineering principles, including **Clean Architecture**, **Generic Repositories**, and heavy use of **LINQ/Lambda expressions** for complex data processing.

## Architecture & Patterns
The project is structured following Domain-Driven Design (DDD) principles:
- **ApplicationCore:** Contains the Domain entities (`Flight`, `Plane`, `Passenger`, `Staff`, `Traveller`) and Business Logic.
- **Services Layer:** Implements specialized logic using the **Generic Service Pattern**.
- **Data Access:** Utilizes **Unit of Work** and **Generic Repository** patterns for clean database interactions.
- **Delegates & Lambdas:** Features advanced C# usage like `Action<>` and `Func<>` delegates for dynamic flight detail processing.

## Core Functionality
- **Advanced Flight Searching:** Filter flights by destination, date, or duration using optimized LINQ queries.
- **Passenger Analytics:** - Track "Senior Travellers" and group passengers by flight frequency.
  - Calculate passenger counts within specific date ranges.
- **Resource Management:** - Automated plane availability checks based on ticket capacity.
  - Plane maintenance logic (e.g., automated deletion/flagging of aircraft older than 10 years).
- **Staff Tracking:** Specialized logic to extract staff members and travellers associated with specific flights or aircraft.

## Code Highlights (LINQ & Logic)
The system includes complex data operations such as:
- **Grouping:** `GroupBy` logic for destination-based flight reporting.
- **Projection:** Use of `SelectMany` to flatten relationships between Planes, Flights, and Tickets.
- **Aggregation:** Real-time calculation of flight duration averages.

## Tech Stack
- **Language:** C# 
- **Framework:** .NET 6.0 / 7.0
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Design Patterns:** Unit of Work, Generic Repository, Dependency Injection, Service Pattern.

## Project Structure
* `AM.ApplicationCore.Domain`: Core entities (Flight.cs, Plane.cs, etc.)
* `AM.ApplicationCore.Interfaces`: Abstractions for Services and Repositories.
* `AM.ApplicationCore.Services`: Business logic implementation (`ServiceFlight.cs`, `ServicePlane.cs`).

