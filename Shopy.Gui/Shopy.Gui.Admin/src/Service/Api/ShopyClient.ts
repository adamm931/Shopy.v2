import { Header } from './Header';
import IShopyClient from './IShopyClient'
import axios, { AxiosRequestConfig } from 'axios'
import { HttpMethod } from './HttpMethod';
import { EnviromentUtils } from '../../Utils/EnviromentUtils';
import { AuthUtils } from '../../Utils/AuthUtils';

export async function Get<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Instance.Get(path);
}

export async function Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Instance.Post(path, body);
}

export async function Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Instance.Put(path, body);
}

export async function Delete<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Instance.Delete(path);
}

class ShopyClient implements IShopyClient {

    private header: Header
    private baseAddress: string
    private token: string

    private constructor(baseAddress: string, token: string) {
        this.baseAddress = baseAddress;
        this.token = token
        this.header = new Header()
    }

    public static Instance: IShopyClient = new ShopyClient(EnviromentUtils.ApiBaseUrl, AuthUtils.GetToken())

    async Get<TResult>(path: string): Promise<TResult> {
        return await this.PerformRequest<TResult>(HttpMethod.Get, path);
    }

    async Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.PerformRequest<TResult>(HttpMethod.Post, path, body);
    }

    async Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.PerformRequest<TResult>(HttpMethod.Put, path, body);
    }

    async Delete<TResult>(path: string): Promise<TResult> {
        return await this.PerformRequest<TResult>(HttpMethod.Delete, path);
    }

    async PerformRequest<TResult, TRequest = {}>(
        method: HttpMethod,
        path: string,
        data: TRequest = {} as any): Promise<TResult> {
        try {

            this.header.AddEntry("Content-Type", "application/json")
            this.header.AddEntry("Authorization", `Bearer ${this.token}`)

            let request: AxiosRequestConfig = {
                data: data,
                url: path,
                method: method,
                headers: this.header.Raw()
            };

            const client = axios.create({ baseURL: this.baseAddress })
            const response = await client.request(request);

            return response.data as TResult;
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    }
}