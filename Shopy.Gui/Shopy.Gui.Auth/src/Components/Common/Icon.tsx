import React from 'react'

export enum IconType {
    Username = "user",
    Email = "envelope",
    Password = "lock"
}

export interface IconProps {
    Type: IconType
}

export const Icon: React.FC<IconProps> = (props: IconProps) =>
    <div className="input-group-append">
        <div className="input-group-text">
            <span className={"fas fa-" + props.Type}></span>
        </div>
    </div>