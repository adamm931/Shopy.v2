export const BaseUrl = "https://localhost:44359/api/auth"

export const LoginUrl = "login"

export const RegisterUrl = "register"

export const CheckUsernameUrl = "checkUsername"

export const Compose = (base: string, relative: string) => `${base}/${relative}`