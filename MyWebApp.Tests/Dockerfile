FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

ENTRYPOINT ["dotnet", "test", "/app/build/MyWebApp.Tests.dll"]
