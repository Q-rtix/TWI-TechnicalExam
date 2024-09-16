# TreewInc API Documentation

## Overview

The TreewInc API provides endpoints for managing products and sales. It includes functionalities such as searching for products, retrieving product details, updating products, and creating sales.

## Endpoints

### ProductsController

- **Search Products**
  - **Endpoint:** `GET /api/products/search`
  - **Parameters:**
    - `name` (optional): The name of the product.
    - `description` (optional): The description of the product.
    - `minPrice` (optional): The minimum price of the product.
    - `maxPrice` (optional): The maximum price of the product.
    - `minStock` (optional): The minimum stock of the product.
    - `maxStock` (optional): The maximum stock of the product.
  - **Response:** A list of products matching the search criteria.

- **Get Product by ID**
  - **Endpoint:** `GET /api/products/{id}`
  - **Parameters:**
    - `id`: The unique identifier of the product.
  - **Response:** The details of the product.

- **Get Products**
  - **Endpoint:** `GET /api/products`
  - **Parameters:**
    - `pageNumber` (optional): The page number for pagination.
    - `pageSize` (optional): The page size for pagination.
  - **Response:** A paginated list of products.

- **Update Product**
  - **Endpoint:** `PUT /api/products`
  - **Parameters:**
    - `command`: The command containing updated product details.
  - **Response:** The updated product details.

- **Remove Product**
  - **Endpoint:** `DELETE /api/products/{productId}`
  - **Parameters:**
    - `productId`: The unique identifier of the product to be removed.
  - **Response:** The result of the remove operation.

### SalesController

- **Create Sale**
  - **Endpoint:** `POST /api/sales`
  - **Parameters:**
    - `command`: The command containing sale details.
  - **Response:** The created sale details.

## Running the Application

### Prerequisites

- **.NET 8 SDK**: Ensure you have the .NET 8 SDK installed. If not, you can install it using the following command:

```sh
winget install Microsoft.DotNet.SDK.8
```

### Profiles

The application can be run using different profiles. Profiles ending with `-test` use an in-memory database, while other profiles use SQL Server.

- **HTTP Development Profile**
  - **Command:** `dotnet run --launch-profile http`
  - **Database:** SQL Server
  - **ASPNETCORE_ENVIRONMENT:** `Development`

- **HTTPS Development Profile**
  - **Command:** `dotnet run --launch-profile https`
  - **Database:** SQL Server
  - **ASPNETCORE_ENVIRONMENT:** `Development`

- **HTTP Test Profile**
  - **Command:** `dotnet run --launch-profile http-test`
  - **Database:** In-memory
  - **ASPNETCORE_ENVIRONMENT:** `Testing`

- **HTTPS Test Profile**
  - **Command:** `dotnet run --launch-profile https-test`
  - **Database:** In-memory
  - **ASPNETCORE_ENVIRONMENT:** `Testing`

Make sure to configure the connection strings and other settings in the `appsettings.{ASPNETCORE_ENVIRONMENT}.json` files accordingly.

## Conclusion

This documentation provides an overview of the TreewInc API endpoints and instructions on how to run the application using different profiles. For more detailed information, refer to the source code and configuration files.