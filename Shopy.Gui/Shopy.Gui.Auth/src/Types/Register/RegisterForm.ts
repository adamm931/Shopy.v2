import { ChangeEvent, FormEvent } from "react";

export interface RegisterFormProps {
    OnEmailChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnUsernameChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnPasswordChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnConfirmPasswordChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnSubmit: (event: FormEvent<HTMLFormElement>) => void
}