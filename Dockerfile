# ==============================
# 1️⃣ Build Stage
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# ✅ 전체 솔루션 복사
COPY . .

# ✅ Web 프로젝트로 이동 후 빌드
WORKDIR /app/SophiaWorld.Web
RUN dotnet publish -c Release -o out

# ==============================
# 2️⃣ Runtime Stage
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# ✅ 빌드 결과물 복사
COPY --from=build /app/SophiaWorld.Web/out ./

# ✅ SQLite DB 복사 (루트에 바로 app.db 있는 경우)
COPY --from=build /app/SophiaWorld.Web/app.db ./app.db

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "SophiaWorld.Web.dll"]
