import React from 'react'
import { RegisterForm } from './RegisterForm'
import { RegisterState, RegisterDispatch, InitRegisterState } from '../../Types/Register/Register'
import { BaseComponent } from '../Base/BaseComponent'

export default class Register extends BaseComponent<RegisterDispatch, RegisterState> {

    state = InitRegisterState()

    register = () => this.props.Register(
        this.state.Username,
        this.state.Email,
        this.state.Password)

    render() {
        return (
            <RegisterForm
                OnSubmit={event => this.onSubmit(event, this.register)}
                OnEmailChange={(event) => this.onInputChange(event, "Email")}
                OnUsernameChange={(event) => this.onInputChange(event, "Username")}
                OnPasswordChange={(event) => this.onInputChange(event, "Password")}
                OnConfirmPasswordChange={(event) => this.onInputChange(event, "ConfirmPassword")}
            />
        )
    }
}