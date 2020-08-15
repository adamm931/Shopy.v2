import React from 'react'
import { CategoryListItemProps } from './Types/CategoryListItemProps'
import { CategoryListItemDispatch } from './Types/CategoryListItemDispatch'
import { Link } from 'react-router-dom'
import { connect } from 'react-redux'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'

type Props = CategoryListItemProps & CategoryListItemDispatch

const CategoryListItem: React.FC<Props> = (props) => (
    <tr>
        <td>{props.Index}</td>
        <td>{props.Name}</td>
        <td><Link to={`categories/${props.ExternalId}/edit`} className="btn btn-primary">Edit</Link></td>
        <td><button className="btn btn-danger" onClick={() => onDelete(props)}>Delete</button></td>
    </tr>
)

const onDelete = (props: Props) =>
    props.Delete(props.ExternalId)

const mapDispatchToProps = (dispatch: any): CategoryListItemDispatch => ({
    Delete: (externalId: string) => dispatch(RequestFactory.DeleteCategory(externalId))
})

export default connect(null, mapDispatchToProps)(CategoryListItem)
