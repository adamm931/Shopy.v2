import { ShopyApiClient } from './ShopyApiClient';

export class AuthApi {

    private static client: ShopyApiClient = new ShopyApiClient("") // base address provide

    public static Login(username: string, password: string): any {

        var response = AuthApi.client.Post("/login", {
            Username: username,
            Password: password
        })

        return response
    }

    public static Register(username: string, password: string, email: string): any {

        var response = AuthApi.client.Post("/register", {
            Username: username,
            Password: password,
            Email: email
        })

        return response

    }

}