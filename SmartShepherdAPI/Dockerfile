# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY SmartShepherdAPI/SmartShepherdAPI.csproj SmartShepherdAPI/
RUN dotnet restore SmartShepherdAPI/SmartShepherdAPI.csproj

# Copy everything else and build
COPY . .
WORKDIR /app/SmartShepherdAPI
RUN dotnet publish -c Release -o /out

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out .

# Run the app
ENTRYPOINT ["dotnet", "SmartShepherdAPI.dll"]
