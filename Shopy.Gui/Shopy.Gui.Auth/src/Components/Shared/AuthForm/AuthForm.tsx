import React from 'react'
import { Formik, Form } from 'formik';
import { AuthFormProps } from './AuthForm.types'

export class AuthForm<FormState> extends React.Component<AuthFormProps<FormState>> {
    render() {
        return (
            <Formik
                onSubmit={this.props.OnSubmit}
                initialValues={this.props.InitialValues}
                validationSchema={this.props.ValidationSchema}
            >
                <div className="login-box" >
                    <div className="login-logo">
                        <span className="title-shopy">{this.props.Title}</span>
                    </div>
                    <div className="card">
                        <div className="card-body login-card-body">
                            <p className="login-box-msg"><b>{this.props.Message}</b></p>
                            <Form>
                                {this.props.children}
                            </Form>
                        </div>
                    </div>
                </div>
            </Formik>
        )
    }
}
