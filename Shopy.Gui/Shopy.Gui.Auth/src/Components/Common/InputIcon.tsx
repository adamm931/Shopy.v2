import React from 'react'
import { InputIconProps } from '../../Types/Common/InputIcon'

export const InputIcon: React.FC<InputIconProps> = (props: InputIconProps) =>
    <div className="input-group-append">
        <div className="input-group-text">
            <span className={"fas fa-" + props.Type}></span>
        </div>
    </div>