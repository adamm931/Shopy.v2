export class ShopyApiClient {

    private baseAddress: string;

    public constructor(baseAddress: string) {
        this.baseAddress = baseAddress
    }

    public Post<TRequest, TResponse>(path: string, body: TRequest): TResponse {
        return <TResponse>{}
    }
}