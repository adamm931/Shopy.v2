import { UserRegisterRequest } from './../Requests/Register';
import { takeLatest } from 'redux-saga/effects';
import { RequestTypes } from '../Requests/RequestTypes';

export function* WatchUserRegister() {
    yield takeLatest(RequestTypes.USER_REGISTER, UserRegister)
}

function* UserRegister(request: UserRegisterRequest) {
    console.log('WatchUserRegister', request)
}