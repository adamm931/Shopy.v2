import { CookieNames } from '../Common/CookieNames';
import { CookieUtils } from './CookieUtils';
import { EnviromentUtils } from './EnviromentUtils';
import { UriUtils } from './UriUtils';

export class AuthUtils {
    public static GetToken() {
        return CookieUtils.GetCookie(CookieNames.ShopyUserToken)
    }

    public static IsAuthenticated() {
        return CookieUtils.HasCookie(CookieNames.ShopyUserToken)
    }

    public static Logout() {
        CookieUtils.RemoveCookie(CookieNames.ShopyUserToken)
        UriUtils.RedirectToUrl(EnviromentUtils.LoginUrl)
    }
}