export interface IProductChangeCategoriesDispatch {
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => void
    AddTo: (productExternalId: string, categoryExternalId: string) => void
    CategoriesLookup: () => void
    GetProductCategories: () => void
}