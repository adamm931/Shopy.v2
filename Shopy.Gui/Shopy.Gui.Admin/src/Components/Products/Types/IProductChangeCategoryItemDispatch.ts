export interface IProductChangeCategoryItemDispatch {
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => void;
}