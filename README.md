# Tetris Console Edition

A Tetris clone developed purely in **C# (Vanilla)** to run directly in the terminal. 

---

![alt text](screenshots/image.png)
---

## Tech Stack

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

- **Language:** C# (Vanilla)
- **Platform:** .NET 8.0 Console Application
- **Architecture:** OOP (Object Oriented Programming) with Game Loop Pattern
- **Infrastructure:** Docker & Docker Compose

---

## How to Run

This game has been containerized to ensure that you can play it without having to install the .NET SDK on your machine.

### Prerequisites

- [Docker](https://www.docker.com/) installed and running.

### Running with Docker

1.  Open the terminal in the project's root folder.
2.  Build the game image:
    ```bash
    docker compose build
    ```
3.  Run the game:
    ```bash
    docker compose run --rm tetris-game
    ```

### Running Locally (.NET SDK)

If you have the .NET 10 SDK installed and prefer to run natively:

```bash
dotnet run
```