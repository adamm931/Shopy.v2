export interface LoginDispatch {
    Login: (state: LoginState) => void
}

export interface LoginState {
    Username: string;
    Password: string;
}