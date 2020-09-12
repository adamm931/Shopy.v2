import { LoginResponse } from './../../Api/Models/LoginResponse';
import { AdminUrlEnv } from './../../Common/EnvVariables';
import { UserLoginReqeust } from '../Requests/Login';
import { RequestTypes } from '../Requests/RequestTypes';
import { takeLatest, call } from 'redux-saga/effects'
import AuthHelper from '../../Api/Helpers/AuthHelper';

export function* WatchUserLogin() {
    yield takeLatest(RequestTypes.USER_LOG_IN, UserLogin)
}

function* UserLogin(request: UserLoginReqeust) {

    const { Username, Password } = request.Payload

    const loginResponse: LoginResponse = yield call(() => AuthHelper.Login(Username, Password))

    if (loginResponse.IsAuthenticated) {
        // TODO: store token to cookie

        window.location.replace(AdminUrlEnv)
    }
}