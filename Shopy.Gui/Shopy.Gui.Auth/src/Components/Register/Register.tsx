import React, { FormEvent, ChangeEvent } from 'react'
import { RegisterForm } from './RegisterForm'
import { NameOf } from '../../Utils/NameOf'
import { RegisterState } from '../../Types/Register/Register'
import { BaseComponent } from '../Base/BaseComponent'

class Register extends BaseComponent<{}, RegisterState> {

    constructor(props: any) {
        super(props)

        this.state = {
            Email: '',
            Username: '',
            Password: '',
            ConfirmPassword: ''
        }
    }

    onSubmit = (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        console.log('state', this.state)
    }

    render() {
        return (
            <RegisterForm
                OnSubmit={this.onSubmit}
                OnEmailChange={(event) => this.onChange(event, NameOf<RegisterState>("Email"))}
                OnUsernameChange={(event) => this.onChange(event, NameOf<RegisterState>("Username"))}
                OnPasswordChange={(event) => this.onChange(event, NameOf<RegisterState>("Password"))}
                OnConfirmPasswordChange={(event) => this.onChange(event, NameOf<RegisterState>("ConfirmPassword"))}
            />
        )
    }
}

export default Register