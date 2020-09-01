import { UserLoginReqeust } from '../Requests/Login';
import { RequestTypes } from '../Requests/RequestTypes';
import { takeLatest, call } from 'redux-saga/effects'
import Client from '../../Api/Client';
import { LoginUrl } from '../../Api/Urls';

export function* WatchUserLogin() {
    yield takeLatest(RequestTypes.USER_LOG_IN, UserLogin)
}

function* UserLogin(request: UserLoginReqeust) {

    const payload = request.Payload

    let response = yield call(() => Client.Post(LoginUrl, {
        Username: payload.Username,
        Password: payload.Password,
    }))

    console.log('Saga/login', response)
}