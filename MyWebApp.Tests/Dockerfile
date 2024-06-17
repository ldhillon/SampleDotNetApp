FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy and build the main application
COPY MyWebApp/MyWebApp.csproj ./MyWebApp/
RUN dotnet restore MyWebApp/MyWebApp.csproj
COPY MyWebApp/. ./MyWebApp/
RUN dotnet publish MyWebApp/MyWebApp.csproj -c Release -o /app/out

# Copy and build the test project
WORKDIR /app/tests
COPY MyWebApp.Tests/MyWebApp.Tests.csproj ./
RUN dotnet restore

# Copy everything else
COPY . .

# Run the tests.
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

# List files in the output directory (uncomment for debugging)
RUN ls -la /app/tests/bin/Release/net8.0 

# Update the Entrypoint to use the correct path and command
ENTRYPOINT ["dotnet", "/app/tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
