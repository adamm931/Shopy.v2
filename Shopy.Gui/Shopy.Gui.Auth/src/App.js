import React from 'react';
import './Content/adminlte.min.css'
import './Content/icheck-bootstrap.min.css'
import './Content/index.css'
import './Content/all.min.css'
import Login from './Components/Login/Login'
import { Router, Switch, Route } from 'react-router-dom'
import Register from './Components/Register/Register';
import { Provider } from 'react-redux';
import { store, history } from './StateManagement/Store'

function App() {
  return (
    <Provider store={store}>
      <Router history={history}>
        <Switch>
          <Route exact path="/" component={Login}></Route>
          <Route exact path="/register" component={Register}></Route>
        </Switch>
      </Router>
    </Provider>
  );
}

export default App;
