import React from 'react';
import './Content/adminlte.min.css'
import './Content/icheck-bootstrap.min.css'
import './Content/index.css'
import './Content/all.min.css'
import Login from './Components/Login/Login'
import { Router, Switch, Route } from 'react-router-dom'
import { createBrowserHistory } from 'history';
import Register from './Components/Register/Register';

function App() {
  return (
    <Router history={createBrowserHistory()}>
      <Switch>
        <Route exact path="/" component={Login}></Route>
        <Route exact path="/register" component={Register}></Route>
      </Switch>
    </Router>
  );
}

export default App;
