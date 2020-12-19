# money-manager


### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/MoneyManager.Infrastructure` (optional if in this folder)
* `--startup-project src/MoneyManager.DesktopApp`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src\MoneyManager.Infrastructure --startup-project src\MoneyManager.DesktopApp --output-dir Persistence\Migrations`