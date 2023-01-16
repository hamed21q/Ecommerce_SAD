#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ES.Presentation/ES.Presentation.csproj", "ES.Presentation/"]
COPY ["ES.Infrustructure.Core/ES.Infrustructure.Core.csproj", "ES.Infrustructure.Core/"]
COPY ["ES.Application.Contracts/ES.Application.Contracts.csproj", "ES.Application.Contracts/"]
COPY ["CS.Domain/ES.Domain.csproj", "CS.Domain/"]
COPY ["ES.Application/ES.Application.csproj", "ES.Application/"]
COPY ["ES.Infructructure.EfCore/ES.Infructructure.EfCore.csproj", "ES.Infructructure.EfCore/"]
RUN dotnet restore "ES.Presentation/ES.Presentation.csproj"
COPY . .
WORKDIR "/src/ES.Presentation"
RUN dotnet build "ES.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ES.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ES.Presentation.dll"]