import React from 'react'
import { Input } from '../Common/Input'
import { Form } from '../Common/Form'
import { Link } from 'react-router-dom'
import { InputType } from '../../Types/Common/Input'
import { InputIconType } from '../../Types/Common/InputIcon'
import { RegisterFormProps } from '../../Types/Register/RegisterForm'

export const RegisterForm: React.FC<RegisterFormProps> = (props: RegisterFormProps) =>
    <Form
        Title="Register"
        Message="Please sign up to proceed"
        OnSubmit={props.OnSubmit}
    >
        <Input
            Type={InputType.Text}
            IconType={InputIconType.Email}
            Placeholder="Email"
            OnChange={props.OnEmailChange}
        />
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
        <Input
            Type={InputType.Password}
            IconType={InputIconType.Password}
            Placeholder="Confirm password"
            OnChange={props.OnConfirmPasswordChange}
        />
        <div className="row">
            <div className="col-6">
                <button type="submit" className="btn btn-primary btn-block btn-shopy-primary">Register</button>
            </div>
            <div className="col-6">
                <Link to="/" className="btn btn-primary btn-block btn-shopy-secondary">Cancel</Link>
            </div>
        </div>
    </Form>