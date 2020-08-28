import React, { FormEvent, ChangeEvent } from 'react'
import { LoginState } from '../../Types/Login/Login'
import { LoginForm } from './LoginForm'
import { BaseComponent } from '../Base/BaseComponent'
import { NameOf } from '../../Utils/NameOf'

class Login extends BaseComponent<{}, LoginState> {

    constructor(props: any) {
        super(props)

        this.state = {
            Username: '',
            Password: ''
        }
    }

    onSubmit = (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log('state', this.state)
    }

    render() {
        return (
            <LoginForm
                OnUsernameChange={event => this.onChange(event, NameOf<LoginState>("Username"))}
                OnPasswordChange={event => this.onChange(event, NameOf<LoginState>("Password"))}
                OnSubmit={this.onSubmit}
            />
        )
    }
}

export default Login