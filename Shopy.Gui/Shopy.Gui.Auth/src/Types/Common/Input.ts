import { ChangeEvent } from "react";
import { InputIconType } from "./InputIcon";

export interface InputProps {
    Type: InputType
    Placeholder: string
    IconType: InputIconType
    OnChange: (event: ChangeEvent<HTMLInputElement>) => void
}

export enum InputType {
    Text = "text",
    Password = "password"
}