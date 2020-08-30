import { Action } from 'redux';

export interface BaseAction<TPayload> extends Action<string> {
    Payload: TPayload
}