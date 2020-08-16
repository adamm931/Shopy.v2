import React from 'react'

const Login: React.FC = () => {

    return (
        <div className="login-box">
            <div className="login-logo">
                <a href="#"><span className="title-shopy">Shopy</span> - Login</a>
            </div>
            <div className="card">
                <div className="card-body login-card-body">
                    <p className="login-box-msg"><b>Please sign to proceed</b></p>
                    <form action="../../index3.html" method="post">

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

                        <div className="row">
                            <div className="col-8">
                                <div className="icheck-primary">
                                    <input type="checkbox" id="remember" />
                                    <label htmlFor="remember">
                                        Remember Me
                                    </label>
                                </div>
                            </div>
                            <div className="col-4">
                                <button type="submit" className="btn btn-primary btn-block btn-shopy-secondary">Sign In</button>
                            </div>
                        </div>

                    </form>
                    <p className="mb-0">
                        <a href="#" className="text-center register">Register</a>
                    </p>
                </div>
            </div>
        </div>
    )
}

export default Login