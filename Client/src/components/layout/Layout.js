import React from 'react'
import NavBar from '../navBar/NavBar';
import BingoBoard from '../bingoCard/BingoBoard';


class Layout extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <div className="layout-wrapper">
                <div className='row topnav column'>
                    <NavBar />
                </div>
                <div className='row bingoCard column'>
                    <BingoBoard />
                </div>
            </div>
        )

    }
}
export default Layout