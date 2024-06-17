# Build the application and tests in the same stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy and restore the project files
COPY MyWebApp/MyWebApp.csproj ./MyWebApp/
COPY MyWebApp.Tests/MyWebApp.Tests.csproj ./MyWebApp.Tests/
RUN dotnet restore MyWebApp/MyWebApp.csproj

# Copy everything else
COPY . .

# Build the web application
RUN dotnet publish MyWebApp/MyWebApp.csproj -c Release -o /app/out

# Run the tests
WORKDIR /app/MyWebApp.Tests
RUN dotnet test -c Release --logger "console;verbosity=detailed"

# List files in the output directory
RUN ls -la /app/MyWebApp.Tests/bin/Release/net8.0 

# Entrypoint to run the tests
ENTRYPOINT ["dotnet", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
