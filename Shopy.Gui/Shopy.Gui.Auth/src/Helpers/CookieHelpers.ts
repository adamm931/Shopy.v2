import Cookies from "js-cookie";

export const SetCookie = (name: string, value: string) => Cookies.set(name, value)