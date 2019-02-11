FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MicroServices/Essence.Communication.Service/Essence.Communication.Api/Essence.Communication.Api.csproj", "MicroServices/Essence.Communication.Service/Essence.Communication.Api/"]
COPY ["MicroServices/Essence.Communication.Service/Essence.Communication.DbContexts/Essence.Communication.DbContexts.csproj", "MicroServices/Essence.Communication.Service/Essence.Communication.DbContexts/"]
COPY ["MicroServices/Services.Utilities/Services.Utilities.DataAccess/Services.Utilities.DataAccess.csproj", "MicroServices/Services.Utilities/Services.Utilities.DataAccess/"]
COPY ["MicroServices/Services.Utilities/Services.Utilities.Common/Services.Utilities.Common.csproj", "MicroServices/Services.Utilities/Services.Utilities.Common/"]
COPY ["MicroServices/Essence.Communication.Service/Essence.Communication.Models/Essence.Communication.Models.csproj", "MicroServices/Essence.Communication.Service/Essence.Communication.Models/"]
COPY ["Messaging/BuildingBlocks/BuildingBlocks.EventBus/BuildingBlocks.EventBus.csproj", "Messaging/BuildingBlocks/BuildingBlocks.EventBus/"]
COPY ["MicroServices/Essence.Communication.Service/Essence.Communication.BusinessServices/Essence.Communication.BusinessServices.csproj", "MicroServices/Essence.Communication.Service/Essence.Communication.BusinessServices/"]
COPY ["MicroServices/Services.Utils/Services.Utils.csproj", "MicroServices/Services.Utils/"]
COPY ["Messaging/BuildingBlocks/BuildingBlocks.EventBus.MessageQueue/BuildingBlocks.EventBus.MessageQueue.csproj", "Messaging/BuildingBlocks/BuildingBlocks.EventBus.MessageQueue/"]
RUN dotnet restore "MicroServices/Essence.Communication.Service/Essence.Communication.Api/Essence.Communication.Api.csproj"
COPY . .
WORKDIR "/src/MicroServices/Essence.Communication.Service/Essence.Communication.Api"
RUN dotnet build "Essence.Communication.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Essence.Communication.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Essence.Communication.Api.dll"]