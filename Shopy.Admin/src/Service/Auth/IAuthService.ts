import { IAuthenticateResponse } from './Models/IAuthenticateResponse';
import { IAuthenticateRequest } from "./Models/IAuthenticateRequest";

export interface IAuthService {

    AuthenticateAsync(loginRequest: IAuthenticateRequest): Promise<IAuthenticateResponse>;

    IsUserLogged(): boolean;

    LoginUser(): void;

    LogoutUser(): void;
}