import { DeleteCategoryRequest } from './Requests/Categories/DeleteCategoryRequest';
import { GetCategoryRequest } from './Requests/Categories/GetCategoryRequest';
import { Category } from './../Service/Categories/Models/Category';
import { EditCategoryRequest } from './Requests/Categories/EditCategoryRequest';
import { AddCategoryRequest } from './Requests/Categories/AddCategoryRequest';
import { IUploadProductImageRequest } from './Requests/Products/IUploadProductImageRequest';
import { CategoryService } from './../Service/Categories/CategoryService';
import { INameExternalIdApiModel } from '../Service/Api/INameExternalIdApiModel';
import { IDeleteProductRequest } from './Requests/Products/IDeleteProductRequest';
import { IProduct } from '../Service/Products/Models/IProduct'
import { IGetProductRequest } from './Requests/Products/IGetPropductRequest';
import { IEditProductRequest } from './Requests/Products/IEditProductRequest';
import { IProductListItem } from '../Service/Products/Models/IProductListItem';
import { ProductsService } from '../Service/Products/ProductsService';
import { IAddProductRequest } from './Requests/Products/IAddProductRequest';
import { RequestTypes } from './Requests/Base/RequestTypes';
import { ILoginUserRequest } from './Requests/Login/ILoginUserRequest';
import { all, put, takeLatest, call } from 'redux-saga/effects'
import * as ActionFactory from './Actions/Factory/ActionFactory';
import { IProductsListRequest } from './Requests/Products/IProductsListRequest';
import { Routes } from '../Enums/Routes';
import { IAddProductToCategoryRequest } from './Requests/Products/IAddProductToCategoryRequest';
import { IRemoveProductFromCategoryRequest } from './Requests/Products/IRemoveProductFromCategoryRequest';
import { CategoriesListRequest } from './Requests/Categories/CategoriesListRequest';
import { IPagedListApiModel } from '../Service/Api/IPagedListApiModel';

function* WatchProductAdd() {
    yield takeLatest(RequestTypes.ADD_PRODUCT, AddProduct)
}

function* WatchProductEdit() {
    yield takeLatest(RequestTypes.EDIT_PRODUCT, EditProduct)
}

function* WatchProductDelete() {
    yield takeLatest(RequestTypes.DELETE_PRODUCT, DeleteProduct)
}

function* WatchProductGet() {
    yield takeLatest(RequestTypes.GET_PRODUCT, GetProduct)
}

function* WatchProductList() {
    yield takeLatest(RequestTypes.LIST_PRODUCTS, ListProducts)
}

function* WatchProductGetCategories() {
    yield takeLatest(RequestTypes.GET_PRODUCT_CATEGORIES, GetProductCategories)
}

function* WatchProductAddToCategory() {
    yield takeLatest(RequestTypes.ADD_PRODUCT_TO_CATEGORY, AddProductToCategory)
}

function* WatchProductRemoveFromCategory() {
    yield takeLatest(RequestTypes.REMOVE_PRODUCT_FROM_CATEGORY, RemoveProductFromCategory)
}

function* WatchCategoriesLookup() {
    yield takeLatest(RequestTypes.LOOKUP_CATEGORIES, LookupCategories)
}

function* WatchUploadProductImages() {
    yield takeLatest(RequestTypes.UPLOAD_PRODUCT_IMAGES, UploadProductImages)
}

function* WatchCategoryAdd() {
    yield takeLatest(RequestTypes.ADD_CATEGORY, AddCategory)
}

function* WatchCategoryEdit() {
    yield takeLatest(RequestTypes.EDIT_CATEGORY, EditCategory)
}

function* WatchCategoryList() {
    yield takeLatest(RequestTypes.LIST_CATEGORIES, ListCategories)
}

function* WatchCategoryGet() {
    yield takeLatest(RequestTypes.GET_CATEGORY, GetCategory)
}

function* WatchCategoryDelete() {
    yield takeLatest(RequestTypes.DELETE_CATEGORY, DeleteCategory)
}

