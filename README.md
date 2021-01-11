# Azure Functions with Custom Root and Intermediate Certificates

This repo includes sample Functions, one written in .NET and one in Node JS, that make an HTTP call to an external web service hosted at: `https://mtlsdemo.nielski.com:8443/`. This service uses a TLS certificate issued by a custom certificate chain. Each Function App is depoyed via a Dockerfile based on the [Azure Functions Base image](https://hub.docker.com/_/microsoft-azure-functions-base?tab=description). The required root and intermediate CA certificates are imported so that the TLS connection for an outbound call can be established.


## Prerequisites

In order to test this project locally, this sample requires the following installed and configured:
1) Docker Desktop
2) .Net Core 3.1 SDK 
3) Node 10+

Visual Studio Code is the recommended IDE.

## Build and Run (.NET Core)

Switch to the `dotnet` directory and execute the following command to create the image:

```bash
docker build -t [your_docker_id]/tlsdotnet:0.0.1 .
```

Next, start the Function container:

```bash
docker run -p 8080:80 -it [your_docker_id]/tlsdotnet:0.0.1
```

## Build and Run (Node JS)

Switch to the `node` directory and execute the following command to create the image:

```bash
docker build -t [your_docker_id]/tlsnode:0.0.1 .
```

Next, start the Function container:

```bash
docker run -p 8081:80 -it [your_docker_id]/tlsnode:0.0.1
```
