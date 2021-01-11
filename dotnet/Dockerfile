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

# COPY ca-contoso-bundle.cer /usr/share/ca-certificates/
# RUN echo ca-contoso-bundle.cer >> /etc/ca-certificates.conf
# RUN update-ca-certificates
# RUN mkdir -p /etc/pki/tls/certs
# RUN ln -s /etc/ssl/certs/ca-certificates.crt /etc/pki/tls/certs/ca-bundle.crt
# RUN cat /usr/share/ca-certificates/ca-contoso-bundle.cer >> /etc/pki/tls/certs/ca-bundle.crt

# ENV SSL_CERT_FILE=/home/site/wwwroot/ca-root-contoso.crt
# ENV SSL_CERT_FILE=/etc/pki/tls/certs/ca-bundle.crt

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]
