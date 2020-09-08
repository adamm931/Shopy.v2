import { UserLoginReqeust } from '../Requests/Login';
import { RequestTypes } from '../Requests/RequestTypes';
import { takeLatest, call } from 'redux-saga/effects'
import AuthHelper from '../../Helpers/AuthHelper';

export function* WatchUserLogin() {
    yield takeLatest(RequestTypes.USER_LOG_IN, UserLogin)
}

function* UserLogin(request: UserLoginReqeust) {

    const { Username, Password } = request.Payload

    let response = yield call(() => AuthHelper.Login(Username, Password))

    console.log('Saga/login', response)
}