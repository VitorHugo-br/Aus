
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ProjetoAus.Api/ProjetoAus.Api.csproj", "ProjetoAus.Api/"]
COPY ["ProjetoAus.Data/ProjetoAus.Data.csproj", "ProjetoAus.Data/"]
COPY ["ProjetoAus.Models/ProjetoAus.Models.csproj", "ProjetoAus.Models/"]
COPY ["ProjetoAus.BLL/ProjetoAus.BLL.csproj", "ProjetoAus.BLL/"]

RUN dotnet restore "ProjetoAus.Api/ProjetoAus.Api.csproj"

COPY . .
WORKDIR "/src/ProjetoAus.Api"
RUN dotnet build "ProjetoAus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProjetoAus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoAus.Api.dll"]