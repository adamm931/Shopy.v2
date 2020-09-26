import { UserRegisterRequest } from '../Requests/Register';
import { takeLatest, call } from 'redux-saga/effects';
import { RequestTypes } from '../Requests/RequestTypes';
import AuthApi from '../../Api/AuthApi'

export function* WatchUserRegister() {
    yield takeLatest(RequestTypes.USER_REGISTER, UserRegister)
}

function* UserRegister(request: UserRegisterRequest) {

    const { Username, Email, Password } = request.Payload

    yield call(() => AuthApi.Register(Username, Email, Password))
}