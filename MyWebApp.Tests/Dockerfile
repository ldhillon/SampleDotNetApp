FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyWebApp/MyWebApp.csproj", "MyWebApp/"]
RUN dotnet restore "MyWebApp/MyWebApp.csproj"
COPY . .
WORKDIR "/src/MyWebApp"
RUN dotnet build "MyWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyWebApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyWebApp.dll"]


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test
WORKDIR /src/tests
COPY ["MyWebApp.Tests/MyWebApp.Tests.csproj", "MyWebApp.Tests/"]
RUN dotnet restore "MyWebApp.Tests/MyWebApp.Tests.csproj"

# Copy everything else
COPY . .

# Copy built application from the previous stage
COPY --from=publish /app/publish ./MyWebApp/out
# Copy the web app project and any other projects needed to compile tests
COPY MyWebApp ./MyWebApp/

# Run the tests.
WORKDIR /src/tests
RUN dotnet test -c Release  

ENTRYPOINT ["dotnet", "test", "/src/tests/bin/Release/net8.0/MyWebApp.Tests.dll"]
