import React from 'react'
import { StringUtils } from '../../Utils/StringUtils'
import { IProductFormEditor } from './Types/IProductFormEditor'

export const ProductFormEditor: React.FC<IProductFormEditor> = (props) =>
    (
        <div className="mb-3 col-md-6">
            <label>
                <b>{StringUtils.Capitalize(props.Name)}:</b>
            </label>
            <textarea
                name={props.Name}
                placeholder={`Enter ${props.Name}`}
                className={props.ClassName || "form-control"}
                value={props.Value}
                onChange={props.OnChange} >
            </textarea>
        </div >
    )