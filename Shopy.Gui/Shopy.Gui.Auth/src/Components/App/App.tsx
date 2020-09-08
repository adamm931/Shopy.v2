import React from 'react';
import '../../Content/adminlte.min.css'
import '../../Content/icheck-bootstrap.min.css'
import '../../Content/index.css'
import '../../Content/all.min.css'
import Login from '../Login/Login.hoc'
import { Router, Switch, Route } from 'react-router-dom'
import Register from '../Register/Register.hoc';
import { Provider } from 'react-redux';
import { store, history } from '../../State/Store'

const App = () =>
  <Provider store={store}>
    <Router history={history}>
      <Switch>
        <Route exact path="/" component={Login}></Route>
        <Route exact path="/login" component={Login}></Route>
        <Route exact path="/register" component={Register}></Route>
      </Switch>
    </Router>
  </Provider>

export default App;
