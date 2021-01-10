import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import fetch from 'node-fetch';

// Load the .env file if it exists
import * as dotenv from "dotenv";
dotenv.config();

const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    context.log('HTTP trigger function processed a request.');
    context.log("Custom CA certificates: " + process.env.NODE_EXTRA_CA_CERTS);

    try {
        const webresponse = await fetch("https://mtlsdemo.nielski.com:8443");

        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "OK",
        };

    } catch (error) {
        context.log(error.message);
        context.res = {
            body: error.message,
            status: 500
        }
    }

};

export default httpTrigger;