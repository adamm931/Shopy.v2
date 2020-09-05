export interface RegisterDispatch {
    Register: (state: RegisterState) => void
}

export interface RegisterState {
    Username: string;
    Email: string;
    Password: string;
    ConfirmPassword: string;
}