# All Project
## Case logic
- Objects and variables: Snake case (user_name)
- Class, enum, file, folder: Pascall case (UserName)
- Strings: Upper snake case (USER_NAME)
- Function, method: Camel case (userName)
- HTML attributes: Lower case (username)
- CSS names: kebaba case (user-name)


# Frontend 

## Features

- ⚡ **Next.js** - React framework for static rendering
- **Best SEO setup** - Meta Tags, JSON-LD and Open Graph Tags
- **[Tina CMS](https://tina.io/) integration** - local & (optional) production CMS
- **Optimized for Web Vitals**
- **Blog with MDX**
- **Mailchimp Integration** - for newsletters
- **Sendgrid Integration** - for sending emails
- **Dark mode** - and customizable themes!
- **No UI library** - just styled components, so you don't have to learn any new syntax
- **One click deployment** - with Vercel or any other serverless deployment environment
- **Eslint** - with Next.js's recommended settings and imports sorting rule
- **Prettier**

## 🤓 Getting Started

- Click `Use the template` or [this link](https://github.com/Blazity/next-saas-starter/generate)
- Setup your [sendgrid](https://sendgrid.com/) API key and add it to environment variables (`SENDGRID_API_KEY` - `.env.local`)
- Adjust the template to your needs (and checkout `env.ts` file)
- Deploy the project on [Vercel](https://vercel.com/) **don't forget to add env variables**
- _(optional)_ Create [Tina Cloud account](https://app.tina.io/), [a project](https://tina.io/docs/tina-cloud/) and fill these `NEXT_PUBLIC_ORGANIZATION_NAME`, `NEXT_PUBLIC_TINA_CLIENT_ID` env vars with proper values
  > Tina's Content API authenticates directly with GitHub removing the need for users to create GitHub accounts. Access is granted through the dashboard, allowing users to login directly through your site and begin editing! Any changes that are saved by your editors will be commited to the configured branch in your GitHub repository.
  - For more details [see the docs](https://tina.io/docs/tina-cloud/)

```
# run the dev mode
$ yarn dev

# run the prod mode
yarn start

# build the app
yarn build
```

> Hint: To edit the blog pages go to [/admin](http://localhost:3000/admin) and navigate to a blog page to edit it. To exit editing mode navigate to [/admin/logout](http://localhost:3000/admin/logout)


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
