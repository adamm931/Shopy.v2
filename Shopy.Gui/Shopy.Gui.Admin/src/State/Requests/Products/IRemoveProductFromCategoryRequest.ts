import { IBaseRequest } from './../Base/IBaseRequest';

export interface IRemoveProductFromCategoryRequest extends IBaseRequest<IRemoveProductFromCategoryRequestPayload> {
}

export interface IRemoveProductFromCategoryRequestPayload {
    ProductExternalId: string
    CategoryExternalId: string
}