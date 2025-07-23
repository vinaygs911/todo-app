    # Build Stage
    # ------------------------
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /app
    
    # Copy project files
    COPY ./src/ToDo.API/ToDo.API.csproj ./ToDo.API/
    COPY ./src/ToDo.Infrastructure/ToDo.Infrastructure.csproj ./ToDo.Infrastructure/
    COPY ./src/ToDo.Application/ToDo.Application.csproj ./ToDo.Application/
    
    # Restore dependencies
    RUN dotnet restore ./ToDo.API/ToDo.API.csproj
    
    # Copy all source code
    COPY ./src ./
    
    # Build and publish the app
    RUN dotnet publish ./ToDo.API/ToDo.API.csproj -c Release -o /app/out
    
    # ------------------------
    # Runtime Stage
    # ------------------------
    FROM mcr.microsoft.com/dotnet/aspnet:8.0
    WORKDIR /app
    
    # Copy compiled app
    COPY --from=build /app/out .
    
    # Copy entrypoint for migrations
    COPY entrypoint.sh .
    
    RUN chmod +x entrypoint.sh
    
    # Entrypoint that applies migrations, then starts the app
    ENTRYPOINT ["./entrypoint.sh"]