import { UserRegisterRequest } from '../Requests/Register';
import { takeLatest, call } from 'redux-saga/effects';
import { RequestTypes } from '../Requests/RequestTypes';
import AuthHelper from '../../Api/Helpers/AuthHelper'

export function* WatchUserRegister() {
    yield takeLatest(RequestTypes.USER_REGISTER, UserRegister)
}

function* UserRegister(request: UserRegisterRequest) {

    const { Username, Email, Password } = request.Payload

    yield call(() => AuthHelper.Register(Username, Email, Password))
}