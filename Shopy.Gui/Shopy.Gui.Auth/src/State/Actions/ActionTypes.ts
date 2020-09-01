import { UserLoggedInAction } from "./Login";
import { UserRegisteredAction } from "./Register";

export enum ActionTypes {
    USER_LOGGED_IN = "@Action/UserLoggedIn",
    USER_REGISTERED = "@Action/UserRegistered"
}

export type ActionType = UserRegisteredAction | UserLoggedInAction 