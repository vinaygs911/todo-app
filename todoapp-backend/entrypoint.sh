#!/bin/bash

echo "Running EF Core Migrations..."
dotnet ef database update

echo "Starting ToDo API..."
exec dotnet ToDo.API.dll
