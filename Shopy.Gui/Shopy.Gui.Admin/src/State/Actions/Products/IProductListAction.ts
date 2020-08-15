import { IPagedListApiModel } from './../../../Service/Api/IPagedListApiModel';
import { ActionTypes } from './../Base/ActionTypes';
import { IBaseAction } from './../Base/IBaseAction';
import { IProductListItem } from '../../../Service/Products/Models/IProductListItem';

export interface IProductListAction extends IBaseAction<IPagedListApiModel<IProductListItem>> {
    type: typeof ActionTypes.PRODUCT_LIST
}