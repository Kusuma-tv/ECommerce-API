# E-Commerce Web API
A backend e-commerce application built using ASP.NET Core Web API, Entity Framework Core and SQL Server.

## Project Overview
This project is a backend REST API for an e-commerce application.
The application provides APIs for user authentication, category management, product management, shopping cart, order management, and wishlist functionality.
The project follows a layered architecture with separate responsibilities for Web API, Business Logic, Repository, Data Access, and Entity layers.

## Features
- User Registration and Login
- JWT Authentication and Authorization
- Category Management
- Product Management
- Shopping Cart
- Order Management
- Wishlist Management
- Entity Framework Core
- SQL Server Database
- Swagger API Documentation
- Repository Pattern
- Business Access Layer
  
## Technologies
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- Git
- GitHub

## Architecture
The project follows a layered architecture to separate API handling, business logic, database operations, and data access.
Client / Postman
       ↓
Controller
       ↓
BAL
       ↓
Repository Interface
       ↓
Repository
       ↓
AppDbContext
       ↓
SQL Server
