# Simple Movie Management App
Demonstrates a simple movie management app

## Getting Started
Each of the following sections will walk you through the steps to get the app up and running.

### Prerequisites
You will need the following installed on your machine:
* [Node.js](https://nodejs.org/en/)
* [PostgreSQL](https://www.postgresql.org/)
* [.NET 7](https://www.microsoft.com/net/download)
* [Yarn](https://yarnpkg.com/en/docs/install)

### Database
1. Create a database named `movies`
2. Set the `DATABASE_URL` environment variable to the connection string for the database in the following format: `Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase`. Use user-secrets or appsettings.json to set this variable in the `backend` project.

### Installing
1. Clone the repository
2. Run `yarn install` in the `frontend` directory
3. Run `dotnet run` in the `backend` directory
4. Run `yarn start` in the `frontend` directory
5. Navigate to `http://localhost:3000/` in your browser
6. Enjoy!


