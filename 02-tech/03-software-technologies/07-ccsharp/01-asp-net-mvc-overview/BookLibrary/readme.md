# Info

## Issues

### Migration issues

Drop the database, then run these commands the project(not solution) directory

#### Delete migrations

    dotnet ef database update 0
    dotnet ef migrations remove

#### Then update

    dotnet ef migrations add SomeMigration
    dotnet ef database update

### VS alternative commands

    Add-Migration AddUserFullName

Does stuff, then creates a migration(File)

    Update-Database

Updates database
Used when changing database
