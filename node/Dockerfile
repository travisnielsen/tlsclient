# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/node:3.0-appservice
FROM mcr.microsoft.com/azure-functions/node:3.0-appservice

# Add custom root and CA certificates to the containter
# ADD ca-root-contoso.crt /usr/local/share/ca-certificates/ca-root-contoso.crt
# ADD ca-int-contoso.crt /usr/local/share/ca-certificates/ca-int-contoso.crt
# RUN chmod 644 /usr/local/share/ca-certificates/ca-root-contoso.crt && chmod 644 /usr/local/share/ca-certificates/ca-int-contoso.crt && update-ca-certificates

ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY . /home/site/wwwroot

ENV NODE_EXTRA_CA_CERTS=/home/site/wwwroot/ca-root-contoso.pem

RUN cd /home/site/wwwroot && \
    npm install