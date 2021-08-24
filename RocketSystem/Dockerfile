FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RocketSystem/RocketSystem.csproj", "RocketSystem/"]
RUN dotnet restore "RocketSystem/RocketSystem.csproj"
COPY . .
WORKDIR "/src/RocketSystem"
RUN dotnet build "RocketSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RocketSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RocketSystem.dll"]
