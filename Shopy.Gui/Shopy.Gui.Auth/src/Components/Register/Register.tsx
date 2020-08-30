import React, { FormEvent, ChangeEvent, Dispatch } from 'react'
import { RegisterForm } from './RegisterForm'
import { RegisterState, RegisterDispatch, InitRegisterState } from '../../Types/Register/Register'
import { BaseComponent } from '../Base/BaseComponent'
import { connect } from 'react-redux'
import { ActionCreator } from '../../StateManagement/Actions/ActionCreator'

class Register extends BaseComponent<RegisterDispatch, RegisterState> {

    constructor(props: any) {
        super(props)
        this.state = InitRegisterState()
    }

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

const mapDispatchToProps = (dispatch: any): RegisterDispatch => ({
    Register: (username: string, email: string, password: string) => dispatch(ActionCreator.UserRegistered(username))
})

export default connect(null, mapDispatchToProps)(Register)