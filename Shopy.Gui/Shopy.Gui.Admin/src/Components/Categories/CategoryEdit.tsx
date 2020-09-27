import React from 'react'
import CategoryForm from './CategoryForm'
import { FormType } from '../../Common/FormTypes'
import { IShopyState } from '../../State/ShopyState'
import { CategoryEditDispatch } from './Types/CategoryEditDispatch'
import { CategoryEditProps } from './Types/CategoryEditProps'
import { UriUtils } from '../../Utils/UriUtils'
import { RouteComponentProps } from 'react-router'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { connect } from 'react-redux'
import { CategoryEditState } from './Types/CategoryEditState'

type Props = CategoryEditProps & CategoryEditDispatch & RouteComponentProps

class CategoryEdit extends React.Component<Props, CategoryEditState> {

    constructor(props: Props) {
        super(props)

        this.state = {
            Name: '',
            ExternalId: '',
            Description: ''
        }
    }

    componentWillReceiveProps(props: CategoryEditProps) {
        this.setState({
            ...this.state,
            ...props
        })
    }

    componentDidMount() {
        this.props.GetCategory(UriUtils.ReadId(this.props))
    }

    render() {
        if (this.state == null) {
            return null
        }
        return <CategoryForm
            Name={this.state.Name}
            ExternalId={this.state.ExternalId}
            Description={this.state.Description}
            Type={FormType.EDIT} />
    }
}

const mapStateToProps = (state: IShopyState): CategoryEditProps => ({
    ExternalId: state.EditingCategory.ExternalId,
    Name: state.EditingCategory.Name,
    Description: state.EditingCategory.Description
})

const mapDispatchToProps = (dispatch: any): CategoryEditDispatch => ({
    GetCategory: (externalId: string) => dispatch(RequestFactory.GetCategory(externalId))
})

export default connect(mapStateToProps, mapDispatchToProps)(CategoryEdit)