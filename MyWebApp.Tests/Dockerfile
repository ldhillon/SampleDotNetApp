FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test-env
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
