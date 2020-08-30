import { ActionType, ActionTypes } from './Actions/ActionTypes';
import { AuthState, initializeState } from "./AuthState";

export const AuthReducer = (state: AuthState = initializeState(), action: ActionType): AuthState => {

    console.log('AuthReducer', action)

    switch (action.type) {
        case ActionTypes.USER_LOGGED_IN: {
            return {
                ...state,
                LoggedInUser: action.Payload.Username
            }
        }
        case ActionTypes.USER_REGISTERED: {
            return {
                ...state,
                RegisteredUser: action.Payload.Username
            }
        }
        default: {
            return state;
        }
    }
}