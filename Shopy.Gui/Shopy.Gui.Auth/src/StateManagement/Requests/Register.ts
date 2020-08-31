import { BaseRequest } from "./BaseRequest";
import { RequestTypes } from "./RequestTypes";

export interface UserRegisterRequest extends BaseRequest<UserRegisterRequestPayload> {
    type: typeof RequestTypes.USER_REGISTER
}

export interface UserRegisterRequestPayload {
    Username: string,
    Email: string,
    Password: string
}