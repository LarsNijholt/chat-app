FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/bundles/ChatApp.Server/ChatApp.Server.csproj", "src/bundles/ChatApp.Server/"]
COPY ["src/modules-server/ChatApp.Core/ChatApp.Core.csproj", "src/modules-server/ChatApp.Core/"]
COPY ["src/modules-server/persistence/ChatApp.EntityFrameworkCore/ChatApp.EntityFrameworkCore.csproj", "src/modules-server/persistence/ChatApp.EntityFrameworkCore/"]
RUN dotnet restore "src/bundles/ChatApp.Server/ChatApp.Server.csproj"
COPY . .
WORKDIR "/src/src/bundles/ChatApp.Server"
RUN dotnet build "ChatApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChatApp.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatApp.Server.dll"]
