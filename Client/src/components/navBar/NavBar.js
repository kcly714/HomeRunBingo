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
                <nav className="navbar navbar-light bg-light">
                    <form className="form-inline">
                        <input type='Email' onChange={this.onChange} lable='Email' placeholder='johndoe@email.com' value={this.state.email} name='Email' />
                        <input type='Password' onChange={this.onChange} lable='Password' placeholder='password123' value={this.state.password} name='Password' />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="button" onClick={() => this.onLoginClick()}>Login</button>
                    </form>
                </nav>
            </React.Fragment>

        )
    }
}

export default NavBar