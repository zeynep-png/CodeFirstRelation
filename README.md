# Code First Approach with Entity Framework Core

This project demonstrates the implementation of the Code First approach using Entity Framework Core to create a database with relationships between tables. The focus is on establishing a one-to-many relationship between users and their posts.

## Database Overview

### Database Name
- **PatikaCodeFirstDb2**

### Tables
The database will contain the following tables:

1. **Users Table**
   - **Id**: `int`, primary key, auto-incrementing.
   - **Username**: `string`, the user's username.
   - **Email**: `string`, the user's email address.

2. **Posts Table**
   - **Id**: `int`, primary key, auto-incrementing.
   - **Title**: `string`, the title of the post.
   - **Content**: `string`, the content of the post.
   - **UserId**: `int`, the identifier of the user who authored the post.

## Relationships

The application establishes the following relationships between the tables:

- A **User** can have multiple **Posts**.
- Each **Post** is associated with a single **User**.

This relationship is defined as a one-to-many relationship:
- **One User** can have **many Posts**.
- **Each Post** belongs to **one User**.

## Context Class

### Class Name
- **PatikaSecondDbContext**

The context class is responsible for configuring the database connection and mapping the entities to the corresponding tables. It also includes the configuration for establishing relationships between the `User` and `Post` entities.

## Implementation Steps

1. **Install Required Packages**: Ensure that Entity Framework Core and the necessary database provider are installed.
  
2. **Define Entity Classes**: Create classes for `User` and `Post` that represent the database tables.

3. **Configure the DbContext**: Implement the `PatikaSecondDbContext` class to manage database operations and relationships.

4. **Create and Apply Migrations**: Use the Entity Framework Core tools to create and apply migrations that set up the database structure.

5. **Seed Initial Data**: Optionally, seed the database with initial data for testing purposes.

## Conclusion

This project provides a practical demonstration of using Entity Framework Core with the Code First approach to create a relational database. The established relationships between the `Users` and `Posts` tables enable the application to manage user-generated content effectively.
