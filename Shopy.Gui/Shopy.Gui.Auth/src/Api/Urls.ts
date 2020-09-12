const Compose = (base: string, relative: string) => `${base}/${relative}`

const BaseUrl = "https://localhost:44359/api/auth"

export const LoginUrl = Compose(BaseUrl, "login")

export const RegisterUrl = Compose(BaseUrl, "register")

export const CheckUsernameUrl = Compose(BaseUrl, "checkUsername")

