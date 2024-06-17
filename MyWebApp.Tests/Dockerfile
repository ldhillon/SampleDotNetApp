# Use the .NET 8 SDK image for both building and testing
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory within the container
WORKDIR /app

# Copy all project files to the container
COPY . .

# Restore dependencies for both projects
RUN dotnet restore MyWebApp.Tests/MyWebApp.Tests.csproj

# Build the web application
RUN dotnet publish MyWebApp/MyWebApp.csproj -c Release -o /app/out

# Build the test project
RUN dotnet build MyWebApp.Tests/MyWebApp.Tests.csproj -c Release 

# Run the tests with detailed logging
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release --logger trx  

# List files in the output directory (uncomment to check the presence of the DLL)
RUN ls -la /app/MyWebApp.Tests/bin/Release/net8.0 

# Entrypoint to run the tests
ENTRYPOINT ["dotnet", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
