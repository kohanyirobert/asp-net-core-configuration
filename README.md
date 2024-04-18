# AspNetCoreConfiguration

Sample repo to showcase how developers could use different credentials
for databases or similar services when working on projects without
hard-coding and committing those to their code repository.

1. Start the production run configuration and note that
the no configuration settingss are displayed at `http://localhost:5041/api/config/env`
2. Start the development run configuration and note
the development connection string is displayed at `http://localhost:5041/api/config/env`
3. Create a user secret by running `dotnet user-secrets init` **in the
project's directory** (not in the solution folder)
4. Then set your local connection string with the following command
`dotnet user-secrets set ConnectionStrings:Default "Server=local-server;Database=local-db;Trusted_Connection=True;"`
5. **Note**: the _key_ of the setting is _ConnectionString**s**_ with an _s_ at the end
6. Then run the production run config again and note that at the previous URL still the production
connection string is displayed
7. Run the development run config and note that this time the _local_ connection is displayed
that was set with `dotnet user-secrets`
8. Now stop everything and open a terminal then navigate to the project's (not the solution's) folder
9. Set the the follow environment variable
   - Using PowerShell: `$Env:CONNECTIONSTRINGS__DEFAULT = "Server=production-server;Database=production-db;Trusted_Connection=True;"`
   - Using Bash: `export CONNECTIONSTRINGS__DEFAULT="Server=production-server;Database=production-db;Trusted_Connection=True;"`
10. Finally run the application with `dotnet run` and note that in the previous URL the local connection
string is displayed

To summarize:
1. Set public defaults into `appsettings.json` (e.g. like default logging level, default temp directory, etc.)
2. Set "sane" defaults into `appsettings.Development.json` which could serve as a sample config for newcomers to the project
3. Use `dotnet user-secrets` to override settings in the above files for development on your own machine
4. Override/set required settings with environment variables in different environments (production environment, Docker, GitHub Actions Workflow, AWS, etc.)
5. **Never put/commit usernames, API keys, passwords, etc. into VCS**

Please also check `launchSettings.json`, that's where it's decided whether the app runs in
a production or development environment (note the "environmentVariables" section).

Recommended reading:
1. https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0#hierarchical-configuration-data
    It's mostly interesting up until and including the section named _`appsettings.json`_ and _Security and user secrets_
2. https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows