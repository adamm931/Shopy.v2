import React from 'react'
import { connect } from 'react-redux'
import { ProductFormInput } from './ProductFormInput'
import { ProductFormEditor } from './ProductFormEditor'
import { ProductFormButtons } from './ProductFormButtons'
import { IProductFormProps, IProductFormDispatch } from './Types/IProductFormProps'
import { IProductFormState, GetStateFromProps } from './Types/IProductFormState'
import { ProductFormDropDown } from './ProductFormDropDown'
import { ProductUtils } from '../../Utils/ProductUtils'
import * as RequestFactory from '../../State/Requests/Factory/RequestFactory'
import { ProductFormImage } from './ProductFormImage'

type ProductFormPropsType = IProductFormProps & IProductFormDispatch;

class ProductForm extends React.Component<ProductFormPropsType, IProductFormState> {

    constructor(props: ProductFormPropsType) {
        super(props);

        this.state = GetStateFromProps(props);
    }

    onCaptionChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Name: event.target.value
        })
    }

    onDescriptionChanged = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Description: event.target.value
        })
    }

    onPriceChanged = (event: React.ChangeEvent<HTMLInputElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Price: Number.parseFloat(event.target.value)
        })
    }

    onBrandChanged = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();

        this.setState({
            ...this.state,
            Brand: event.target.value
        })
    }

    onSizesChanged = (event: React.ChangeEvent<HTMLSelectElement>) => {
        event.preventDefault();

        var sizes = Array
            .from(event.target.selectedOptions)
            .map(option => option.value);

        this.setState({
            ...this.state,
            Sizes: sizes
        })
    }

    onSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        // validate form here

        let data = this.state;

        if (this.props.Type === "Add") {
            this.props.Add(
                data.Name,
                data.Description,
                data.Price,
                data.Brand,
                data.Sizes)
        }

        else {

            if (this.props.ExternalId === undefined) {
                throw new Error('Product externalId is not present');
            }

            this.props.Edit(
                this.props.ExternalId,
                data.Name,
                data.Description,
                data.Price,
                data.Brand,
                data.Sizes)

            let files = this.state.Images
                .filter(img => img.File !== undefined)
                .map(file => file.File as File)

            this.props.UploadImages(this.props.ExternalId, files)
        }
    }

    onImageChanged = (url: string, file: File, index: number) => {

        let currentImages = this.state.Images;

        currentImages[index] = {
            Url: url,
            File: file
        }

        this.setState({
            ...this.state,
            Images: currentImages
        })
    }

    componentWillReceiveProps(newProps: IProductFormProps) {
        this.setState({
            ...this.state,
            Name: newProps.Name,
            Description: newProps.Description,
            Price: newProps.Price,
            Brand: newProps.Brand,
            Sizes: newProps.Sizes,
            Images: newProps.Images.map(image => ({
                Url: image.Url,
                File: image.File
            }))
        })
    }

    render() {
        return (
            <div className="col-md-12 order-md-1">
                <div>
                    <h2>{this.props.Type} product</h2>
                </div>
                <form onSubmit={this.onSubmit}>
                    <ProductFormInput Type="text" Name="name" Value={this.state.Name} OnChange={this.onCaptionChanged} />
                    <ProductFormEditor Name="description" Value={this.state.Description} OnChange={this.onDescriptionChanged} />
                    <ProductFormInput Type="number" Name="price" Value={this.state.Price} OnChange={this.onPriceChanged} />

                    <ProductFormDropDown
                        Name="Brand"
                        SelectedItem={this.state.Brand}
                        Items={ProductUtils.GetBrands()}
                        OnChange={this.onBrandChanged}
                    />

                    <ProductFormDropDown
                        Name="Sizes"
                        SelectedItems={this.state.Sizes}
                        Items={ProductUtils.GetSizes()}
                        Multiple
                        OnChange={this.onSizesChanged}
                    />

                    {/* create product image component */}

                    <div className="ml-3 row">

                        <ProductFormImage
                            Index={0}
                            OnImageChange={(url, file) => this.onImageChanged(url, file, 0)}
                            ExternalId={this.props.ExternalId}
                            {...this.props.Images[0]}
                        />
                        <ProductFormImage
                            Index={1}
                            OnImageChange={(url, file) => this.onImageChanged(url, file, 1)}
                            ExternalId={this.props.ExternalId}
                            {...this.props.Images[1]}
                        />
                        <ProductFormImage
                            Index={2}
                            OnImageChange={(url, file) => this.onImageChanged(url, file, 2)}
                            ExternalId={this.props.ExternalId}
                            {...this.props.Images[2]}
                        />
                    </div>

                    <br />

                    <ProductFormButtons />
                </form >
            </div>
        )
    }
}

const mapDispatchToProps = (dispatch: any): IProductFormDispatch => ({
    Add: (caption: string, description: string, price: number, brand: string, sizes: string[]) =>
        dispatch(RequestFactory.AddProductRequest(caption, description, price, brand, sizes)),
    Edit: (externalId: string, caption: string, description: string, price: number, brand: string, sizes: string[]) =>
        dispatch(RequestFactory.EditProductRequest(externalId, caption, description, price, brand, sizes)),
    UploadImages: (externalId: string, images: File[]) =>
        dispatch(RequestFactory.UploadProductImages(externalId, images))
})

export default connect(null, mapDispatchToProps)(ProductForm)