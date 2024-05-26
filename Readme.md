# Advanced E-commerce Platform

## Overview
TechMart is an advanced e-commerce platform built with ASP.NET Core MVC 7.0. It is designed to provide a comprehensive solution for online retail businesses, featuring a robust product management system, user authentication, and a seamless shopping experience.

## Technologies Used
- **ASP.NET Core MVC 7.0**: For building a scalable and maintainable web application.
- **Entity Framework Core**: For database management and operations.
- **SQL Server**: As the database server.
- **Bootstrap**: For responsive and modern UI design.
- **JavaScript & jQuery**: For interactive and dynamic client-side operations.

## Features
- Product Management
- User Authentication and Authorization
- Shopping Cart and Checkout
- Order Management
- Responsive Design

## Setup and Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/enesscigdem/StoreApp-Ecommerce---Asp.Net-Core-Mvc-7.0.git
   cd StoreApp-Ecommerce---Asp.Net-Core-Mvc-7.0
   ```

2. Update the connection string in `appsettings.json` to point to your SQL Server instance.

3. Run the following commands to update the database and run the application:
   ```bash
   dotnet ef database update
   dotnet run
   ```

4. Open a browser and navigate to `https://localhost:5001` to see the application in action.

## Usage
- Register as a new user or log in with an existing account.
- Browse products and add them to your cart.
- Proceed to checkout to complete the purchase.

## Contribution Guidelines
- Fork the repository and create your branch from `main`.
- Submit pull requests for any enhancements or bug fixes.

## License
This project is licensed under the MIT License.
