FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY /src .
WORKDIR /src/Dotnet.Example.Api
RUN dotnet restore Dotnet.Example.Api.csproj
RUN dotnet publish Dotnet.Example.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

RUN useradd -u 1001 -r -g 0 -s /usr/sbin/nologin default \
    && chown -R 1001:0 /app \
    && chmod -R g+rw /app 

# Need to set this because the Base image defaults to 80 which will not work as a non root user.....
# More info: https://stackoverflow.com/questions/48669548/why-does-aspnet-core-start-on-port-80-from-within-docker
ENV ASPNETCORE_URLS=http://+:8080
USER 1001
EXPOSE 8080

ENTRYPOINT ["dotnet", "Dotnet.Example.Api.dll"]