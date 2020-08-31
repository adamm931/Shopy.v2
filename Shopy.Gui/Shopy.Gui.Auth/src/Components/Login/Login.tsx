import React, { FormEvent, ChangeEvent } from 'react'
import { LoginState, LoginDispatch, InitLoginState } from '../../Types/Login/Login'
import { LoginForm } from './LoginForm'
import { BaseComponent } from '../Base/BaseComponent'

export default class Login extends BaseComponent<LoginDispatch, LoginState> {

    state = InitLoginState()

    login = () => this.props.Login(
        this.state.Username,
        this.state.Password)

    render() {
        return (
            <LoginForm
                OnUsernameChange={event => this.onInputChange(event, "Username")}
                OnPasswordChange={event => this.onInputChange(event, "Password")}
                OnSubmit={event => this.onSubmit(event, this.login)}
            />
        )
    }
}

