import { IBaseRequest } from './../Base/IBaseRequest';

export interface IAddProductRequest extends IBaseRequest<IAddProductRequestPayload> {
}

export interface IAddProductRequestPayload {
    Name: string;
    Description: string;
    Price: number;
    Brand: string;
    Sizes: string[];
}