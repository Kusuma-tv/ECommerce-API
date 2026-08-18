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

## Database Relationships
The main entities and their relationships are:
User
 ├── Cart
 │     └── CartItem
 │           └── Product
 │
 ├── Order
 │     └── OrderItem
 │           └── Product
 │
 └── Wishlist
       └── WishlistItem
             └── Product

Category
   └── Product

## API Modules
### Authentication
| Method | Endpoint | Description |
|---|---|---|
| POST | /api/User/register` | Register a new user |
| POST | /api/User/login` | Login and receive JWT token |

### Category

| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Category` | Create category |
| GET | /api/Category` | Get all categories |
| GET | /api/Category/{categoryId}` | Get category by ID |
| PUT | /api/Category/{categoryId}` | Update category |
| DELETE | /api/Category/{categoryId}` | Delete category |

### Product

| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Product` | Create product |
| GET | /api/Product` | Get all products |
| GET | /api/Product/{productId}` | Get product by ID |
| PUT | /api/Product/{productId}` | Update product |
| DELETE | /api/Product/{productId}` | Delete product |

### Cart
| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Cart` | Add product to cart |
| GET | /api/Cart` | Get current user's cart |
| PUT | /api/Cart/{cartItemId}` | Update cart item quantity |
| DELETE | /api/Cart/{cartItemId}` | Remove cart item |

### Order
| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Order` | Create order from cart |
| GET | /api/Order` | Get current user's orders |
| GET | /api/Order/{orderId}` | Get order by ID |

### Wishlist
| Method | Endpoint | Description |
|---|---|---|
| POST | /api/Wishlist` | Add product to wishlist |
| GET | /api/Wishlist` | Get current user's wishlist |
| DELETE | /api/Wishlist/{wishlistItemId}` | Remove product from wishlist |

## Authentication
The API uses JWT Bearer Authentication.
The authentication flow is:
Register
   ↓
Login
   ↓
JWT Token
   ↓
Authorization: Bearer <token>
   ↓
Protected APIs

## Swagger
Swagger is enabled for interactive API documentation and API testing.
After running the application, Swagger can be accessed at:
https://localhost:<port>/swagger

## How to Run
### Prerequisites
- .NET SDK
- SQL Server
- Visual Studio
- SQL Server Management Studio (optional)
### Steps
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the SQL Server connection string.
4. Configure JWT settings using User Secrets.
5. Apply Entity Framework Core migrations.
6. Build and run the application.
7. Open Swagger to explore the APIs.
