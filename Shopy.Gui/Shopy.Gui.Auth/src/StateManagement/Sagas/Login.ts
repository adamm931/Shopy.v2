import { UserLoginReqeust } from './../Requests/Login';
import { RequestTypes } from '../Requests/RequestTypes';
import { takeLatest } from 'redux-saga/effects'

export function* WatchUserLogin() {
    yield takeLatest(RequestTypes.USER_LOG_IN, UserLogin)
}

function* UserLogin(request: UserLoginReqeust) {
    console.log('WatchUserLogin', request)
}