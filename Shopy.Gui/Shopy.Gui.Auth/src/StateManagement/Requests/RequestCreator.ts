import { UserLoginReqeust } from "./Login";
import { RequestTypes } from "./RequestTypes";
import { UserRegisterRequest } from "./Register";

export class RequestCreator {
    static UserLogin = (username: string, password: string): UserLoginReqeust => <UserLoginReqeust>{
        type: RequestTypes.USER_LOG_IN,
        Payload: {
            Username: username,
            Password: password
        }
    }
    static UserRegister = (username: string, email: string, password: string): UserRegisterRequest => <UserRegisterRequest>{
        type: RequestTypes.USER_REGISTER,
        Payload: {
            Username: username,
            Email: email,
            Password: password
        }
    }
}