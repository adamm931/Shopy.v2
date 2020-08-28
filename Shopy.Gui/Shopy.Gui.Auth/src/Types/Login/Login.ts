export interface LoginDispatch {
    Login: (username: string, password: string) => void
}

export interface LoginState {
    Username: string;
    Password: string;
}