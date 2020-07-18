import { DeleteCategoryRequestPayload } from './../../State/Requests/Categories/DeleteCategoryRequest';
import { GetCategoryRequestPayload } from './../../State/Requests/Categories/GetCategoryRequest';
import { Category } from './Models/Category';
import { EditCategoryRequestPayload } from './../../State/Requests/Categories/EditCategoryRequest';
import { AddCategoryRequestPayload } from './../../State/Requests/Categories/AddCategoryRequest';
import { INameExternalIdApiModel } from '../Api/INameExternalIdApiModel';
import { Get, Post, Put, Delete } from '../Api/ShopyClient';

export class CategoryService {
    public static Lookup = async (): Promise<INameExternalIdApiModel[]> =>
        await Get<INameExternalIdApiModel[]>("/categories/lookup")

    public static Add = async (data: AddCategoryRequestPayload): Promise<{}> =>
        await Post<{}, AddCategoryRequestPayload>("/categories/add", data)

    public static Edit = async (data: EditCategoryRequestPayload): Promise<{}> =>
        await Put<{}, AddCategoryRequestPayload>(`/categories/${data.ExternalId}/edit`, data)

    public static Get = async (data: GetCategoryRequestPayload): Promise<{}> =>
        await Get<Category>(`/categories/${data.ExternalId}/get`)

    public static Delete = async (data: DeleteCategoryRequestPayload): Promise<{}> =>
        await Delete<{}>(`/categories/${data.ExternalId}/delete`)

    // TODO: create new endpoint 
    public static List = async (): Promise<Category[]> =>
        await Get<Category[]>("/categories/lookup");
}