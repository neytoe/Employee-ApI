#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o publish
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 5000
COPY --from=build /app/sqlitedemo.db .
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "APIPractice.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet APIPractice.dll

