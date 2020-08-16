import React from 'react'

const Register: React.FC = () => {
    return (
        <div className="login-box">
            <div className="login-logo">
                <a href="#"><span className="title-shopy">Shopy</span> - Register</a>
            </div>
            <div className="card">
                <div className="card-body login-card-body">
                    <p className="login-box-msg"><b>Register to our services</b></p>
                    <form action="../../index3.html" method="post">

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
                                <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">Cancel</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default Register