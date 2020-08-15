import React from 'react';

export interface IProductFormEditor {
    Name: string
    Value: any
    ClassName?: string
    OnChange?: (event: React.ChangeEvent<HTMLTextAreaElement>) => void
}