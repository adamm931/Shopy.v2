import { IPagedListApiModel } from './../Api/IPagedListApiModel';
import { IProductApiModel } from './Models/IProductApiModel';
import { IRemoveProductFromCategoryRequestPayload } from './../../State/Requests/Products/IRemoveProductFromCategoryRequest';
import { IAddProductToCategoryRequestPayload } from './../../State/Requests/Products/IAddProductToCategoryRequest';
import { INameExternalIdApiModel } from '../Api/INameExternalIdApiModel';
import { IDeleteProductRequestPayload } from './../../State/Requests/Products/IDeleteProductRequest';
import { IProduct } from './Models/IProduct'
import { IEditProductRequestPayload } from './../../State/Requests/Products/IEditProductRequest';
import { IAddProductRequestPayload } from './../../State/Requests/Products/IAddProductRequest';
import { Post, Get, Put, Delete } from '../Api/ShopyClient';
import { IProductListItem } from './Models/IProductListItem';
import { IGetProductRequestPayload } from '../../State/Requests/Products/IGetPropductRequest';

export class ProductsService {

    public static AddProduct = async (product: IAddProductRequestPayload): Promise<any> =>
        await Post<any, IAddProductRequestPayload>("/products/add", product)

    public static EditProduct = async (product: IEditProductRequestPayload): Promise<any> =>
        await Put<any, IEditProductRequestPayload>(`/products/edit`, product);

    public static DeleteProduct = async (product: IDeleteProductRequestPayload): Promise<any> =>
        await Delete<any>(`/products/${product.ExternalId}/delete`)

    public static ListProducts = async (): Promise<IPagedListApiModel<IProductListItem>> =>
        await Get<IPagedListApiModel<IProductListItem>>("/products")

    public static GetProductCategories = async (externalId: string): Promise<INameExternalIdApiModel[]> =>
        await Get<INameExternalIdApiModel[]>(`/products/${externalId}/categories`)

    public static AddProductToCategory = async (request: IAddProductToCategoryRequestPayload): Promise<any> =>
        await Post<any, {}>(`/products/add-to-category`, request);

    public static RemoveProductFromCategory = async (request: IRemoveProductFromCategoryRequestPayload): Promise<any> =>
        await Post<any, {}>(`/products/remove-from-category`, request);

    public static GetProduct = async (request: IGetProductRequestPayload): Promise<IProduct> => {
        var apiProduct = await Get<IProductApiModel>(`/products/${request.ExternalId}/get`)
        return {
            ExternalId: apiProduct.ExternalId,
            Name: apiProduct.Name,
            Description: apiProduct.Description,
            Price: apiProduct.Price,
            Sizes: apiProduct.Sizes.map(model => model.Name),
            Brand: apiProduct.Brand.Name
        }
    }

    public static UploadImage = async (imageFile: File, externalId: string, imageName: string) => {

        let reader = new FileReader()

        reader.readAsDataURL(imageFile)

        reader.onload = async function () {

            var base64String = reader.result?.toString().split('base64,')[1];

            await Post<{}, any>("products/uploadImage", {
                Base64String: base64String,
                ExternalId: externalId,
                ImageName: imageName
            })
        }



    }
}