import { LoginState } from './Login.types';
import { UsernameRegex, PasswordRegex } from "../../Common/RegexConstants"
import * as Yup from 'yup'
import { UsernameSchema, PasswordSchema } from '../../Common/ValidationSchemas';

export const LoginInitialValues =
    {
        Username: '',
        Password: ''
    } as LoginState

export const LoginValidationSchema =
    Yup.object().shape({
        Username: UsernameSchema("Username"),
        Password: PasswordSchema("Password"),
    })