import { IBaseRequest } from './../Base/IBaseRequest';

export interface EditCategoryRequest extends IBaseRequest<EditCategoryRequestPayload> {
}

export interface EditCategoryRequestPayload {
    ExternalId: string;
    Name: string;
    Description: string;
}