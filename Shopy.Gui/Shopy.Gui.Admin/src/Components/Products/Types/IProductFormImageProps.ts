export interface IProductFormImageProps {
    Index: number;
    Url: string;
    File?: File;
    ExternalId: string;
    OnImageChange: (url: string, file: File) => void;
}