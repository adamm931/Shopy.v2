import { AuthReducer } from './Reducer'
import { createStore } from 'redux'
import { createBrowserHistory } from 'history'

export const history = createBrowserHistory()

export const store = createStore(AuthReducer)