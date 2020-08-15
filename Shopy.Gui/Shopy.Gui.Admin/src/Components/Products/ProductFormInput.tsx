import React from 'react'
import { IProductFormInput } from './Types/IProductFormInput'
import { StringUtils } from '../../Utils/StringUtils'

export const ProductFormInput: React.FC<IProductFormInput> = (props) =>
    (
        <div className="mb-3 col-md-6">
            <label>
                <b>{StringUtils.Capitalize(props.Name)}:</b>
            </label>
            <input
                name={props.Name}
                type={props.Type}
                placeholder={`Enter ${props.Name}`}
                className={props.ClassName || "form-control"}
                value={props.Value}
                onChange={props.OnChange} >
            </input >
        </div >
    )