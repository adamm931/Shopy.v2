import { UsernameRegex, PasswordRegex } from '../../Common/RegexConstants';
import * as Yup from 'yup'
import { RegisterState } from './Register.types';

export const RegisterInitialValues = {
    Username: '',
    Email: '',
    Password: '',
    ConfirmPassword: ''
} as RegisterState

export const RegisterValidationSchema = Yup.object().shape({
    Username: Yup.string()
        .matches(UsernameRegex, 'Username is invalid')
        .required('Username is required'),
    Email: Yup.string()
        .email('Invalid email')
        .required('Email is required'),
    Password: Yup.string()
        .matches(PasswordRegex, 'Password is invalid')
        .required('Password is required'),
    ConfirmPassword: Yup.string()
        .matches(PasswordRegex, 'Password is invalid')
        .required('Confirm password is required')
})