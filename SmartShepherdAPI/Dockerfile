# Use the official .NET SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy only csproj first (rest comes later)
COPY ["SmartShepherdAPI.csproj", "./"]
RUN dotnet restore

# Copy everything and publish
COPY . ./
RUN dotnet publish SmartShepherdAPI.csproj -c Release -o /out

# Use the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out ./

# Run the app
ENTRYPOINT ["dotnet", "SmartShepherdAPI.dll"]
