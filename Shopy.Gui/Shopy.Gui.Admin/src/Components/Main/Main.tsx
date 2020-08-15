import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Login from '../Login/Login'
import ProductList from '../Products/ProductList'
import CategoriesList from '../Categories/CategoryList'
import AuthRoute from '../AuthRoute/AuthRoute'
import ProductEdit from '../Products/ProductEdit'
import ProductAdd from '../Products/ProductAdd'
import ProductChangeCategories from '../Products/ProductChangeCategories'
import CategoryEdit from '../Categories/CategoryEdit'
import CategoryAdd from '../Categories/CategoryAdd'

const Main = () => (
    <main id="content-wrap" role="main" className="col-md-9 ml-sm-auto col-lg-10 px-4 ">
        <Switch>
            <Route exact path="/" component={Login} />
            <AuthRoute exact path="/products" component={ProductList} />
            <AuthRoute exact path="/products/add" component={ProductAdd} />
            <AuthRoute exact path="/products/:id/edit" component={ProductEdit} />
            <AuthRoute exact path="/products/:id/changeCategories" component={ProductChangeCategories} />
            <AuthRoute exact path="/categories" component={CategoriesList} />
            <AuthRoute exact path="/categories/add" component={CategoryAdd} />
            <AuthRoute exact path="/categories/:id/edit" component={CategoryEdit} />
        </Switch>
    </main>
)

export default Main