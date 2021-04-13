FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CRD-OrderReviewHook/CRD-OrderReviewHook.csproj", "CRD-OrderReviewHook/"]
RUN dotnet restore "CRD-OrderReviewHook/CRD-OrderReviewHook.csproj"
COPY . .
WORKDIR "/src/CRD-OrderReviewHook"
RUN dotnet build "CRD-OrderReviewHook.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CRD-OrderReviewHook.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CRD-OrderReviewHook.dll"]