import React from 'react'
import { IProductChangeCategoryItemProps } from './Types/IProductChangeCategoryItemProps'

export const ProductChangeCategoryItem: React.FC<IProductChangeCategoryItemProps> = (props) => (
    <tr>
        <td>{props.Index}</td>
        <td>{props.Name}</td>
        <td>
            <a href="#this" onClick={
                () => props.RemoveFrom(props.ProductExternalId, props.ExternalId)}
                className="btn btn-danger"
                role="button">Remove
            </a>
        </td>
    </tr>
)