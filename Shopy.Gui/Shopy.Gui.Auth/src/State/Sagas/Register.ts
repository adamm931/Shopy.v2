import { UserRegisterRequest } from '../Requests/Register';
import { takeLatest, call } from 'redux-saga/effects';
import { RequestTypes } from '../Requests/RequestTypes';
import AuthHelper from '../../Helpers/AuthHelper'

export function* WatchUserRegister() {
    yield takeLatest(RequestTypes.USER_REGISTER, UserRegister)
}

function* UserRegister(request: UserRegisterRequest) {

    const { Username, Email, Password } = request.Payload

    let response = yield call(() => AuthHelper.Register(Username, Email, Password))

    console.log('Saga/register', response)
}