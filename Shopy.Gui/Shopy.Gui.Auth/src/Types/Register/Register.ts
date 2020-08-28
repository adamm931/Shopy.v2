export interface RegisterDispatch {
    Register: (username: string, email: string, password: string) => void
}

export interface RegisterState {
    Username: string;
    Email: string;
    Password: string;
    ConfirmPassword: string;
}