import React from 'react'
import ProductForm from './ProductForm'
import { connect } from 'react-redux'

class ProductAdd extends React.Component {

    render() {
        return (
            <ProductForm
                Name=""
                Description=""
                Price={0}
                Brand=""
                Sizes={[]}
                Images={[]}
                Type="Add" />
        )
    }
}

export default connect()(ProductAdd)