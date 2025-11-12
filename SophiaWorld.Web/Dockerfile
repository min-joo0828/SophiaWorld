# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 솔루션 복사
COPY . .

# Web 프로젝트만 빌드
WORKDIR /app/SophiaWorld.Web
RUN dotnet publish -c Release -o out

# 2. Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/SophiaWorld.Web/out ./

# SQLite 파일 등 로컬 데이터 포함 가능
EXPOSE 8080
ENTRYPOINT ["dotnet", "SophiaWorld.Web.dll"]
