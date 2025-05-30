# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy everything and restore
COPY . ./
RUN dotnet restore SmartShepherdAPI.csproj

# Publish the release version
RUN dotnet publish SmartShepherdAPI.csproj -c Release -o /out

# Use the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out .

# Run the app
ENTRYPOINT ["dotnet", "SmartShepherdAPI.dll"]
