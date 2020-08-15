import { DropDownList } from '../Shared/Dropdown/DropDownList'
import { IProductDropDownProps } from './Types/IProductDropDownProps'
import React from 'react'
import { StringUtils } from '../../Utils/StringUtils'

export const ProductFormDropDown: React.FC<IProductDropDownProps> = (props) => (
    <div className="mb-3 col-md-3">
        <label>
            <b>{StringUtils.Capitalize(props.Name)}:</b>
        </label>
        <DropDownList
            Name={props.Name}
            Items={props.Items}
            SelectedItem={props.SelectedItem}
            SelectedItems={props.SelectedItems}
            Multiple={props.Multiple}
            ClassName="custom-select d-block"
            OnChange={props.OnChange}
        />
    </div>
)