import React from 'react'
import { AuthFieldProps } from './AuthField.types'
import { ErrorMessage, Field, FormikValues } from 'formik'

export function AuthField(props: AuthFieldProps) {
    return (
        <React.Fragment>
            <div className="input-group mb-3">
                <Field
                    name={props.Name}
                    type={props.Type}
                    className="form-control"
                    placeholder={props.Placeholder}
                />
                <div className="input-group-append">
                    <div className="input-group-text">
                        <span className={"fas fa-" + props.IconType}></span>
                    </div>
                </div>
            </div>
            {/* {
                props.FormProps.errors[props.Name]
                && props.FormProps.touched[props.Name]
                && <div className="mb-3 text-danger">{props.FormProps.errors[props.Name]}</div>
            } */}
            <span className="mb-3 text-danger"><ErrorMessage name={props.Name} /></span>
        </React.Fragment>)
}



