import React from 'react'
import ProductForm from './ProductForm'
import { connect } from 'react-redux'
import { IShopyState, EmptyEditingProduct } from '../../State/ShopyState';
import { IProductEditProps } from './Types/IProductEditProps'
import { IProductEditDispatch } from './Types/IProductEditDisptach'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { RouteComponentProps } from 'react-router-dom';
import { UriUtils } from '../../Utils/UriUtils'

type Props = IProductEditDispatch & IProductEditProps & RouteComponentProps

class ProductEdit extends React.Component<Props, IProductEditProps> {

    constructor(props: Props) {
        super(props)

        this.setState(EmptyEditingProduct())
    }

    componentDidMount() {
        this.props.RequestGetProduct(UriUtils.ReadId(this.props));
    }

    componentWillReceiveProps(nextProps: IProductEditProps) {
        this.setState(nextProps)
    }

    render() {

        if (this.state == null) {
            return null
        }

        return (
            <ProductForm
                ExternalId={UriUtils.ReadId(this.props)}
                Name={this.state.Name}
                Description={this.state.Description}
                Price={this.state.Price}
                Brand={this.state.Brand}
                Sizes={this.state.Sizes}
                Images={[]}
                Type="Edit"
            />)
    }
}

const mapStateToProps = (state: IShopyState): IProductEditProps => {
    return state !== undefined ?
        {
            Name: state.EditingProduct.Name,
            Description: state.EditingProduct.Description,
            Price: state.EditingProduct.Price,
            Brand: state.EditingProduct.Brand,
            Sizes: state.EditingProduct.Sizes,
        } : EmptyEditingProduct()
}

const mapDisptachToProps = (dispatch: any): IProductEditDispatch => ({
    RequestGetProduct: (externalId: string) => dispatch(RequestFactory.GetProductRequest(externalId))
})

export default connect(mapStateToProps, mapDisptachToProps)(ProductEdit)