# GitHub Stat Analyzer

## Description
GitHub Stat Analyzer is a web application built with ASP.NET Core that connects to the GitHub API to gather statistics from the `lodash/lodash` repository. It provides an endpoint to retrieve the frequency of each letter in JavaScript/TypeScript files in decreasing order.

## Features
- Connects to GitHub API using Octokit.
- Retrieves and processes JavaScript/TypeScript files from the `lodash/lodash` repository.
- Calculates the frequency of each letter and returns the statistics in decreasing order.

## Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Git](https://git-scm.com/)

## Setup

1. **Clone the repository**:
    ```sh
    git clone https://github.com/jjosequevedo/gitstatanalyzer
    cd gitstatanalyzer
    ```

2. **Install the required packages**:
    ```sh
    dotnet restore
    ```

3. **Build the project**:
    ```sh
    dotnet build
    ```

4. **Run the application**:
    ```sh
    cd GitStatAnalyzer
    dotnet run
    ```

    The API will be available at `https://localhost:5141`.

## Usage

### API Endpoints

#### Get Letter Frequencies
- **URL**: `/api/githubstats/letter-frequencies`
- **Method**: `GET`
- **Response**: JSON array of letter frequencies in decreasing order.

### Example Request
```sh
curl https://localhost:5001/api/githubstats/letter-frequencies
```

### Example Response
``` json
[{"letter":"e","count":25},{"letter":"t","count":15},{"letter":"s","count":13},...]
```

### Project Structure
- `Controllers/`: Contains the API controller.
- `Models/`: Contains the data model for letter frequency.
- `Services/`: Contains the service interfaces and implementations.
- `Program.cs`: Configures and runs the application.
- `GitStatAnalyzer.csproj`: Project file with dependencies.

### Contributions
Contributions are welcome! Please open an issue or submit a pull request.
