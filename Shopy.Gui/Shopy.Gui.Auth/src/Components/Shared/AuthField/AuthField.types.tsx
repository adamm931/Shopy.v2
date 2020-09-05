import { ChangeEvent } from "react";
import { FormikErrors, FormikTouched, FormikState } from "formik";

export interface AuthFieldProps {
    Name: string
    Type: AuthFieldType
    Placeholder: string
    IconType: AuthFieldIconType
}

export enum AuthFieldType {
    Text = "text",
    Password = "password"
}

export enum AuthFieldIconType {
    Username = "user",
    Email = "envelope",
    Password = "lock"
}