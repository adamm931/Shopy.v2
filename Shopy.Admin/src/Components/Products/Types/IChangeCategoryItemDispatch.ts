export interface IChangeCategoryItemDispatch {
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => void;
}