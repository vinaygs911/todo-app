# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ToDo.API/*.csproj ToDo.API/
COPY ToDo.Application/*.csproj ToDo.Application/
RUN dotnet restore ToDo.API/ToDo.API.csproj

# Copy everything else
COPY . .

# Build
RUN dotnet publish ToDo.API/ToDo.API.csproj -c Release -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published files
COPY --from=build /app/publish .

# EF Tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy and make entrypoint executable
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

# Expose port
EXPOSE 80

ENTRYPOINT ["./entrypoint.sh"]