import { UsernameSchema, EmailSchema, PasswordSchema } from './../../Common/ValidationSchemas';
import * as Yup from 'yup'
import { RegisterState } from './Register.types';

export const RegisterInitialValues = {
    Username: '',
    Email: '',
    Password: '',
    ConfirmPassword: ''
} as RegisterState

export const RegisterValidationSchema = Yup.object().shape({
    Username: UsernameSchema("Username"),
    Email: EmailSchema("Email"),
    Password: PasswordSchema("Password", "ConfirmPassword"),
    ConfirmPassword: PasswordSchema("ConfirmPassword")
})