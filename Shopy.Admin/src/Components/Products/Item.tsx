import React from 'react'
import { Link } from 'react-router-dom';
import { IProductListItemDispatch } from './Types/IProductListItemDispatch'
import { IProductListItemProps } from './Types/IProductListItemProps'
import { connect } from 'react-redux';
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'

type Props = IProductListItemProps & IProductListItemDispatch

const ProductItem: React.FC<Props> = (props) => <tr>
    <td>{props.Index}</td>
    <td>{props.Name}</td>
    <td>{props.Price}</td>
    <td><Link to={`products/${props.ExternalId}/edit`} className="btn btn-primary" role="button">Edit</Link></td>
    <td><Link to="#" onClick={() => onDeleteClicked(props)} className="btn btn-danger">Delete</Link></td>
    <td><Link to={`products/${props.ExternalId}/changeCategories`} className="btn btn-secondary" role="button">Change categories</Link></td>
</tr>

const onDeleteClicked = (props: Props) => {
    props.Delete(props.ExternalId)
}

const mapDispatchToProps = (dispatch: any): IProductListItemDispatch => ({
    Delete: (externalId: string) => (dispatch(RequestFactory.DeleteProductRequest(externalId)))
})

export default connect(null, mapDispatchToProps)(ProductItem)