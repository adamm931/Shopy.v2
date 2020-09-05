import { Register } from './Register'
import { connect } from 'react-redux'
import { RequestCreator } from '../../State/Requests/RequestCreator'
import { RegisterDispatch, RegisterState } from './Register.types'

const mapDispatchToProps = (dispatch: any): RegisterDispatch => ({
    Register: (state: RegisterState) => dispatch(RequestCreator.UserRegister(state.Username, state.Email, state.Password))
})

export default connect(null, mapDispatchToProps)(Register)