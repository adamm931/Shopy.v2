import Register from './Register'
import { RegisterDispatch } from '../../Types/Register/Register'
import { ActionCreator } from '../../StateManagement/Actions/ActionCreator'
import { connect } from 'react-redux'

const mapDispatchToProps = (dispatch: any): RegisterDispatch => ({
    Register: (username: string, email: string, password: string) => dispatch(ActionCreator.UserRegistered(username))
})

export default connect(null, mapDispatchToProps)(Register)