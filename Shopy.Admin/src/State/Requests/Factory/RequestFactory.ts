import { DeleteCategoryRequest } from './../Categories/DeleteCategoryRequest';
import { GetCategoryRequest } from './../Categories/GetCategoryRequest';
import { CategoriesListRequest } from './../Categories/CategoriesListRequest';
import { EditCategoryRequest } from './../Categories/EditCategoryRequest';
import { AddCategoryRequest } from './../Categories/AddCategoryRequest';
import { IUploadProductImageRequest } from './../Products/IUploadProductImageRequest';
import { IGetProductCategoriesRequest } from './../Products/IGetProductCategoriesRequest';
import { IRemoveProductFromCategoryRequest } from './../Products/IRemoveProductFromCategoryRequest';
import { IAddProductToCategoryRequest } from './../Products/IAddProductToCategoryRequest';
import { IDeleteProductRequest } from './../Products/IDeleteProductRequest';
import { IEditProductRequest } from './../Products/IEditProductRequest';
import { IGetProductRequest } from './../Products/IGetPropductRequest';
import { IProductsListRequest } from '../Products/IProductsListRequest';
import { IAddProductRequest } from './../Products/IAddProductRequest';
import { ILoginUserRequest } from './../Login/ILoginUserRequest';
import { RequestTypes } from '../Base/RequestTypes';
import { ILookupCategoriesRequest } from './../Categories/ILookupCategoriesRequest'

// Login
export const LoginUserRequest = (username: string, password: string): ILoginUserRequest => ({
    Payload: {
        Username: username,
        Password: password
    },
    type: RequestTypes.LOGIN_USER
} as ILoginUserRequest)

// Products
export const AddProductRequest = (name: string, description: string, price: number, brand: string, sizes: string[]): IAddProductRequest => ({
    Payload: {
        Caption: name,
        Description: description,
        Price: price,
        Brand: brand,
        Sizes: sizes,
    },
    type: RequestTypes.ADD_PRODUCT
})

export const EditProductRequest = (externalId: string, name: string, description: string, price: number, brand: string, sizes: string[]): IEditProductRequest => ({
    Payload: {
        ExternalId: externalId,
        Caption: name,
        Description: description,
        Price: price,
        Brand: brand,
        Sizes: sizes,
    },
    type: RequestTypes.EDIT_PRODUCT
})

export const DeleteProductRequest = (externalId: string): IDeleteProductRequest => ({
    Payload: {
        ExternalId: externalId
    },
    type: RequestTypes.DELETE_PRODUCT
})

export const ListProductsRequest = (): IProductsListRequest => ({
    Payload: {},
    type: RequestTypes.LIST_PRODUCTS
})

export const GetProductRequest = (externalId: string): IGetProductRequest => ({
    Payload: {
        ExternalId: externalId
    },
    type: RequestTypes.GET_PRODUCT
})

export const AddProductToCategory = (productExternalId: string, categoryExternalId: string): IAddProductToCategoryRequest => ({
    Payload: {
        ProductExternalId: productExternalId,
        CategoryExternalId: categoryExternalId
    },
    type: RequestTypes.ADD_PRODUCT_TO_CATEGORY
})

export const RemoveProductFromCategory = (productExternalId: string, categoryExternalId: string): IRemoveProductFromCategoryRequest => ({
    Payload: {
        ProductExternalId: productExternalId,
        CategoryExternalId: categoryExternalId
    },
    type: RequestTypes.REMOVE_PRODUCT_FROM_CATEGORY
})

export const GetProductCategories = (productExternalId: string): IGetProductCategoriesRequest => ({
    Payload: {
        ExternalId: productExternalId
    },
    type: RequestTypes.GET_PRODUCT_CATEGORIES
})

export const LookupCategories = (): ILookupCategoriesRequest => ({
    Payload: {},
    type: RequestTypes.LOOKUP_CATEGORIES
})

export const UploadProductImages = (productExternalId: string, images: File[]): IUploadProductImageRequest => ({
    Payload: {
        ProductExternalId: productExternalId,
        Images: images
    },
    type: RequestTypes.UPLOAD_PRODUCT_IMAGES
})

// Categories

export const AddCategory = (name: string): AddCategoryRequest => ({
    Payload: {
        Name: name
    },
    type: RequestTypes.ADD_CATEGORY
})

export const EditCategory = (externalId: string, name: string): EditCategoryRequest => ({
    Payload: {
        ExternalId: externalId,
        Name: name
    },
    type: RequestTypes.EDIT_CATEGORY
})

export const ListCategories = (): CategoriesListRequest => ({
    Payload: {},
    type: RequestTypes.LIST_CATEGORIES
})

export const GetCategory = (externalId: string): GetCategoryRequest => ({
    Payload: {
        ExternalId: externalId
    },
    type: RequestTypes.GET_CATEGORY
})

export const DeleteCategory = (externalId: string): DeleteCategoryRequest => ({
    Payload: {
        ExternalId: externalId
    },
    type: RequestTypes.DELETE_CATEGORY
})