# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the project files first for caching
COPY ./ToDo.API/ToDo.API.csproj ./ToDo.API/
COPY ./ToDo.Application/ToDo.Application.csproj ./ToDo.Application/

# Restore
RUN dotnet restore ./ToDo.API/ToDo.API.csproj

# Copy the rest of the source
COPY . .

# Build & publish
RUN dotnet publish ./ToDo.API/ToDo.API.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

# EF CLI for migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

EXPOSE 80
ENTRYPOINT ["./entrypoint.sh"]