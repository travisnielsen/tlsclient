FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

COPY . /src/dotnet-function-app
RUN cd /src/dotnet-function-app && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish *.csproj --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

# Add custom root and CA certificates to the containter
ADD contoso-root.crt /usr/local/share/ca-certificates/contoso-root.crt
ADD contoso-int.crt /usr/local/share/ca-certificates/contoso-int.crt
RUN chmod 644 /usr/local/share/ca-certificates/contoso-root.crt && chmod 644 /usr/local/share/ca-certificates/contoso-int.crt && update-ca-certificates
# currently unsure if this command is required
RUN echo contoso-root.crt >> /etc/ca-certificates.conf && echo contoso-int.crt >> /etc/ca-certificates.conf

COPY --from=installer-env ["/home/site/wwwrootsd", "/home/site/wwwroot"]
