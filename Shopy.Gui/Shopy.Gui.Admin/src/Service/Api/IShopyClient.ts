export default interface IShopyClient {

    Get<TResult>(path: string): Promise<TResult>;

    Post<TResult, TRequest>(path: string, body: TRequest): Promise<TResult>;

    Put<TResult, TRequest>(path: string, body: TRequest, multipart?: boolean): Promise<TResult>;

    Delete<TBody>(path: string): Promise<TBody>;

}