function* AddProduct(request: IAddProductRequest) {
    yield call(() => ProductsService.AddProduct(request.Payload));
    yield put(ActionFactory.Redirect(Routes.Products.Root))
}

function* EditProduct(request: IEditProductRequest) {
    yield call(() => ProductsService.EditProduct(request.Payload));
    yield put(ActionFactory.Redirect(Routes.Products.Root))
}

function* GetProduct(request: IGetProductRequest) {
    var product: IProduct = yield call(() => ProductsService.GetProduct(request.Payload));
    yield put(ActionFactory.ProductEdit(product))
}

function* DeleteProduct(request: IDeleteProductRequest) {
    yield call(() => ProductsService.DeleteProduct(request.Payload));
    yield put(ActionFactory.ProductDeleted(request.Payload.ExternalId))
}

function* ListProducts(request: IProductsListRequest) {
    var products: IPagedListApiModel<IProductListItem> = yield call(() => ProductsService.ListProducts());
    yield put(ActionFactory.ProductList(products));
}

function* GetProductCategories(request: IGetProductRequest) {
    var productCategories: INameExternalIdApiModel[] = yield call(() => ProductsService.GetProductCategories(request.Payload.ExternalId));
    yield put(ActionFactory.ProductCategories(productCategories));
}

function* AddProductToCategory(request: IAddProductToCategoryRequest) {
    let payload = request.Payload
    yield call(() => ProductsService.AddProductToCategory(request.Payload));
    yield put(ActionFactory.ProductAddedToCategory(payload.ProductExternalId, payload.CategoryExternalId));
}

function* RemoveProductFromCategory(request: IRemoveProductFromCategoryRequest) {
    let payload = request.Payload
    yield call(() => ProductsService.RemoveProductFromCategory(payload));
    yield put(ActionFactory.ProductRemovedFromCategory(payload.ProductExternalId, payload.CategoryExternalId));
}

function* LookupCategories(request: IProductsListRequest) {
    var lookup: INameExternalIdApiModel[] = yield call(() => CategoryService.Lookup())
    yield put(ActionFactory.LookupCategories(lookup));
}

function* UploadProductImages(request: IUploadProductImageRequest) {
    let payload = request.Payload
    yield call(() => payload.Images.forEach((image, index) => {
        ProductsService.UploadImage(image, payload.ProductExternalId, index.toString())
    }))
}

function* AddCategory(request: AddCategoryRequest) {
    let payload = request.Payload
    yield call(() => CategoryService.Add(payload))
    yield put(ActionFactory.Redirect(Routes.Categories.Root))
}

function* EditCategory(request: EditCategoryRequest) {
    let payload = request.Payload
    yield call(() => CategoryService.Edit(payload))
    yield put(ActionFactory.Redirect(Routes.Categories.Root))
}

function* ListCategories(request: CategoriesListRequest) {
    let categories: Category[] = yield call(() => CategoryService.List())
    yield put(ActionFactory.CategoryList(categories));
}

function* GetCategory(request: GetCategoryRequest) {
    let category: Category = yield call(() => CategoryService.Get(request.Payload))
    yield put(ActionFactory.CategoryEdit(category));
}

function* DeleteCategory(request: DeleteCategoryRequest) {
    let payload = request.Payload
    yield call(() => CategoryService.Delete(payload))
    yield put(ActionFactory.CategoryDelete(payload.ExternalId));
}

export function* Watch() {
    yield all([
        WatchProductAdd(),
        WatchProductList(),
        WatchProductEdit(),
        WatchProductDelete(),
        WatchProductGet(),
        WatchProductGetCategories(),
        WatchProductAddToCategory(),
        WatchProductRemoveFromCategory(),
        WatchCategoriesLookup(),
        WatchUploadProductImages(),
        WatchCategoryAdd(),
        WatchCategoryEdit(),
        WatchCategoryList(),
        WatchCategoryGet(),
        WatchCategoryDelete()
    ])
}