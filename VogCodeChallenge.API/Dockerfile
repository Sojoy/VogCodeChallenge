FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VogCodeChallenge.API/VogCodeChallenge.API.csproj", "VogCodeChallenge.API/"]
COPY ["VogCodeChallenge.Data/VogCodeChallenge.Data.csproj", "VogCodeChallenge.Data/"]
COPY ["VogCodeChallenge.Core/VogCodeChallenge.Core.csproj", "VogCodeChallenge.Core/"]
COPY ["VogCodeChallenge.Domain/VogCodeChallenge.Domain.csproj", "VogCodeChallenge.Domain/"]
RUN dotnet restore "VogCodeChallenge.API/VogCodeChallenge.API.csproj"
COPY . .
WORKDIR "/src/VogCodeChallenge.API"
RUN dotnet build "VogCodeChallenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VogCodeChallenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VogCodeChallenge.API.dll"]