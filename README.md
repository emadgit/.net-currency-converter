# .NET Razor Project with MySQL

This project is a .NET Razor application that uses a MySQL database. It includes a simplified version of the Northwind database.

## Demo Video

Here is a demo of the application:
<video src="[URL](https://github.com/emadgit/blog/raw/main/midalia-blog/public/assets/meta5-demo.mp4)"></video>


## Prerequisites

- .NET SDK
- Docker
- MySQL

## Setup

1. Clone the repository.

2. Navigate to the project directory.

3. Run the MySQL Docker container:

    ```bash
    docker run --name=mysql1 -p 3306:3306 -e MYSQL_ROOT_PASSWORD=YOUR_PASSWORD -e MYSQL_DATABASE=mydatabase -d mysql:latest
    ```

    This will start a new MySQL server in a Docker container. Make sure you replace `YOUR_PASSWORD`

4. Connect to the MySQL server:

    ```bash
    docker exec -it mysql1 mysql -uroot -p
    ```

    When prompted, enter the root password ( `YOUR_PASSWORD` ) that you set when you started the MySQL server.

5. Create the Northwind database:

    ```sql
    CREATE DATABASE Northwind;
    USE Northwind;

    CREATE TABLE Orders (
        OrderID int NOT NULL,
        ShipCountry varchar(15),
        Freight decimal(10,4),
        PRIMARY KEY (OrderID)
    );

    INSERT INTO Orders (OrderID, ShipCountry, Freight) VALUES
    (10248, 'Germany', 32.38),
    (10249, 'Mexico', 11.61),
    (10250, 'Mexico', 65.83);
    ```

    For stored procedure: 

    ```
    DELIMITER //
    CREATE PROCEDURE GetAverageFreight(IN shipCountry VARCHAR(15))
    BEGIN
    SELECT AVG(Freight) FROM Orders WHERE ShipCountry = shipCountry;
    END //
    DELIMITER ;
    ```

    This script creates a simplified version of the Northwind database with only the `Orders` table and a few sample records.

6. Update the connection string in `appsettings.json` to point to your MySQL server. Make sure to replace `<your_password>` with your actual password:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;Database=northwind;User=root;Password=<your_password>;"
    }
    ```

## Running the Application

To run the application, use the `dotnet watch` command:

```bash
dotnet watch
```

## Application Details
The application displays the average freight cost for a selected country in a selected currency. The freight cost is fetched from the database and converted to the selected currency when the page loads and whenever the selected country or currency changes.

