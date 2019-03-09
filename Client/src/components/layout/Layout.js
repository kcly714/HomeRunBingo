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
            <div className="layout-wrapper">
                <Row>
                    <div className='row topnav column'>
                        <NavBar />
                    </div>

                </Row>
                <Row>

                    <div className='row bingoCard column'>
                        <BingoBoard />
                    </div>
                </Row>
            </div>
        )

    }
}
export default Layout