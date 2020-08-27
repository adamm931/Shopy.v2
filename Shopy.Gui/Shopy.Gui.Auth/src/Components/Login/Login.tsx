import React, { FormEvent, Component, ChangeEvent } from 'react'
import { Link } from 'react-router-dom'
import { LoginState } from './LoginState'
import { IconType } from '../Common/Icon'
import { Input, InputType } from '../Common/Input'

class Login extends Component<{}, LoginState> {

    constructor(props: any) {
        super(props)

        this.state = {
            Username: '',
            Password: ''
        }
    }

    onUsernameChange = (event: ChangeEvent<HTMLInputElement>) => {
        event.preventDefault()
        this.setState({
            ...this.state,
            Password: event.target.value
        })
    }

    onPasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
        event.preventDefault()
        this.setState({
            ...this.state,
            Username: event.target.value
        })
    }

    onSubmit = (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault()
        console.log('state', this.state)
    }

    render() {
        return (
            <div className="login-box" >
                <div className="login-logo">
                    <span className="title-shopy">Login</span>
                </div>
                <div className="card">
                    <div className="card-body login-card-body">
                        <p className="login-box-msg"><b>Please sign to proceed</b></p>
                        <form onSubmit={this.onSubmit}>
                            <Input
                                Type={InputType.Text}
                                IconType={IconType.Username}
                                Placeholder="Username"
                                OnChange={this.onUsernameChange}
                            />
                            <Input
                                Type={InputType.Password}
                                IconType={IconType.Password}
                                Placeholder="Password"
                                OnChange={this.onPasswordChange}
                            />
                            <div className="row">
                                <div className="col-8">
                                    <Link to="/register" className="text-center register">Register</Link>
                                </div>
                                <div className="col-4">
                                    <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">Sign In</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}

export default Login