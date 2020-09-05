import { connect } from "react-redux"
import { RequestCreator } from "../../State/Requests/RequestCreator"
import { Login } from './Login'
import { LoginDispatch, LoginState } from "./Login.types"

const mapDispatchToProps = (dispatch: any): LoginDispatch => ({
    Login: (state: LoginState) => dispatch(RequestCreator.UserLogin(state.Username, state.Password))
})

export default connect(null, mapDispatchToProps)(Login)