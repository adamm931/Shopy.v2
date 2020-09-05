import React, { FormEvent } from 'react'
import { LoginDispatch, LoginState } from './Login.types'
import { AuthForm } from '../Shared/AuthForm/AuthForm'
import { LoginInitialValues, LoginValidationSchema } from './Login.validation'
import { AuthField } from '../Shared/AuthField/AuthField'
import { AuthFieldType, AuthFieldIconType } from '../Shared/AuthField/AuthField.types'
import { Link } from 'react-router-dom'

export const Login: React.FC<LoginDispatch> = (props: LoginDispatch) =>
    <AuthForm<LoginState>
        Title="Login"
        Message="Enter your credentials"
        InitialValues={LoginInitialValues}
        ValidationSchema={LoginValidationSchema}
        OnSubmit={props.Login}
    >
        <AuthField
            Name="Username"
            Placeholder="Enter username"
            Type={AuthFieldType.Text}
            IconType={AuthFieldIconType.Username}
        />
        <AuthField
            Name="Password"
            Placeholder="Enter password"
            Type={AuthFieldType.Password}
            IconType={AuthFieldIconType.Password}
        />
        <div className="row">
            <div className="col-8">
                <Link to="/register" className="text-center register">Register</Link>
            </div>
            <div className="col-4">
                <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">Sign In</button>
            </div>
        </div>
    </AuthForm>

