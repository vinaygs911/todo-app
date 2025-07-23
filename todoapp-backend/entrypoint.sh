#!/bin/bash

echo "Applying EF Core migrations..."
dotnet ef database update

echo "Starting ToDo API..."
exec dotnet ToDo.API.dll