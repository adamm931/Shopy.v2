import { AdminUrlEnv } from './../Common/EnvVariables';
import { RedirectToUrl } from './UriHelpers';
import { ShopyUserToken } from './../Common/CookieNames';
import { SetCookie } from './CookieHelpers';

export const LoginUser = (token: string) => {
    SetCookie(ShopyUserToken, token);
    RedirectToUrl(AdminUrlEnv)
}