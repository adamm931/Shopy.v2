import { ActionTypes } from "./ActionTypes";
import { BaseAction } from "./BaseAction";

export interface UserLoggedInAction extends BaseAction<UserLoggedInActionPayload> {
    type: typeof ActionTypes.USER_LOGGED_IN
}

export interface UserLoggedInActionPayload {
    Username: string
}