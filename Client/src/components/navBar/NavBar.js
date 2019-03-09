import React from 'react'
import TextInput from '../../common/TextInput'
import UserService from '../../services/UserService'


class NavBar extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            Email: '',
            Password: '',
        }
    }

    onChange = (event) => {
        const key = event.target.name;
        const value = event.target.value;
        this.setState({
            ...this.state,
            [key]: value
        })
    }

    onRegisterClick = event => {

    }
    onLoginClick = data => {
        UserService.create(this.state, this.onLoginSuccess, this.onLoginError)
    }

    onLoginSuccess = event => {
        console.log('login success', event)
    }

    onLoginError = err => {
        console.log('login error', err)
    }
    render() {
        return (
            <React.Fragment>
                <div className='topnav'>
                    <nav>
                        <TextInput type='Email' onChange={this.onChange} lable='Email' placeholder='johndoe@email.com' value={this.state.email} name='Email' />
                        <TextInput type='Password' onChange={this.onChange} lable='Password' placeholder='password123' value={this.state.password} name='Password' />
                        <button type='button' className='login' onClick={() => this.onLoginClick()}> Login </button>
                        {/* <button type='button' className='register' onClick={this.onRegisterClick}> Register </button> */}
                    </nav>
                </div>
            </React.Fragment>
        )
    }
}

export default NavBar