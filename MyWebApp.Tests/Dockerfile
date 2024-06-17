# Test image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test
WORKDIR /app

# Copy and restore the test project file
COPY MyWebApp.Tests/MyWebApp.Tests.csproj ./MyWebApp.Tests/
RUN dotnet restore MyWebApp.Tests/MyWebApp.Tests.csproj

# Copy everything else
COPY MyWebApp.Tests/. ./MyWebApp.Tests/

# Copy built application from the build-env stage
COPY --from=build-env /app/out ./MyWebApp/out 

# Run the tests.
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

# List files in the output directory (uncomment for debugging)
RUN ls -la /app/MyWebApp.Tests/bin/Release/net8.0 

ENTRYPOINT ["dotnet", "test", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
