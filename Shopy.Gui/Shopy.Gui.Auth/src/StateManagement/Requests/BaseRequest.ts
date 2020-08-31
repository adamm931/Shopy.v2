import { Action } from "redux";

export interface BaseRequest<TPayload> extends Action<string> {
    Payload: TPayload
}