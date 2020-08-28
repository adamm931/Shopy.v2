import React from 'react'
import { InputProps } from '../../Types/Common/Input'
import { InputIcon } from './InputIcon'

export const Input: React.FC<InputProps> = (props: InputProps) =>
    <div className="input-group mb-3">
        <input
            type={props.Type}
            className="form-control"
            placeholder={props.Placeholder}
            onChange={props.OnChange}
        />
        <InputIcon Type={props.IconType} />
    </div>