import { FormType } from '../../../Enums/FormType'

export interface CategoryFormProps {
    ExternalId?: string
    Name?: string
    Description?: string
    Type: FormType
}