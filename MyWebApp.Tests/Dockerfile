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
COPY MyWebApp.Tests/. ./

# Copy built application from the previous stage
COPY --from=build-env /app/out ./MyWebApp/out

# Run the tests.
# Specify the project file explicitly
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release --logger "console;verbosity=detailed"

# List files in the output directory (uncomment for debugging)
RUN ls -la /app/tests/bin/Release/net8.0

# Entrypoint to run the tests
# Pass the correct path to the test DLL
ENTRYPOINT ["dotnet", "/app/tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
