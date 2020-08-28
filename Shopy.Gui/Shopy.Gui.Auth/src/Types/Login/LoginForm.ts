import { ChangeEvent, FormEvent } from "react";

export interface LoginFormProps {
    OnUsernameChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnPasswordChange: (event: ChangeEvent<HTMLInputElement>) => void
    OnSubmit: (event: FormEvent<HTMLFormElement>) => void
}