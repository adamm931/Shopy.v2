export interface CategoryFormDispatch {
    Add: (name: string) => void
    Edit: (externalId: string, name: string) => void
}