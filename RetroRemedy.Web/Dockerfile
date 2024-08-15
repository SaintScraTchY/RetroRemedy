FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RetroRemedy.Web/RetroRemedy.Web.csproj", "RetroRemedy.Web/"]
RUN dotnet restore "RetroRemedy.Web/RetroRemedy.Web.csproj"
COPY . .
WORKDIR "/src/RetroRemedy.Web"
RUN dotnet build "RetroRemedy.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "RetroRemedy.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RetroRemedy.Web.dll"]
