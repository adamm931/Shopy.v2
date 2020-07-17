import { IProductFormImageProps } from './IProductFormImageProps';

export interface IProductFormProps {
    Uuid?: string;
    Name: string
    Description: string
    Price: number
    Brand: string
    Sizes: string[]
    Type: ProductFormType
    Images: IProductFormImageProps[]
}

export interface IProductFormDispatch {
    Add: (name: string, description: string, price: number, brand: string, sizes: string[]) => void
    Edit: (externalId: string, name: string, description: string, price: number, brand: string, sizes: string[]) => void
    UploadImages: (externalId: string, images: File[]) => void
}

export type ProductFormType = "Edit" | "Add";