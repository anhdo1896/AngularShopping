#  Skiing Shop App

## Overview

This e-commerce platform allows users to browse, sort, filter, and purchase products related to skiing. The user can order products and make payments using the Stripe payment gateway. 

## Technology Stack
- `Front-End`: Angular
- `Back-End`: ASP.NET Core
- `Database`: SQLite (relational DB)
- `Payment Gateway`: Stripe (for testing credit card transactions)
- `Caching`: `Redis` (for caching the product list)
- `Deployment`:
    - `Front-End`: Amazon S3
    - `Back-End`: Azure App Service
    - `Redis Server`: Amazon S2


## Available script

After clone this project, in the `client` project directory, you can run:

### `npm install`

Install the necessary dependences.

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:4200](http://localhost:4200) to view it in the browser.

The page will reload if you make edits.

### `npm run build`

Builds the app for production to the `build` folder (dist).\
It correctly bundles Angular in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

## Project Structure

## Frontend

The Angular front end will be divided into several feature modules for better organization and maintainability.

 ### Modules:
 - `Core Module:`
    - `Guards`: Protects routes (e.g., ensuring users are authenticated before accessing certain pages).
    - `Interceptors`:
        - `Error`: Catches and handles HTTP errors globally.
        - `JWT Token`: Attaches JWT tokens to outbound requests for secure endpoints.
        - `Loading`: Displays loading indicators when HTTP requests are in progress.
- `Shared Module`:
    - `Custom Text Input`: Implements `ControlValueAccessor` for handling form controls (used across the application).
    - `Pagination`: Provides pagination for the product list.
- `Account Module`
- `Basket Module`
- `Checkout Module`
- `Home Module`
- `Orders Module`
- `Shop Module`
- `Routing Module`

###  Additional Techniques:
- `Reactive Forms`: Used for managing complex forms such as registration and profile updates.

## Backend
The ASP.NET Core back end follows a SOLID structure for maintainability and scalability. The project is divided into three main solutions:

### 1. API
- `Controllers`: Handle incoming HTTP requests from the front end. Each controller manages a specific entity (e.g., ProductsController, OrdersController).
- `Extensions`: Provides reusable methods for common logic (e.g., pagination, sorting).
- `Helpers`: Utility classes to assist with common tasks like response formatting and validation.
- `Middlewares`: Custom middleware for handling server errors and returning user-friendly messages
### 2. Core
- `Entities`: Contains the domain models that represent the database tables (e.g., Product, Order, User).
- `Interfaces`: Defines the contracts that the services and repositories must follow, ensuring separation of concerns.
- `Specifications`: Implements a design pattern used to filter and query data dynamically based on different conditions (used in product filtering and sorting).
### 3.Infrastructure
- `Data`: Contains the DbContext for managing the database connection and migrations.
- `Repository`: Provides data access logic, retrieving entities from the database.
- `Unit of Work`: Ensures that multiple repositories can be used together while maintaining transaction integrity.

### Redis Caching for Product List
Redis is used as an in-memory data store to cache the product list. This reduces the load on the database by serving frequently requested products directly from cache. The product data is cached after it is retrieved from the database and updated when new products are added or existing ones are modified.


## Tools

- `IDE`: Visual Studio (for .NET Core development) and Visual Studio Code (for Angular development).
Testing:
- `Postman`: manual testing and writing scripts to automate testing of API endpoints.
- `Swagger`: Integrated API documentation and testing tool.

## Learn More

You access the demo [Skiing Shop App](http://anhdo-16092024-staging.s3-website-us-east-1.amazonaws.com/).

To learn API, check out the [Skiing Shop App API](https://shoppingrediscacheapi.azurewebsites.net/swagger).













