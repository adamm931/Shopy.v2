import React from 'react'
import { LoginFormProps } from '../../Types/Login/LoginForm'
import { Form } from '../Common/Form'
import { Input } from '../Common/Input'
import { InputType } from '../../Types/Common/Input'
import { InputIconType } from '../../Types/Common/InputIcon'
import { Link } from 'react-router-dom'

export const LoginForm: React.FC<LoginFormProps> = (props: LoginFormProps) =>
    <Form
        Title="Login"
        Message="Enter your credentials"
        OnSubmit={props.OnSubmit}
    >
        <Input
            Type={InputType.Text}
            IconType={InputIconType.Username}
            Placeholder="Username"
            OnChange={props.OnUsernameChange}
        />
        <Input
            Type={InputType.Password}
            IconType={InputIconType.Password}
            Placeholder="Password"
            OnChange={props.OnPasswordChange}
        />
        <div className="row">
            <div className="col-8">
                <Link to="/register" className="text-center register">Register</Link>
            </div>
            <div className="col-4">
                <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">Sign In</button>
            </div>
        </div>
    </Form>