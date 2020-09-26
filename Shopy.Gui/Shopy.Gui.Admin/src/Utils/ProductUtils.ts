import { EndOfLineState } from 'typescript';
import { IKeyValue } from './../Components/Shared/Types/IKeyValue';
import { EnviromentUtils } from './EnviromentUtils';

export class ProductUtils {

    public static GetBrands = (): IKeyValue[] =>
        [
            {
                Key: 'Adidas',
                Value: 'Adidas'
            },
            {
                Key: 'Rebook',
                Value: 'Rebook'
            },
            {
                Key: 'Nike',
                Value: 'Nike'
            },
            {
                Key: 'Puma',
                Value: 'Puma'
            },
            {
                Key: 'Active',
                Value: 'Active'
            }
        ]

    public static GetSizes = (): IKeyValue[] =>
        [
            {
                Key: 'XS',
                Value: 'Extra small'
            },
            {
                Key: 'S',
                Value: 'Small'
            },
            {
                Key: 'M',
                Value: 'Medium'
            },
            {
                Key: 'L',
                Value: 'Large'
            },
            {
                Key: 'XL',
                Value: 'Extra large'
            }
        ]

    public static GetImageUrl = (index: number, externalId: string): string =>
        externalId === undefined
            ? EnviromentUtils.DefaultImageUrl
            : `${EnviromentUtils.ImageRootDirectoryUrl}/${externalId}/${index}.png`

}