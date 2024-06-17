FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copy both project files first
COPY ../MyWebApp/MyWebApp.csproj ./MyWebApp/
COPY MyWebApp.Tests.csproj ./MyWebApp.Tests/

RUN dotnet restore MyWebApp.Tests/MyWebApp.Tests.csproj

# Copy everything else
COPY . .

# Publish the web app and run tests in separate steps
RUN dotnet publish MyWebApp/MyWebApp.csproj -c Release -o /app/out 
RUN dotnet test MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

# (Optional) Verify DLL Existence (uncomment to check)
# RUN ls -l /app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll

ENTRYPOINT ["dotnet", "test", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
