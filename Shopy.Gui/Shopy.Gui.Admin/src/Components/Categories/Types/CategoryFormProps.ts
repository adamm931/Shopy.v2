import { FormType } from '../../../Common/FormTypes'

export interface CategoryFormProps {
    ExternalId?: string
    Name?: string
    Description?: string
    Type: FormType
}