FROM mcr.microsoft.com/dotnet/sdk:8.0 
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet test /app/MyWebApp.Tests/MyWebApp.Tests.csproj -c Release  

# Check if your test DLL exists (optional)
# RUN ls /app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll

ENTRYPOINT ["dotnet", "test", "/app/MyWebApp.Tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
