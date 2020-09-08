import React from 'react'
import { RegisterState, RegisterDispatch } from './Register.types'
import { AuthForm } from '../Shared/AuthForm/AuthForm'
import { AuthFieldType, AuthFieldIconType } from '../Shared/AuthField/AuthField.types'
import { Link } from 'react-router-dom'
import { AuthField } from '../Shared/AuthField/AuthField'
import { RegisterInitialValues, RegisterValidationSchema } from './Register.validation'
import { AuthFormActions } from '../Shared/AuthFormActions/AuthFormActions'

export const Register: React.FC<RegisterDispatch> = (props: RegisterDispatch) =>
    <AuthForm<RegisterState>
        Title="Register"
        Message="Create your account"
        InitialValues={RegisterInitialValues}
        ValidationSchema={RegisterValidationSchema}
        OnSubmit={props.Register}>
        <AuthField
            Name="Email"
            Placeholder="Enter email"
            Type={AuthFieldType.Text}
            IconType={AuthFieldIconType.Email}
        />
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
        <AuthField
            Name="ConfirmPassword"
            Placeholder="Enter confirm password"
            Type={AuthFieldType.Password}
            IconType={AuthFieldIconType.Password}
        />
        <AuthFormActions
            LeftActionName="Go to login"
            LeftActionTo="login"
            RightActionName="Register"
        />
    </ AuthForm>