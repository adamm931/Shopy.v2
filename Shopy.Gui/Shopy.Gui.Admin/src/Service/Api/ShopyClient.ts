import { IKeyValue } from './../../Components/Shared/Types/IKeyValue';
import { Header } from './Header';
import IShopyClient from './IShopyClient'
import axios, { AxiosRequestConfig } from 'axios'
import { HttpMethod } from './HttpMethod';

export async function Get<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Create().Get(path);
}

export async function Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Create().Post(path, body);
}

export async function Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
    return await ShopyClient.Create().Put(path, body);
}

export async function Delete<TResult>(path: string): Promise<TResult> {
    return await ShopyClient.Create().Delete(path);
}

class ShopyClient implements IShopyClient {

    private header: Header
    private baseAddress: string

    private constructor(baseAddress: string) {
        this.baseAddress = baseAddress;
        this.header = new Header()
    }

    AddHeader(headers: IKeyValue[]): void {

        headers.forEach(header => {
            this.header.AddEntry(header.Key, header.Value)
        });

    }

    public static Create(): IShopyClient {
        return new ShopyClient(process.env.REACT_APP_API_ADDRESS as string);
    }

    async Get<TResult>(path: string): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Get, path);
    }

    async Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Post, path, body);
    }

    async Put<TResult, TRequest>(path: string, body: TRequest): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Put, path, body);
    }

    async Delete<TResult>(path: string): Promise<TResult> {
        return await this.request<TResult>(HttpMethod.Delete, path);
    }

    async request<TResult, TRequest = {}>(
        method: HttpMethod,
        path: string,
        data: TRequest = {} as any): Promise<TResult> {
        try {

            this.header.AddEntry("Content-Type", "application/json")

            let request: AxiosRequestConfig = {
                data: data,
                url: path,
                method: method,
                headers: this.header.Raw()
            };

            const response = await this.createClient().request(request);
            return response.data as TResult;
        }
        catch (error) {
            console.log(error);
            throw error;
        }
    }

    createClient = () => axios.create({
        baseURL: this.baseAddress,
    })

}