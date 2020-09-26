import { IPagedListApiModel } from './../Service/Api/IPagedListApiModel';
import { Category } from './../Service/Categories/Models/Category';
import { INameExternalIdApiModel } from '../Service/Api/INameExternalIdApiModel';
import { IProduct } from '../Service/Products/Models/IProduct';
import { IProductListItem } from '../Service/Products/Models/IProductListItem';

export interface IShopyState {
    ProductList: IPagedListApiModel<IProductListItem>
    EditingProduct: IProduct
    RedirectTo?: string
    ProductCategories: INameExternalIdApiModel[],
    AvailableProductCategories: INameExternalIdApiModel[],
    LookupCategories: INameExternalIdApiModel[],
    Categories: Category[],
    EditingCategory: Category
}

export const EmptyEditingProduct = (): IProduct => ({
    ExternalId: '',
    Name: '',
    Description: '',
    Price: 0,
    Brand: '',
    Sizes: []
})

export const EmptyEditingCategory = (): Category => ({
    ExternalId: '',
    Name: '',
    Description: ''
})

export const InitialState: IShopyState = {
    ProductList: {},
    EditingProduct: EmptyEditingProduct(),
    ProductCategories: [],
    AvailableProductCategories: [],
    LookupCategories: [],
    Categories: [],
    EditingCategory: EmptyEditingCategory()
};

