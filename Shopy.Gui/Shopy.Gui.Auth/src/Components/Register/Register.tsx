import React, { Component } from 'react'
import { RegisterState } from './RegisterState'
import { Link } from 'react-router-dom'
import { Icon, IconType } from '../Common/Icon'
import { Input, InputType } from '../Common/Input'

class Register extends Component<{}, RegisterState> {

    render() {

        return (
            <div className="login-box">
                <div className="login-logo">
                    <span className="title-shopy">Register</span>
                </div>
                <div className="card">
                    <div className="card-body login-card-body">
                        <p className="login-box-msg"><b>Please sign up to proceed</b></p>
                        <form onSubmit={(event) => console.log(event)}>
                            <Input
                                Type={InputType.Text}
                                IconType={IconType.Email}
                                Placeholder="Email"
                                OnChange={(event) => console.log(event)}
                            />
                            <Input
                                Type={InputType.Text}
                                IconType={IconType.Username}
                                Placeholder="Username"
                                OnChange={(event) => console.log(event)}
                            />
                            <Input
                                Type={InputType.Password}
                                IconType={IconType.Password}
                                Placeholder="Password"
                                OnChange={(event) => console.log(event)}
                            />
                            <Input
                                Type={InputType.Password}
                                IconType={IconType.Password}
                                Placeholder="Confirm password"
                                OnChange={(event) => console.log(event)}
                            />
                            <div className="row">
                                <div className="col-6">
                                    <button type="submit" className="btn btn-primary btn-block btn-shopy-primary">Register</button>
                                </div>
                                <div className="col-6">
                                    <Link to="/" className="btn btn-primary btn-block btn-shopy-secondary">Cancel</Link>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        )

    }
}

export default Register