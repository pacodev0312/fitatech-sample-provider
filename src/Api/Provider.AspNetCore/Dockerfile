FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY ./bin/Release/Provider.AspNetCore/net8.0/publish .

USER $APP_UID
EXPOSE 8080

CMD dotnet Fintatech.DataProviders.Sample.Api.Provider.AspNetCore.dll
