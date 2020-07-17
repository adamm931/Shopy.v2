import { INameIdApiModel } from './../../Api/INameIdApiModel';

export interface IProductApiModel {
    ExternalId: string;
    Name: string;
    Description: string;
    Price: number;
    Brand: INameIdApiModel;
    Sizes: INameIdApiModel[];
}