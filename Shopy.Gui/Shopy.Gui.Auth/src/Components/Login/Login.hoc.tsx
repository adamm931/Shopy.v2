import { connect } from "react-redux"
import { LoginDispatch } from '../../Types/Login/Login'
import { ActionCreator } from "../../StateManagement/Actions/ActionCreator"
import Login from './Login'

const mapDispatchToProps = (dispatch: any): LoginDispatch => ({
    Login: (username: string, password: string) => dispatch(ActionCreator.UserLoggedIn(username))
})

export default connect(null, mapDispatchToProps)(Login)