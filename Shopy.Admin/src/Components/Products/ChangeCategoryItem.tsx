import React from 'react'
import { IChangeCategoryItemProps } from './Types/IChangeCategoryItemProps'

export const ChangeCategoryItem: React.FC<IChangeCategoryItemProps> = (props) => (
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