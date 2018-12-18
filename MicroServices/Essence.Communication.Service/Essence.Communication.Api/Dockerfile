FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY . .
WORKDIR /src/MicroServices/Essence.Communication.Service/Essence.Communication.Api
RUN dotnet restore Essence.Communication.Api.csproj
RUN dotnet build Essence.Communication.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Essence.Communication.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Essence.Communication.Api.dll"]
