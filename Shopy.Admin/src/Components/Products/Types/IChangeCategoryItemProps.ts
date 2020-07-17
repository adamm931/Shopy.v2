export interface IChangeCategoryItemProps {
    Index: number;
    ExternalId: string;
    ProductUid: string;
    Name: string;
    RemoveFrom: (productUid: string, categoryUid: string) => void;
}