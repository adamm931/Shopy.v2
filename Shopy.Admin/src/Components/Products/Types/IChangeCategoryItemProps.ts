export interface IChangeCategoryItemProps {
    Index: number;
    ExternalId: string;
    ProductExternalId: string;
    Name: string;
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => void;
}