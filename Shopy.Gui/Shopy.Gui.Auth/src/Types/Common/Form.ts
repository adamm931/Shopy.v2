import { FormEvent } from "react";

export interface FormProps {
    Title: string
    Message: string
    OnSubmit: (event: FormEvent<HTMLFormElement>) => void
}