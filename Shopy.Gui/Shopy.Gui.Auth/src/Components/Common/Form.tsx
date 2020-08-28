import React from 'react'
import { FormProps } from '../../Types/Common/Form'

export class Form extends React.Component<FormProps> {
    render() {
        return (
            <div className="login-box" >
                <div className="login-logo">
                    <span className="title-shopy">{this.props.Title}</span>
                </div>
                <div className="card">
                    <div className="card-body login-card-body">
                        <p className="login-box-msg"><b>{this.props.Message}</b></p>
                        <form onSubmit={this.props.OnSubmit}>
                            {this.props.children}
                        </form>
                    </div>
                </div>
            </div>
        )
    }
}
