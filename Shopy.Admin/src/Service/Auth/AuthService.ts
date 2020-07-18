import { LocalStorageKeys } from '../../Enums/LocalStorageKeys';
import { StorageUtils } from '../../Utils/StorageUtils';
import { LoginUrl } from '../Api/Urls'
import { IAuthenticateResponse } from './Models/IAuthenticateResponse';
import { IAuthenticateRequest } from './Models/IAuthenticateRequest';
import { IAuthService } from './IAuthService';
import { Post } from '../Api/ShopyClient'

export class AuthService implements IAuthService {

    LogoutUser(): void {
        StorageUtils.DeleteItem(LocalStorageKeys.UserLoggedIn);
    }

    LoginUser(): void {
        StorageUtils.SetItem(LocalStorageKeys.UserLoggedIn, true);
    }

    IsUserLogged(): boolean {

        if (!StorageUtils.HasItem(LocalStorageKeys.UserLoggedIn)) {
            return false;
        }

        return StorageUtils.GetItem<boolean>(LocalStorageKeys.UserLoggedIn);;
    }

    async AuthenticateAsync(loginRequest: IAuthenticateRequest): Promise<IAuthenticateResponse> {
        return await Post<IAuthenticateResponse, IAuthenticateRequest>(LoginUrl, loginRequest);
    }
}