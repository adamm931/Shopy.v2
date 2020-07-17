import { INameExternalIdApiModel } from '../../../Service/Api/INameExternalIdApiModel';
import { IBaseAction } from './../Base/IBaseAction';
import { ActionTypes } from '../Base/ActionTypes';

export interface IGetProductCategoriesAction extends IBaseAction<IGetProductCategoriesActionPayload> {
    type: typeof ActionTypes.PRODUCT_CATEGORIES
}

export interface IGetProductCategoriesActionPayload {
    Categories: INameExternalIdApiModel[];
}