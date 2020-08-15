import React from 'react'
import CategoryForm from './CategoryForm'
import { FormType } from '../../Enums/FormType'
import { connect } from 'react-redux'

class CategoryAdd extends React.Component<{}> {
    render() {
        return <CategoryForm
            Name=""
            Type={FormType.ADD} />
    }
}


export default connect()(CategoryAdd)