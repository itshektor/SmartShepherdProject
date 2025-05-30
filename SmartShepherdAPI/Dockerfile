# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY SmartShepherdAPI/SmartShepherdAPI.csproj SmartShepherdAPI/
RUN dotnet restore SmartShepherdAPI/SmartShepherdAPI.csproj

# Publish the release version
COPY . .
WORKDIR /app/SmartShepherdAPI
RUN dotnet publish -c Release -o /out

# Use the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .


# Run the app
ENTRYPOINT ["dotnet", "SmartShepherdAPI.dll"]
