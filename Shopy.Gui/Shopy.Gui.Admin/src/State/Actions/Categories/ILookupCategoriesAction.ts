import { ActionTypes } from './../Base/ActionTypes';
import { INameExternalIdApiModel } from '../../../Service/Api/INameExternalIdApiModel';
import { IBaseAction } from './../Base/IBaseAction';

export interface ILookupCategoriesAction extends IBaseAction<ILookupCategoriesActionPayload> {
    type: typeof ActionTypes.CATEGORIES_LOOKUP
}

export interface ILookupCategoriesActionPayload {
    Lookup: INameExternalIdApiModel[]
}