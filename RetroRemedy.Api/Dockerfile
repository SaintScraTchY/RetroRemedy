FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RetroRemedy.Api/RetroRemedy.Api.csproj", "RetroRemedy.Api/"]
RUN dotnet restore "RetroRemedy.Api/RetroRemedy.Api.csproj"
COPY . .
WORKDIR "/src/RetroRemedy.Api"
RUN dotnet build "./RetroRemedy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RetroRemedy.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetroRemedy.Api.dll"]
