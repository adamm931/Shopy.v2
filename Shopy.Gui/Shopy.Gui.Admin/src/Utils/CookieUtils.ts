import Cookies from "js-cookie";

export class CookieUtils {
    public static GetCookie(name: string): string {
        return Cookies.get(name) || ''
    }

    public static HasCookie(name: string): boolean {
        return CookieUtils.GetCookie(name) !== ''
    }

    public static RemoveCookie(name: string) {
        Cookies.remove(name)
    }
}