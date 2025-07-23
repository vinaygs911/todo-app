# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files to restore dependencies
COPY src/ToDo.API/ToDo.API.csproj src/ToDo.API/
COPY src/ToDo.Application/ToDo.Application.csproj src/ToDo.Application/

# Restore dependencies
RUN dotnet restore src/ToDo.API/ToDo.API.csproj

# Copy all source code
COPY . .

# Publish the application
RUN dotnet publish src/ToDo.API/ToDo.API.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output
COPY --from=build /app/publish .

# Copy and prepare the entrypoint script
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

EXPOSE 80
ENTRYPOINT ["./entrypoint.sh"]