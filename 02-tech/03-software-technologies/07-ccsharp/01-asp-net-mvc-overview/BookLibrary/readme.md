# Info

## Issues

### Migration issues

Drop the database, then run these commands the project(not solution) directory

#### Delete migrations

    dotnet ef database update 0
    dotnet ef migrations remove

#### Then update

    dotnet ef migrations add initial
    dotnet ef database update