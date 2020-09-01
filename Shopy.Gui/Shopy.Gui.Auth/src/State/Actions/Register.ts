import { ActionTypes } from "./ActionTypes";
import { BaseAction } from "./BaseAction";

export interface UserRegisteredAction extends BaseAction<UserRegisteredActionPayload> {
    type: typeof ActionTypes.USER_REGISTERED
}

export interface UserRegisteredActionPayload {
    Username: string
}