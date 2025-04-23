# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY CTRLightsPublicAPI/CTRLightsPublicAPI.csproj ./ 
RUN dotnet restore

# Copy everything else inside the project folder
COPY CTRLightsPublicAPI/. ./

# Publish the app
RUN dotnet publish -c Release -o /app

# Use the .NET runtime image to serve the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "CTRLightsPublicAPI.dll"]




