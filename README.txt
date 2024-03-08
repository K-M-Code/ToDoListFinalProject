After docker compose is put up using "docker compose up -d" add the courses table to MariaDB by logging into adminer at localhost:8080 with username Root and password RootPassword.

Run the below SQL Command to add table courses to db called Database

CREATE TABLE Tasks (
    TaskID INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    IsCompleted BOOLEAN NOT NULL DEFAULT 0
);

CREATE TABLE Tags (
    TagID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE TaskTags (
    TaskID INT,
    TagID INT,
    PRIMARY KEY (TaskID, TagID),
    FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    FOREIGN KEY (TagID) REFERENCES Tags(TagID)
);
