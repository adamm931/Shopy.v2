import { UserRegisterRequest } from '../Requests/Register';
import { takeLatest, call } from 'redux-saga/effects';
import { RequestTypes } from '../Requests/RequestTypes';
import { RegisterUrl } from '../../Api/Urls';
import Client from '../../Api/Client';

export function* WatchUserRegister() {
    yield takeLatest(RequestTypes.USER_REGISTER, UserRegister)
}

function* UserRegister(request: UserRegisterRequest) {
    const payload = request.Payload

    let response = yield call(() => Client.Post(RegisterUrl, {
        Username: payload.Username,
        Email: payload.Email,
        Password: payload.Password,
    }))

    console.log('Saga/register', response)
}