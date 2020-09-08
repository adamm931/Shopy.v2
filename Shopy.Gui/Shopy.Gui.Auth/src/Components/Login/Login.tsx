import React from 'react'
import { LoginDispatch, LoginState } from './Login.types'
import { AuthForm } from '../Shared/AuthForm/AuthForm'
import { LoginInitialValues, LoginValidationSchema } from './Login.validation'
import { AuthField } from '../Shared/AuthField/AuthField'
import { AuthFieldType, AuthFieldIconType } from '../Shared/AuthField/AuthField.types'
import { Link } from 'react-router-dom'
import { AuthFormActions } from '../Shared/AuthFormActions/AuthFormActions'

export const Login: React.FC<LoginDispatch> = (props: LoginDispatch) =>
    <AuthForm<LoginState>
        Title="Login"
        Message="Sign in to Shopy"
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
        <AuthFormActions
            LeftActionName="Create account"
            LeftActionTo="register"
            RightActionName="Sign in"
        />
    </AuthForm >

