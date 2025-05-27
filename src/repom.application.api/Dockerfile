FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["repom.application.api/repom.application.api.csproj", "repom.application.api/"]
COPY ["repom.application/repom.application.csproj", "repom.application/"]
COPY ["repom.domain.core/repom.domain.core.csproj", "repom.domain.core/"]
COPY ["repom.bootstrapper/repom.bootstrapper.csproj", "repom.bootstrapper/"]
COPY ["repom.persistence/repom.persistence.csproj", "repom.persistence/"]
COPY ["repom.utils/repom.utils.csproj", "repom.utils/"]
RUN dotnet restore "repom.application.api/repom.application.api.csproj"
COPY . .
WORKDIR "/src/repom.application.api"
RUN dotnet build "./repom.application.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./repom.application.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "repom.application.api.dll"]
