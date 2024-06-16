FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SampleDotNetApp/SampleDotNetApp.csproj", "SampleDotNetApp/"]
RUN dotnet restore "SampleDotNetApp/SampleDotNetApp.csproj"
COPY . .
WORKDIR "/src/SampleDotNetApp"
RUN dotnet build "SampleDotNetApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleDotNetApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleDotNetApp.dll"]
