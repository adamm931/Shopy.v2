import { LoginState } from './Login.types';
import { UsernameRegex, PasswordRegex } from "../../Common/RegexConstants"
import * as Yup from 'yup'

export const LoginInitialValues =
    {
        Username: '',
        Password: ''
    } as LoginState

export const LoginValidationSchema =
    Yup.object().shape({
        Username: Yup.string()
            .matches(UsernameRegex, 'Username is invalid')
            .required('Username is required'),
        Password: Yup.string()
            .matches(PasswordRegex, 'Password is invalid')
            .required('Password is required'),
    })