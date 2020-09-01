export interface AuthState {
    LoggedInUser: string,
    RegisteredUser: string,
}

export const initializeState = (): AuthState => <AuthState>{
    LoggedInUser: '',
    RegisteredUser: '',
}