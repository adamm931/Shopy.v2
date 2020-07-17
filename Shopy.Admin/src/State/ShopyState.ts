import { IPagedListApiModel, EmptyPageList } from './../Service/Api/IPagedListApiModel';
import { Category } from './../Service/Categories/Models/Category';
import { INameExternalIdApiModel } from '../Service/Api/INameExternalIdApiModel';
import { AuthService } from './../Service/Auth/AuthService';
import { IProduct } from '../Service/Products/Models/IProduct';
import { IProductListItem } from '../Service/Products/Models/IProductListItem';

export interface IShopyState {
    IsUserLogged: boolean
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
    Name: ''
})

export const InitialState: IShopyState = {
    IsUserLogged: new AuthService().IsUserLogged(),
    ProductList: {},
    EditingProduct: EmptyEditingProduct(),
    ProductCategories: [],
    AvailableProductCategories: [],
    LookupCategories: [],
    Categories: [],
    EditingCategory: EmptyEditingCategory()
};

