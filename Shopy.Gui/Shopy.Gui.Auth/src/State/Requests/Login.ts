import { RequestTypes } from "./RequestTypes";
import { BaseRequest } from "./BaseRequest";

export interface UserLoginReqeust extends BaseRequest<UserLoginRequestPayload> {
    type: typeof RequestTypes.USER_LOG_IN
}

export interface UserLoginRequestPayload {
    Username: string,
    Password: string
}