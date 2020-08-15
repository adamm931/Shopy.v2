export interface IProductChangeCategoryItemProps {
    Index: number;
    ExternalId: string;
    ProductExternalId: string;
    Name: string;
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => void;
}