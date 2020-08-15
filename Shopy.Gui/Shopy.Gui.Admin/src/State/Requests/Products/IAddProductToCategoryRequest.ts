import { IBaseRequest } from './../Base/IBaseRequest';

export interface IAddProductToCategoryRequest extends IBaseRequest<IAddProductToCategoryRequestPayload> {
}

export interface IAddProductToCategoryRequestPayload {
    ProductExternalId: string
    CategoryExternalId: string
}