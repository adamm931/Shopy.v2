import { AuthService } from './../Service/Auth/AuthService';
import { ActionTypes } from './Actions/Base/ActionTypes';
import { IActions } from './Actions/Base/Actions';
import { IShopyState, InitialState } from './ShopyState';

const authService = new AuthService();

export const ShopyReducer = (state: IShopyState = InitialState, action: IActions): IShopyState => {
    switch (action.type) {
        case ActionTypes.USER_LOGED_IN: {

            authService.LoginUser();
            return {
                ...state,
                IsUserLogged: true
            }
        }
        case ActionTypes.PRODUCT_LIST: {
            return {
                ...state,
                ProductList: action.Payload
            }
        }
        case ActionTypes.PRODUCT_EDIT: {
            return {
                ...state,
                EditingProduct: action.Payload
            }
        }
        case ActionTypes.PRODUCT_DELETED: {
            let items = state.ProductList.Items || []
            items = items.filter(product => product.ExternalId !== action.Payload.ExternalId)

            return {
                ...state,
                ProductList: {
                    ...state.ProductList,
                    Items: items
                }
            };
        }
        case ActionTypes.REDIRECT: {
            return {
                ...state,
                RedirectTo: action.Payload.Url
            }
        }
        case ActionTypes.CLEAR_REDIRECT: {
            return {
                ...state,
                RedirectTo: undefined
            }
        }
        case ActionTypes.CATEGORIES_LOOKUP: {
            return {
                ...state,
                LookupCategories: action.Payload.Lookup
            }
        }
        case ActionTypes.PRODUCT_CATEGORIES: {

            console.log(state);

            var productCategories = action.Payload.Categories;

            return {
                ...state,
                ProductCategories: productCategories,
                AvailableProductCategories: state.LookupCategories
                    .filter(lookup => !productCategories.map(c => c.ExternalId).includes(lookup.ExternalId))
            }
        }
        case ActionTypes.PRODUCT_ADDED_TO_CATEGORY: {

            let { addingList, removingList } = getCategoryModifiedLists(action.Payload.CategoryUid, true, state)

            return {
                ...state,
                ProductCategories: addingList,
                AvailableProductCategories: removingList
            }
        }
        case ActionTypes.PRODUCT_REMOVED_FROM_CATEGORY: {

            let { addingList, removingList } = getCategoryModifiedLists(action.Payload.CategoryUid, false, state)

            return {
                ...state,
                ProductCategories: removingList,
                AvailableProductCategories: addingList
            }
        }

        case ActionTypes.CATEGORY_LIST: {
            return {
                ...state,
                Categories: action.Payload.Categories
            }
        }

        case ActionTypes.CATEGORY_EDIT: {
            return {
                ...state,
                EditingCategory: action.Payload.Category
            }
        }

        case ActionTypes.CATEGORY_DELETE: {
            return {
                ...state,
                Categories: state.Categories.filter(category => category.ExternalId !== action.Payload.ExternalId)
            }
        }

        default: {
            return state
        }
    }
}

const getCategoryModifiedLists = (categoryUid: string, added: boolean, state: IShopyState): any => {

    let addingList = state.AvailableProductCategories
    let removingList = state.ProductCategories

    if (added) {
        addingList = state.ProductCategories
        removingList = state.AvailableProductCategories
    }

    removingList = removingList.filter(category => category.ExternalId !== categoryUid)

    var category = state.LookupCategories.find(lookup => lookup.ExternalId === categoryUid)

    if (category === undefined) {
        throw new Error(`Category is not found with externalId '${categoryUid}'`)
    }

    addingList = [...addingList, category]

    return {
        removingList,
        addingList
    }
}
