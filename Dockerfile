FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore MyTracker/MyTracker.csproj
RUN dotnet publish MyTracker/MyTracker.csproj -c Release -o out --self-contained false

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MyTracker.dll"]