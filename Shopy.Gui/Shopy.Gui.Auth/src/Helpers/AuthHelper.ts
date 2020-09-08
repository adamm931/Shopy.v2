import { CheckUsernameResponse } from './../Api/Models/CheckUsernameResponse';
import { CheckUsernameUrl, RegisterUrl, LoginUrl } from './../Api/Urls';
import Client from '../Api/Client'

class AuthHelper {

    public async CheckUsername(username: string): Promise<boolean> {
        return await Client.Post<any, CheckUsernameResponse>(CheckUsernameUrl, {
            Username: username
        })
            .then(res => res.IsAvailable);
    }

    public async Login(username: string, password: string) {
        return await Client.Post(LoginUrl, {
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
