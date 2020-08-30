import { UserLoggedInAction } from "./Login";
import { UserRegisteredAction } from "./Register";

export enum ActionTypes {
    USER_LOGGED_IN = "@Actions/UserLoggedIn",
    USER_REGISTERED = "@Actions/UserRegistered"
}

export type ActionType = UserRegisteredAction | UserLoggedInAction 