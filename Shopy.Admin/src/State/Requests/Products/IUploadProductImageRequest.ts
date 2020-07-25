import { IBaseRequest } from './../Base/IBaseRequest';

export interface IUploadProductImageRequest extends IBaseRequest<IUploadProductImageRequestPayload> {
}

export interface IUploadProductImageRequestPayload {
    ProductExternalId: string
    Images: File[]
}