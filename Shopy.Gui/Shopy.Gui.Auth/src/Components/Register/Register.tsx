import React from 'react'
import { RegisterState, RegisterDispatch } from './Register.types'
import { AuthForm } from '../Shared/AuthForm/AuthForm'
import { AuthFieldType, AuthFieldIconType } from '../Shared/AuthField/AuthField.types'
import { Link } from 'react-router-dom'
import { AuthField } from '../Shared/AuthField/AuthField'
import { RegisterInitialValues, RegisterValidationSchema } from './Register.validation'

export const Register: React.FC<RegisterDispatch> = (props: RegisterDispatch) =>
    <AuthForm<RegisterState>
        Title="Register"
        Message="Please sign up to proceed"
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
        <div className="row">
            <div className="col-6">
                <button type="submit" className="btn btn-primary btn-block btn-shopy-primary">Register</button>
            </div>
            <div className="col-6">
                <Link to="/" className="btn btn-primary btn-block btn-shopy-secondary">Cancel</Link>
            </div>
        </div>
    </ AuthForm>