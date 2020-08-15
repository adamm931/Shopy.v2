import React from 'react';

export interface IProductFormInput {
    Type: string
    Name: string
    Value: any
    ClassName?: string
    OnChange?: (event: React.ChangeEvent<HTMLInputElement>) => void
}