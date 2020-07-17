export interface IPagedListApiModel<T> {
    Items?: T[];

    PageIndex?: number;

    PageSize?: number;

    PageCount?: number;

    TotalCount?: number;

    HasNextPage?: boolean;
}

export function EmptyPageList<T>(): IPagedListApiModel<T> {
    return {
        Items: [],
        PageIndex: -1,
        PageSize: -1,
        PageCount: -1,
        TotalCount: -1,
        HasNextPage: false
    }
} 