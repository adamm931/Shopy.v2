import { AuthReducer } from './Reducer'
import { createStore, applyMiddleware } from 'redux'
import { createBrowserHistory } from 'history'
import { routerMiddleware } from 'react-router-redux';
import createSagaMiddleware from 'redux-saga'
import { RunSaga } from './AuthWatcher'

export const history = createBrowserHistory()

const saga = createSagaMiddleware()
const router = routerMiddleware(history)
const middleware = applyMiddleware(saga, router)

export const store = createStore(AuthReducer, middleware)

saga.run(RunSaga)