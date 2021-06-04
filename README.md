# :moneybag: Money manager

:hatching_chick: This is a pet project for monitoring and recording finance movements.

:hatched_chick: The ultimate goal is to create a platform for:

- :notebook: convenient financial accounting  
- :chart_with_upwards_trend: obtaining recommendations based on our own financial strategies

## Desktop application

[About the desktop application](src/electronApp/README.md)

## Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

- `--project src/MoneyManager.Infrastructure` (optional if in this folder)
- `--startup-project src/ElectronApp`
- `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\MoneyManager.Infrastructure --startup-project src\ElectronApp --output-dir Persistence\Migrations`
