import React from 'react'
import NavBar from '../navBar/NavBar';
import BingoBoard from '../bingoCard/BingoBoard';
import { Row, Column } from 'bootstrap'


class Layout extends React.Component {
    constructor(props) {
        super(props)

    }

    render() {
        return (
            <React.Fragment>

                <div className='container'>
                    <div className='row col navigation'>
                        <NavBar />
                    </div>
                </div>
                <div className='container'>
                    <BingoBoard />
                </div>
            </React.Fragment>
        )

    }
}
export default Layout