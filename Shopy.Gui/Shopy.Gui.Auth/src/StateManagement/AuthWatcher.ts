import { WatchUserLogin } from './Sagas/Login'
import { WatchUserRegister } from './Sagas/Register'
import { all } from 'redux-saga/effects'

export function* RunSaga() {
    yield all([
        WatchUserLogin(),
        WatchUserRegister()
    ])
}