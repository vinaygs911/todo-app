# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj files to restore dependencies
COPY ToDo.API/ToDo.API.csproj ToDo.API/
COPY ToDo.Application/ToDo.Application.csproj ToDo.Application/

# Restore dependencies
RUN dotnet restore ToDo.API/ToDo.API.csproj

# Copy the rest of the code
COPY . .

# Publish the app
RUN dotnet publish ToDo.API/ToDo.API.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Add entrypoint script for EF migration + run
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

EXPOSE 80
ENTRYPOINT ["./entrypoint.sh"]
