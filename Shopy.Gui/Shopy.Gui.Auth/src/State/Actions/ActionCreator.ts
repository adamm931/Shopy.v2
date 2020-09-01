import { UserLoggedInAction as UserLoggedInAction } from "./Login"
import { UserRegisteredAction } from "./Register"
import { ActionTypes } from "./ActionTypes"

export class ActionCreator {

    static UserLoggedIn = (username: string): UserLoggedInAction => <UserLoggedInAction>{
        type: ActionTypes.USER_LOGGED_IN,
        Payload: {
            Username: username
        }
    }

    static UserRegistered = (username: string): UserRegisteredAction => <UserRegisteredAction>{
        type: ActionTypes.USER_REGISTERED,
        Payload: {
            Username: username
        }
    }
}
