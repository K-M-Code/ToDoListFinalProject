# Final Project 

This is The final project for the Windows Programming course spring 2024, the selected project from the given options is a Todo list

# Requirements

    - Docker
    - .NET SDK 8
    - Visual Studio IDE

# Steps to Run the project
    
    1. Clone the Repository
    2. Deploy the Database using docker compose 
        ```
        docker compose up -d
        ```
    3. Login to PGAdmin using localhost:8888 using the following credentials:
        - username: postgres@postgres.com
        - password: postgres
        - database: db
    4. Run the below SQL Command to add table courses to db called Database
       ```
       CREATE TABLE todos (
        id UUID PRIMARY KEY,
        title VARCHAR(255) NOT NULL,
        description TEXT NOT NULL,
        is_completed BOOLEAN NOT NULL,
        is_deleted BOOLEAN NOT NULL,
        is_important BOOLEAN NOT NULL
        );
       ```