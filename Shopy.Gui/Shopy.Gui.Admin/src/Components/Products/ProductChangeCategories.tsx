import React from 'react';
import { IProductChangeCategoriesProps } from './Types/IProductChangeCategoriesProps'
import { ProductChangeCategoryItem } from './ProductChangeCategoryItem'
import { DropDownList } from '../Shared/Dropdown/DropDownList'
import { IProductChangeCategoriesState } from './Types/IProductChangeCategoriesState'
import { IProductChangeCategoriesDispatch } from './Types/IProductChangeCategoriesDispatch';
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { connect } from 'react-redux';
import { IShopyState } from '../../State/ShopyState';
import { RouteComponentProps } from 'react-router-dom';
import { RouteUtils } from '../../Utils/RouterUtils';

type Props = IProductChangeCategoriesProps & IProductChangeCategoriesDispatch & RouteComponentProps

class ProductChangeCategories extends React.Component<Props, IProductChangeCategoriesState> {

    constructor(props: Props) {
        super(props)

        this.state = {
            SelectedCategoryUid: '',
            AvailableCategories: [],
            ProductCategories: [],
            ProductExternalId: RouteUtils.GetIdParam(props)
        }

        this.props.CategoriesLookup();
        this.props.GetProductCategories();
    }

    componentWillReceiveProps = (newProps: IProductChangeCategoriesProps) => {
        this.setState({
            ...this.state,
            AvailableCategories: newProps.AvailableCategories,
            ProductCategories: newProps.ProductCategories
        })
    }

    setSelectedCategory = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();
        this.setState({
            ...this.state,
            SelectedCategoryUid: event.target.value
        })
    }

    addToSelectedCategory = () => {
        let categoryExternalId = this.state.SelectedCategoryUid;

        if (categoryExternalId === undefined) {
            return
        }

        if (this.state.ProductCategories.some(productCategory => productCategory.Key === categoryExternalId)) {
            return
        }

        // last element
        if (this.state.AvailableCategories.length === 1) {
            categoryExternalId = this.state.AvailableCategories[0].Key
        }

        this.props.AddTo(this.state.ProductExternalId, categoryExternalId)
    }

    removeFromCategory = (productExternalId: string, categoryExternalId: string) => {
        this.props.RemoveFrom(productExternalId, categoryExternalId)
    }

    render() {
        return (
            <React.Fragment>
                <h2>Add or remove categories for product</h2>
                <div className="table-responsive">
                    <table className="table table-striped table-sm">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th colSpan={2}>Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.ProductCategories.map((category, index) =>
                                    <ProductChangeCategoryItem
                                        Index={index}
                                        Name={category.Value}
                                        ExternalId={category.Key}
                                        ProductExternalId={this.state.ProductExternalId}
                                        RemoveFrom={this.removeFromCategory} />)
                            }
                        </tbody>
                    </table>
                    {
                        // component for this?
                        this.state.AvailableCategories.length === 0
                            ? null
                            : (
                                <div className="row col-md-9">
                                    <div className="mb-3 col-md-4">
                                        <DropDownList
                                            Name="AvailableCategories"
                                            ClassName="custom-select d-block"
                                            Items={this.state.AvailableCategories}
                                            SelectedItem={this.state.SelectedCategoryUid}
                                            OnChange={this.setSelectedCategory} />
                                    </div>
                                </div>
                            )
                    }
                    {
                        // component for this?
                        this.state.AvailableCategories.length === 0
                            ? null
                            :
                            (
                                <div className="col-md-4 mb-3">
                                    <button onClick={() => this.addToSelectedCategory()} className="btn btn-success">Add</button>
                                </div>
                            )
                    }


                </div>
            </React.Fragment>
        )
    }
}

const mapStateToProps = (state: IShopyState): IProductChangeCategoriesProps => {
    return {
        AvailableCategories: state.AvailableProductCategories.map(model => ({
            Key: model.ExternalId,
            Value: model.Name
        })),
        ProductCategories: state.ProductCategories.map(model => ({
            Key: model.ExternalId,
            Value: model.Name
        }))
    }

}

const mapDispatachToProps = (dispatch: any, routeProps: RouteComponentProps): IProductChangeCategoriesDispatch => ({
    RemoveFrom: (productExternalId: string, categoryExternalId: string) => dispatch(RequestFactory.RemoveProductFromCategory(productExternalId, categoryExternalId)),
    AddTo: (productExternalId: string, categoryExternalId: string) => dispatch(RequestFactory.AddProductToCategory(productExternalId, categoryExternalId)),
    CategoriesLookup: () => dispatch(RequestFactory.LookupCategories()),
    GetProductCategories: () => dispatch(RequestFactory.GetProductCategories(RouteUtils.GetIdParam(routeProps)))
})

export default connect(mapStateToProps, mapDispatachToProps)(ProductChangeCategories);
