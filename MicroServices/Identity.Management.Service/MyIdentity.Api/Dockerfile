FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MyIdentity.Api/MyIdentity.Api.csproj", "MyIdentity.Api/"]
COPY ["MyIdentity.Configs/MyIdentity.Configs.csproj", "MyIdentity.Configs/"]
COPY ["MyIdentity.Migrations/MyIdentity.Migrations.csproj", "MyIdentity.Migrations/"]
COPY ["MyIdentity.DataAccess/MyIdentity.DataAccess.csproj", "MyIdentity.DataAccess/"]
COPY ["MyIdentity.Models/MyIdentity.Models.csproj", "MyIdentity.Models/"]
RUN dotnet restore "MyIdentity.Api/MyIdentity.Api.csproj"
COPY . .
WORKDIR "/src/MyIdentity.Api"
RUN dotnet build "MyIdentity.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MyIdentity.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT="Development"
ENTRYPOINT ["dotnet", "MyIdentity.Api.dll"]