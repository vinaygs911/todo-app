#!/bin/bash
# Apply EF Core migrations
echo "Applying EF Core migrations..."
dotnet ToDo.API.dll ef database update

# Run the app
echo "Starting ToDo API..."
exec dotnet ToDo.API.dll