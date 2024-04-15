After docker compose is put up using "docker compose up -d" add the courses table to MariaDB by logging into adminer at localhost:8080 with the credentials username: Username, password: password.
# Final Project 

This is The final project for the Windows Programming course spring 2024, the selected project from the given options is a Todo list

##Requirements

    - Docker
    - .NET SDK 8
    - Visual Studio IDE
## Steps to Run the project
   1. Clone the Repository
   2. Deploy the Database using docker compose 
    ```
    docker compose up -d
    ```
   3. Login to Adminer using localhost:8080 using the following credentials:
        - username: Username
        - password: password
        - database: Database
   4. Run the below SQL Command to add table courses to db called Database
   ```
    CREATE TABLE Tasks (
        TaskId INT AUTO_INCREMENT PRIMARY KEY,
        Title VARCHAR(255) NOT NULL,
        IsCompleted BOOLEAN NOT NULL DEFAULT 0
    );

    CREATE TABLE Tags (
        TagId INT AUTO_INCREMENT PRIMARY KEY,
        Name VARCHAR(50) NOT NULL
    );

    CREATE TABLE TaskTags (
        TaskId INT,
        TagId INT,
        FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
        FOREIGN KEY (TagId) REFERENCES Tags(TagId),
        PRIMARY KEY (TaskId, TagId)
    );


    ALTER TABLE Tasks AUTO_INCREMENT = 0;
    ```