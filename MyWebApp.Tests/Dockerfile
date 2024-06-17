# Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy and restore the project file
COPY MyWebApp/MyWebApp.csproj ./MyWebApp/
RUN dotnet restore MyWebApp/MyWebApp.csproj

# Copy everything else for the web app
COPY MyWebApp/. ./MyWebApp/
#Build the app so that the entrypoint for the container has a built binary
RUN dotnet publish MyWebApp/MyWebApp.csproj -c Release -o /app/out


# Test image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test
WORKDIR /app

# Copy and restore the test project file
COPY MyWebApp.Tests/MyWebApp.Tests.csproj ./MyWebApp.Tests/
RUN dotnet restore MyWebApp.Tests/MyWebApp.Tests.csproj

# Copy everything else
COPY MyWebApp.Tests/. ./MyWebApp.Tests/

# Copy built application from the previous stage
COPY --from=build-env /app/out ./MyWebApp/out

# Run the tests.
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

ENTRYPOINT ["dotnet", "test", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
