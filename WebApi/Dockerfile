#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY WebApi/WebApi.csproj WebApi/
COPY ../../_Resource/WebApiIntegrations/Code/WebApi.Integrations/WebApi.Integrations.csproj ../../_Resource/WebApiIntegrations/Code/WebApi.Integrations/
COPY ../../_Resource/FandradeTecInfoUtils/FAndradeTecInfo.Utils.csproj ../../_Resource/FandradeTecInfoUtils/
RUN dotnet restore WebApi/WebApi.csproj
COPY . .
WORKDIR /src/WebApi
RUN dotnet build WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.dll"]
