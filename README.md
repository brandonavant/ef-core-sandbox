# ef-core-sandbox

A repository for creating EF Core related PoCs.

# Steps to build locally

1. Pick a password for your DB SA account.
2. Open `docker-compose.yml` and replace <database-password-here> with the password that you chose.
3. Open `Models/SandboxContext.cs` and replace <database-password-here> with the password that you chose.
4. Run `docker-compose up` from the command line at the root most directory of this project (same level as this README.md).
5. After performing the last step, your database container will have started up. We need to configure it by running the script at `scripts/database-setup.sql`.
6. You now may run the application using either VS or `dotnet run` from the command line.

> NOTE: If you do not have docker compose installed, follow these directions to install it: https://docs.docker.com/compose/install/.