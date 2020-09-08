import React from 'react'
import { Link } from 'react-router-dom'
import { AuthFormActionProps } from './AuthFormAction.types'

export const AuthFormActions: React.FC<AuthFormActionProps> = (props: AuthFormActionProps) =>
    <div className="row">
        <div className="col-8">
            <Link to={`/${props.LeftActionTo}`} className="text-center register">{props.LeftActionName}</Link>
        </div>
        <div className="col-4">
            <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">{props.RightActionName}</button>
        </div>
    </div>