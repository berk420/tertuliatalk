# All Project
## Case logic
- Objects and variables: Snake case (user_name)
- Class, enum, file, folder: Pascall case (UserName)
- Strings: Upper snake case (USER_NAME)
- Function, method: Camel case (userName)
- HTML attributes: Lower case (username)
- CSS names: kebaba case (user-name)



# Backend
## .NET API Project with Redis Integration

This project is a .NET API that requires a Redis server running on Docker at port 6379. The Redis server is used for caching and session management.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Running Redis with Docker](#running-redis-with-docker)
- [Running the .NET API](#running-the-net-api)
- [License](#license)

## Prerequisites

- Docker and Docker Compose
- .NET SDK
- Redis

## Getting Started

To run this project, you need to have Docker installed and running on your machine. If Docker is not installed, you can download it from [Docker's official website](https://www.docker.com/).

## Running Redis with Docker

To run a Redis server on Docker, use the following command:

```bash
docker run -d --name redis-server -p 6379:6379 redis
```

This command will:

- Pull the latest Redis image from Docker Hub.
- Run Redis in a detached mode (`-d`).
- Expose Redis on port 6379 (`-p 6379:6379`).

Ensure that the Redis server is running correctly by using:

```bash
docker ps
```

You should see `redis-server` listed as one of the running containers.

## Running the .NET API

Once Redis is up and running, you can start your .NET API by running:

```bash
dotnet run
```

The API should connect to the Redis server running on port 6379.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
```

Bu dosya, `.md` formatında bir README dosyası olarak kullanılmaya hazırdır. Kopyalayarak projenizin kök dizinine `README.md` olarak kaydedebilirsiniz.
