import { IBaseRequest } from '../Base/IBaseRequest';
import { RequestTypes } from '../Base/RequestTypes';

export interface IEditProductRequest extends IBaseRequest<IEditProductRequestPayload> {
}

export interface IEditProductRequestPayload {
    ExternalId: string;
    Name: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
}