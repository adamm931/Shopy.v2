import { connect } from "react-redux"
import { LoginDispatch } from '../../Types/Login/Login'
import { RequestCreator } from "../../State/Requests/RequestCreator"
import Login from './Login'

const mapDispatchToProps = (dispatch: any): LoginDispatch => ({
    Login: (username: string, password: string) => dispatch(RequestCreator.UserLogin(username, password))
})

export default connect(null, mapDispatchToProps)(Login)