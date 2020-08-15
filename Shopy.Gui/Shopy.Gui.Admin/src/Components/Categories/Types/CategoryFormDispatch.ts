export interface CategoryFormDispatch {
    Add: (name: string, description: string) => void
    Edit: (externalId: string, name: string, description: string) => void
}