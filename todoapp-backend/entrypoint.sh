#!/bin/bash
set -e

echo "Applying EF Core migrations..."

dotnet ef database update \
  --project ./ToDo.Application/ToDo.Application.csproj \
  --startup-project ./ToDo.API/ToDo.API.csproj \
  --verbose

echo "Migrations applied."

echo "🚀 Starting ToDo API..."
exec dotnet ToDo.API.dll
