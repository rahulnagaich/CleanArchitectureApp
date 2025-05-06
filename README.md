Solution Overview
The solution is structured around Clean Architecture, which emphasizes separation of concerns and independence of frameworks, UI, and infrastructure. It ensures that the core business logic is independent of external dependencies, making the application maintainable, testable, and scalable.
---
Key Concepts
1.	Clean Architecture Principles:
•	Core Independence: The core domain (entities, use cases) is independent of frameworks, databases, or UI.
•	Separation of Concerns: Each layer has a specific responsibility.
•	Dependency Inversion: High-level modules (business logic) should not depend on low-level modules (infrastructure). Both should depend on abstractions.
2.	Layered Architecture:
•	Domain Layer: Contains core business logic and entities.
•	Application Layer: Contains use cases, commands, queries, and interfaces for interacting with the domain.
•	Infrastructure Layer: Handles database access, external services, and other low-level concerns.
•	Presentation Layer: Handles UI or API endpoints.
3.	CQRS (Command Query Responsibility Segregation):
•	Commands (e.g., CreateCategoryCommand) modify state.
•	Queries (e.g., GetAllCategoriesQueryHandler) retrieve data.
4.	Entity Framework Core:
•	Used for database access and object-relational mapping (ORM).
•	Includes features like migrations, seeding, and change tracking.
5.	MediatR:
•	A library for implementing the Mediator Pattern.
•	Decouples the sender and receiver of requests (e.g., commands and queries).
6.	Unit Testing:
•	Ensures the correctness of individual components (e.g., entities, handlers).
•	Uses libraries like XUnit and FluentAssertions.
---
Technologies Used
1.	.NET 8:
•	The latest version of the .NET platform, offering performance improvements and modern features.
2.	Entity Framework Core:
•	ORM for database interactions.
3.	MediatR:
•	Simplifies the implementation of CQRS.
4.	AutoMapper:
•	Handles object-to-object mapping (e.g., mapping entities to DTOs).
5.	XUnit:
•	A testing framework for writing unit tests.
6.	FluentAssertions:
•	Provides a fluent syntax for writing assertions in tests.
