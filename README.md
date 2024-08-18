# **String Calculator & LinkedList Project**

This project contains two primary components: a **String Calculator** and a **LinkedList** implementation. 
The project emphasizes clean code practices, adherence to SOLID principles, proper error handling, 
and comprehensive unit testing with code coverage.

## **Features**

### **String Calculator**

- **Parses** a string of numbers separated by custom or default delimiters.
- **Supports** different delimiters, including custom and multiple delimiters.
- **Validates** the input to ensure there are no negative numbers.
- **Ignores** numbers greater than 1000 in the sum calculation.
- **Follows** clean code principles by using well-named methods and ensuring single responsibility.

### **LinkedList**

- **Implements** a generic singly linked list with basic operations such as insert, delete, and print.
- **Supports** inserting and deleting nodes at specified positions.
- **Logs** the linked list's state after each operation using dependency injection for logging.

## **Clean Code Practices**

- **Single Responsibility Principle**: Each class and method in the project is designed to do one thing well.
- **Readable and Intention-Revealing Names**: All methods and variables are named to clearly indicate their purpose.
- **No Comments**: The code is self-explanatory, minimizing the need for comments. This is a sign of well-written, clean code.
- **Formatted Code**: Consistent code formatting ensures readability and maintainability.

## **SOLID Principles**

The project adheres to the SOLID principles:

- **Single Responsibility Principle**: Each class has one responsibility.
- **Open/Closed Principle**: The classes are open for extension but closed for modification.
- **Liskov Substitution Principle**: Interfaces and base classes are used so that derived classes or implementations can be substituted without affecting the correctness.
- **Interface Segregation Principle**: Interfaces are small and focused, ensuring that implementing classes are not forced to implement methods they do not use.
- **Dependency Inversion Principle**: High-level modules depend on abstractions, and dependency injection is used to invert dependencies.

## **Interfaces**

Interfaces are used to decouple the implementation details from the usage:

- **`IStringCalculator`**: Defines the contract for the String Calculator.
- **`ILinkedList<T>`**: Defines the contract for the LinkedList.

## **Logger and Dependency Injection**

- The project uses **`ILogger<T>`** for logging throughout the application.
- **Dependency injection** is employed to inject loggers into classes, promoting the Dependency Inversion Principle and making the code easier to test and extend.



## **Code Coverage with Coverlet**

Coverlet is used to measure the code coverage of the project. Code coverage reports can be generated in multiple formats and viewed using tools like ReportGenerator.

### **Setting Up Code Coverage**

To run tests with coverage:

\```bash
dotnet test /p:CollectCoverage=true
\```

To generate coverage reports in multiple formats (e.g., Cobertura and OpenCover):

\```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura,opencover
\```

### **Setting Up Code Coverage**

To view the coverage report:

Install ReportGenerator:

\```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
\```

Generate and view an HTML report:

\```bash
reportgenerator -reports:./TestResults/coverage.opencover.xml -targetdir:./TestResults/CoverageReport -reporttypes:Html
\```

Open the index.html file in your browser to view the report.
