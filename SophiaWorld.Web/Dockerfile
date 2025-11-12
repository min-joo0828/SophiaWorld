# ==============================
# 1️⃣ Build Stage
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# ✅ 상위 폴더까지 포함해서 전체 복사
COPY ../ ./

# ✅ Web 프로젝트로 이동 후 빌드
WORKDIR /app/SophiaWorld.Web
RUN dotnet publish -c Release -o out

# ==============================
# 2️⃣ Runtime Stage
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# ✅ 빌드된 결과물 복사
COPY --from=build /app/SophiaWorld.Web/out ./

# ✅ SQLite DB 파일 복사 (루트에 app.db 있는 구조)
COPY --from=build /app/SophiaWorld.Web/app.db ./app.db

# ✅ 포트 및 환경변수 설정
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

# ✅ 실행 엔트리포인트
ENTRYPOINT ["dotnet", "SophiaWorld.Web.dll"]
