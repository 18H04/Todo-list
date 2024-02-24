# Todo List Application

This is a Todo List Application project, built with ASP.NET Core for the backend and React for the frontend. This application allows users to manage tasks they need to complete in a todo list.

## Requirements

- [ASP.NET Core](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Modern web browser

## Installation

1. **Clone the project from the GitHub repository:**

    - Backend (ASP.NET Core):
    ```bash
    git clone https://github.com/18H04/Todo-list/tree/main/todo-server
    ```

    - Frontend (React):
    ```bash
    git clone https://github.com/18H04/Todo-list/tree/main/todo-website
    ```

2. **Install and Run Backend (ASP.NET Core):**

    - Open the solution in Visual Studio or your favorite code editor.
    - Configure the connection string for the SQL Server database in the appsettings.json file.
    - Open the Package Manager Console and run the following command to apply migrations and create the database:
    ```bash
    Update-Database
    ```
    - Run the backend application.

3. **Install and Run Frontend (React):**

    - Navigate to the frontend project directory:
    ```bash
    cd todo-list-frontend
    ```
    - Install the dependencies:
    ```bash
    npm install
    ```
    - Start the frontend application:
    ```bash
    npm start
    ```

## Author

- Phung Dang Hieu
- Email: hieudang18042003@gmail.com

## License

This project is licensed under the [MIT License](LICENSE).
