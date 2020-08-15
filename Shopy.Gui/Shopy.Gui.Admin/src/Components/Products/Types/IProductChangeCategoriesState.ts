import { IKeyValue } from '../../Shared/Types/IKeyValue';

export interface IProductChangeCategoriesState {
    ProductExternalId: string
    SelectedCategoryUid?: string
    AvailableCategories: IKeyValue[]
    ProductCategories: IKeyValue[]
}