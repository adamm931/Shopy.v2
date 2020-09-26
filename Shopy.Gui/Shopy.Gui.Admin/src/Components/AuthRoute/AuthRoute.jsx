import React from 'react'
import { Route } from 'react-router';
import { EnviromentUtils } from '../../Utils/EnviromentUtils'
import { AuthUtils } from '../../Utils/AuthUtils'

export const AuthRoute = ({ component: Component, ...rest }) => <Route {...rest} render={props => {
    return AuthUtils.IsAuthenticated
        ? <Component {...props} />
        : window.location.replace(EnviromentUtils.LoginUrl);
}} />