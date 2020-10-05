FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Multilingual.MigrationTool/Multilingual.MigrationTool.csproj", "Multilingual/"]
RUN ls
RUN dotnet restore "./Multilingual/Multilingual.MigrationTool.csproj"
COPY . .
WORKDIR "/src/Multilingual.MigrationTool"
RUN ls
RUN dotnet build "Multilingual.MigrationTool.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Multilingual.MigrationTool.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Multilingual.MigrationTool.dll"]