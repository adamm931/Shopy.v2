import { ProductCategories } from './../../../State/Actions/Factory/ActionFactory';
import { IKeyValue } from './../../Shared/Types/IKeyValue';

export interface IChangeCategoriesState {
    ProductExternalId: string
    SelectedCategoryUid?: string
    AvailableCategories: IKeyValue[]
    ProductCategories: IKeyValue[]
}