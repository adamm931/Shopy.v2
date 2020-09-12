import { LoginResponse } from '../Models/LoginResponse';
import { CheckUsernameResponse } from '../Models/CheckUsernameResponse';
import { CheckUsernameUrl, RegisterUrl, LoginUrl } from '../Urls';
import Client from '../Client'

class AuthHelper {

    public async CheckUsername(username: string): Promise<CheckUsernameResponse> {
        return await Client.Post<CheckUsernameResponse>(CheckUsernameUrl, {
            Username: username
        })
    }

    public async Login(username: string, password: string): Promise<LoginResponse> {
        return await Client.Post<LoginResponse>(LoginUrl, {
            Username: username,
            Password: password,
        })
    }

    public async Register(username: string, email: string, password: string) {
        return await Client.Post(RegisterUrl, {
            Username: username,
            Email: email,
            Password: password,
        })
    }
}

export default new AuthHelper()
