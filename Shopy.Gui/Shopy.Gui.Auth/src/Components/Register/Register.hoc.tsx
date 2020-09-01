import Register from './Register'
import { RegisterDispatch } from '../../Types/Register/Register'
import { connect } from 'react-redux'
import { RequestCreator } from '../../State/Requests/RequestCreator'

const mapDispatchToProps = (dispatch: any): RegisterDispatch => ({
    Register: (username: string, email: string, password: string) => dispatch(RequestCreator.UserRegister(username, email, password))
})

export default connect(null, mapDispatchToProps)(Register)