FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1402


FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Identity.Management.Api/Identity.Management.Api.csproj", "Identity.Management.Api/"]
RUN dotnet restore "Identity.Management.Api/Identity.Management.Api.csproj"
COPY . .
WORKDIR "/src/Identity.Management.Api"
RUN dotnet build "Identity.Management.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Identity.Management.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_ENVIRONMENT="Development"
ENTRYPOINT ["dotnet", "Identity.Management.Api.dll"]