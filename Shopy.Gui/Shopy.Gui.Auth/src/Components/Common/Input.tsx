import React, { ChangeEvent } from 'react'
import { Icon, IconType } from './Icon'

export interface InputProps {
    Type: InputType
    Placeholder: string
    IconType: IconType
    OnChange: (event: ChangeEvent<HTMLInputElement>) => void
}

export enum InputType {
    Text = "text",
    Password = "password"
}

export const Input: React.FC<InputProps> = (props: InputProps) =>
    <div className="input-group mb-3">
        <input
            type={props.Type}
            className="form-control"
            placeholder={props.Placeholder}
            onChange={props.OnChange}
        />
        <Icon Type={props.IconType} />
    </div>