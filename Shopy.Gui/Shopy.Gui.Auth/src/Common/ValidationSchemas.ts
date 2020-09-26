import { UsernameRegex, PasswordRegex } from './RegexConstants';
import * as Yup from 'yup'
import AuthApi from '../Api/AuthApi';

export const UsernameSchema = (usernameField: string) => Yup.string()
    .matches(UsernameRegex, `${usernameField} is doesn't meet requirements`)
    .required(`${usernameField} is required`);

export const PasswordSchema = (passwordField: string, confirmPasswordFieldName?: string) => {
    var schema = Yup.string()
        .matches(PasswordRegex, `${passwordField} is doesn't meet requirements`)
        .required(`${passwordField} is required`)

    if (confirmPasswordFieldName) {
        schema = schema.oneOf([Yup.ref(confirmPasswordFieldName)], `${passwordField} must match ${confirmPasswordFieldName}`)
    }

    return schema
}

export const UniqueUsernameSchema = (usernameField: string) =>
    UsernameSchema(usernameField).test(
        'unique_username',
        'Username is not available',
        async (value) => value ? (await AuthApi.CheckUsername(value)).IsAvailable : false)


export const EmailSchema = (emailField: string) => Yup.string()
    .email('Email is invalid')
    .required(`${emailField} is required`)
