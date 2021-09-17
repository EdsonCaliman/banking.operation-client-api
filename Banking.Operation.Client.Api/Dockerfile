#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
ENV TZ="America/Sao_Paulo"
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Operation.Client.Api/Banking.Operation.Client.Api.csproj", "Banking.Operation.Client.Api/"]
COPY ["Banking.Operation.Client.CrossCutting.Ioc/Banking.Operation.Client.CrossCutting.Ioc.csproj", "Banking.Operation.Client.CrossCutting.Ioc/"]
COPY ["Banking.Operation.Client.Infra.Data/Banking.Operation.Client.Infra.Data.csproj", "Banking.Operation.Client.Infra.Data/"]
COPY ["Banking.Operation.Client.Domain/Banking.Operation.Client.Domain.csproj", "Banking.Operation.Client.Domain/"]
RUN dotnet restore "Banking.Operation.Client.Api/Banking.Operation.Client.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Operation.Client.Api"
RUN dotnet build "Banking.Operation.Client.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Operation.Client.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Operation.Client.Api.dll"]