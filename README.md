# Azure Function with Custom Root and Intermediate Certificates

This sample includes a Function that makes a call to `https://mtlsdemo.nielski.com:8443/`, which uses a TLS certificate issued by a custom certificate chain. It works using a cusotm Dockerfile based on the [Azure Functions Base image](https://hub.docker.com/_/microsoft-azure-functions-base?tab=description). The required root and intermediate CA certificates are imported so that the TLS connection for an outbound call can be established.

> NOTE: This sample currently emits "The remote certificate is invalid according to the validation procedure."

## Prerequisites

This sample requires a recent version of Docker and .Net Core 3.1 installed on a development workstation. Visual Studio Code is recommended.

## Build and Run

From the project root, execute the following command to create the image:

```bash
docker build -t [your_docker_id]/tlsclient:0.0.1 .
```

Next, start the Function container:

```bash
docker run -p 8080:80 -it [your_docker_id]/tlsclient:0.0.1
```
