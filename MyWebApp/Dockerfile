FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build

EXPOSE 80
ENTRYPOINT ["dotnet", "/app/build/MyWebApp.dll"]
