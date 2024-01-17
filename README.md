# TheKings
TheKings Console Application

Overview
TheKings is a C#/.NET Core Console Application designed to fetch and analyze data about English monarchs. The project is self-contained, handling both the data retrieval and processing within a single process. Using Newtonsoft Json for data conversion and LINQ for data querying, TheKings offers insights into historical monarch data.

#### TheKings API
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup


#### Docker Compose establishment with diff microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables


#### Features
* Data Fetching: The application fetches a list of English monarchs from an online source, ensuring up-to-date information.
* Data Analysis: Utilizes LINQ queries to produce statistics about the monarchs, such as the number of monarchs, the longest-reigning monarch, the house that ruled the longest, and the most common first name among the monarchs.
* Local Data Representation: Converts the fetched data into a local format for ease of manipulation and analysis.
* 
####  Technical Details
* Data Source: The monarch data is sourced from a publicly available gist.
* Data Storage: Upon initialization, the application loads the data into a SQL database, leveraging Entity Framework ORM for efficient data handling.
* Dependency: Aside from the standard .NET Core libraries, the project utilizes Newtonsoft Json for JSON processing.
* 
#### Usage
TheKings.API provides endpoints from which TheKings console application retrieves the required data. After fetching the data from the API, the application performs various statistical analyses and displays the results in the console.

#### Project Structure
TheKings.API: Handles data provision through RESTful endpoints.
TheKings.ConsoleApp: The main console application responsible for data retrieval and processing.

#### Getting Started
To run TheKings, simply clone the repository, ensure you have .NET Core installed, and execute the console application. The API should be running to fetch the data successfully.
