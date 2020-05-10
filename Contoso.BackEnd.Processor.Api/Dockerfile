#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Contoso.BackEnd.Processor.Api/Contoso.BackEnd.Processor.Api.csproj", "Contoso.BackEnd.Processor.Api/"]
RUN dotnet restore "Contoso.BackEnd.Processor.Api/Contoso.BackEnd.Processor.Api.csproj"
COPY . .
WORKDIR "/src/Contoso.BackEnd.Processor.Api"
RUN dotnet build "Contoso.BackEnd.Processor.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contoso.BackEnd.Processor.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contoso.BackEnd.Processor.Api.dll"]