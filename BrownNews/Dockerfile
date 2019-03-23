FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["BrownNews/BrownNews.csproj", "BrownNews/"]
RUN dotnet restore "BrownNews/BrownNews.csproj"
COPY . .
WORKDIR "/src/BrownNews"
RUN dotnet build "BrownNews.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BrownNews.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ["dotnet", "ef", "database", "update"]
ENTRYPOINT ["dotnet", "BrownNews.dll"]