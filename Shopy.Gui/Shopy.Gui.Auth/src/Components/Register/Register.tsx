import React from 'react'
import { Link } from 'react-router-dom'

const Register: React.FC = () => {
    return (
        <div className="login-box">
            <div className="login-logo">
                <span className="title-shopy">Register</span>
            </div>
            <div className="card">
                <div className="card-body login-card-body">
                    <p className="login-box-msg"><b>Please sign up to proceed</b></p>
                    <form method="post">

                        <div className="input-group mb-3">
                            <input type="email" className="form-control" placeholder="Email" />
                            <div className="input-group-append">
                                <div className="input-group-text">
                                    <span className="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>

                        <div className="input-group mb-3">
                            <input type="text" className="form-control" placeholder="Username" />
                            <div className="input-group-append">
                                <div className="input-group-text">
                                    <span className="fas fa-user"></span>
                                </div>
                            </div>
                        </div>

                        <div className="input-group mb-3">
                            <input type="password" className="form-control" placeholder="Password" />
                            <div className="input-group-append">
                                <div className="input-group-text">
                                    <span className="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>

                        <div className="input-group mb-3">
                            <input type="confirm_password" className="form-control" placeholder="Confirm password" />
                            <div className="input-group-append">
                                <div className="input-group-text">
                                    <span className="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>

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

export default Register