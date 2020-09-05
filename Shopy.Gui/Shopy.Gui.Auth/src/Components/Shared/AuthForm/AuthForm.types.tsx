import { FormikHelpers, FormikState } from "formik";

export interface AuthFormProps<FormState> {
    Title: string
    Message: string
    InitialValues: FormState
    ValidationSchema: any
    OnSubmit: (values: FormState) => void
}