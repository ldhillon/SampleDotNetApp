FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copy the project file first to restore dependencies
COPY MyWebApp.Tests.csproj ./MyWebApp.Tests/
RUN dotnet restore MyWebApp.Tests/MyWebApp.Tests.csproj

# Copy everything else
COPY . . 

# Run the tests.
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

# (Optional) Check if your test DLL exists after the build.
# RUN ls /app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll

# Explicitly specify the path to the test DLL.
ENTRYPOINT ["dotnet", "test", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
