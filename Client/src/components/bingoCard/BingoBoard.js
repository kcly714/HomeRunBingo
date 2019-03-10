import React from 'react'
import HR_Leaders from '../../axios/HR_Leaders'
import CardService from '../../services/CardService'
import { white } from 'ansi-colors';
import SweetAlert from 'react-bootstrap-sweetalert'

class BingoBoard extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            card: 'myCard',
            usedNums: [],
            winner: false,
            activesq1: false,
            activesq2: false,
            activesq3: false,
            activesq4: false,
            activesq5: false,
            activesq6: false,
            activesq7: false,
            activesq8: false,
            activesq9: false,
            activesq10: false,
            activesq11: false,
            activesq12: false,
            activesq13: false,
            activesq14: false,
            activesq15: false,
            activesq16: false,
            players: [],
            usedPlayers: [],
            pageRender: false

        }
        HR_Leaders.HRLeaders(this.onSuccess, this.onError)

    }
    toggleActive1 = () => {
        this.setState({
            activesq1: !this.state.activesq1
        }, () => this.checkWin())
    }
    toggleActive2 = () => {
        this.setState({
            activesq2: !this.state.activesq2
        }, () => this.checkWin())
    }
    toggleActive3 = () => {
        this.setState({
            activesq3: !this.state.activesq3
        }, () => this.checkWin())
    }
    toggleActive4 = () => {
        this.setState({
            activesq4: !this.state.activesq4
        }, () => this.checkWin())
    }
    toggleActive5 = () => {
        this.setState({
            activesq5: !this.state.activesq5
        }, () => this.checkWin())
    }
    toggleActive6 = () => {
        this.setState({
            activesq6: !this.state.activesq6
        }, () => this.checkWin())
    }
    toggleActive7 = () => {
        this.setState({
            activesq7: !this.state.activesq7
        }, () => this.checkWin())
    }
    toggleActive8 = () => {
        this.setState({
            activesq8: !this.state.activesq8
        }, () => this.checkWin())
    }
    toggleActive9 = () => {
        this.setState({
            activesq9: !this.state.activesq9
        }, () => this.checkWin())
    }
    toggleActive10 = () => {
        this.setState({
            activesq10: !this.state.activesq10
        }, () => this.checkWin())
    }
    toggleActive11 = () => {
        this.setState({
            activesq11: !this.state.activesq11
        }, () => this.checkWin())
    }
    toggleActive12 = () => {
        this.setState({
            activesq12: !this.state.activesq12
        }, () => this.checkWin())
    }
    toggleActive13 = () => {
        this.setState({
            activesq13: !this.state.activesq13
        }, () => this.checkWin())
    }
    toggleActive14 = () => {
        this.setState({
            activesq14: !this.state.activesq14
        }, () => this.checkWin())
    }
    toggleActive15 = () => {
        this.setState({
            activesq15: !this.state.activesq15
        }, () => this.checkWin())
        HR_Leaders.HRLeaders(this.onSuccess, this.onError)

    }
    toggleActive16 = () => {
        this.setState({
            activesq16: !this.state.activesq16
        }, () => this.checkWin())
        console.table(this.state);
    }
    onSuccess = resp => {
        console.log("Success Get All", resp)
        let fullName = ""
        // let team = ""
        // let homers;
        // let rank;
        for (let i = 0; i < resp.data.leagues[0].hitting.home_runs.players.length; i++) {
            fullName = resp.data.leagues[0].hitting.home_runs.players[i].preferred_name + " " + resp.data.leagues[0].hitting.home_runs.players[i].last_name

            // resp.data.leagues[0].hitting.home_runs.players[i].status === "FA" ? team = "Free Agent" : team = resp.data.leagues[0].hitting.home_runs.players[i].team.abbr

            // homers = resp.data.leagues[0].hitting.home_runs.players[i].hr

            let newNameArray = this.state.players.slice()
            newNameArray.push(fullName)
            this.setState({
                players: newNameArray
            })

            // let newTeamArray = this.state.Team.slice()
            // newTeamArray.push(team)
            // this.setState({
            //     Team: newTeamArray
            // })

            // let newHomeRunArray = this.state.Homers.slice()
            // newHomeRunArray.push(homers)
            // this.setState({
            //     Homers: newHomeRunArray
            // })
            // let newRankArray = this.state.Rank.slice()
            // newRankArray.push(rank = i + 1)
            // this.setState({
            //     Rank: newRankArray
            // })


        }
        this.setState({ players: this.state.players })


    }
    onError = resp => {
        console.log("Failed to get all", resp)
    }



    newCard = () => {
        this.setState({ players: this.state.players })

        const usedNumsArr = []
        const usedNamesArr = []
        for (var i = 0; usedNumsArr.length < 16; i++) {
            var newNum;

            newNum = (Math.floor(Math.random() * 24) + 1);
            this.setState({
                usedNums: {
                    ...this.state.usedNums, newNum
                }

            })
            if (usedNumsArr.indexOf(newNum) === -1) {
                usedNumsArr.push(newNum);
                usedNamesArr.push(this.state.players[newNum])
                // console.log(`the number ${newNum} has not been used so we will add it to our array`);
            }

        }
        this.setState({
            usedPlayers: usedNamesArr
        })
        this.setState({
            usedNums: [
                usedNumsArr
            ],
            square1: usedNamesArr[0],
            square2: usedNamesArr[1],
            square3: usedNamesArr[2],
            square4: usedNamesArr[3],
            square5: usedNamesArr[4],
            square6: usedNamesArr[5],
            square7: usedNamesArr[6],
            square8: usedNamesArr[7],
            square9: usedNamesArr[8],
            square10: usedNamesArr[9],
            square11: usedNamesArr[10],
            square12: usedNamesArr[11],
            square13: usedNamesArr[12],
            square14: usedNamesArr[13],
            square15: usedNamesArr[14],
            square16: usedNamesArr[15],
            winner: false,
            activesq1: false,
            activesq2: false,
            activesq3: false,
            activesq4: false,
            activesq5: false,
            activesq6: false,
            activesq7: false,
            activesq8: false,
            activesq9: false,
            activesq10: false,
            activesq11: false,
            activesq12: false,
            activesq13: false,
            activesq14: false,
            activesq15: false,
            activesq16: false,

        })

    }

    getNewNum = () => {
        return Math.floor(Math.random() * 75);
    }

    onCardSubmit = event => {
        CardService.create(this.state, this.onCardSubSuccess, this.onCardSubError)
    }

    onCardSubSuccess = evt => {
        console.log('we submitted our card', evt)
    }

    onCardSubError = err => {
        console.log('card submission error', err)
    }


    anotherCard = () => {
        this.setState({ pageRender: true })
        this.newCard();
    }

    componentDidMount() {
        const usedNumsArr = []
        const usedNamesArr = []
        for (var i = 0; usedNumsArr.length < 24; i++) {
            var newNum;

            newNum = (Math.floor(Math.random() * 24) + 1);
            this.setState({
                usedNums: {
                    ...this.state.usedNums, newNum
                }
            })
            if (usedNumsArr.indexOf(newNum) === -1) {
                usedNumsArr.push(newNum);
                usedNamesArr.push(this.state.players[newNum])
                // console.log(`the number ${newNum} has not been used so we will add it to our array`);
            }
        }
        this.setState({
            usedPlayers: usedNamesArr
        })
        this.setState({
            usedNums: [
                usedNumsArr
            ],
            square1: usedNamesArr[0],
            square2: usedNamesArr[1],
            square3: usedNamesArr[2],
            square4: usedNamesArr[3],
            square5: usedNamesArr[4],
            square6: usedNamesArr[5],
            square7: usedNamesArr[6],
            square8: usedNamesArr[7],
            square9: usedNamesArr[8],
            square10: usedNamesArr[9],
            square11: usedNamesArr[10],
            square12: usedNamesArr[11],
            square13: usedNamesArr[12],
            square14: usedNamesArr[13],
            square15: usedNamesArr[14],
            square16: usedNamesArr[15],

        })



    }
    checkWin = () => {
        if ((this.state.activesq1 && this.state.activesq2 && this.state.activesq3 && this.state.activesq4) ||
            (this.state.activesq5 && this.state.activesq6 && this.state.activesq7 && this.state.activesq8) ||
            (this.state.activesq9 && this.state.activesq10 && this.state.activesq11 && this.state.activesq12) ||
            (this.state.activesq13 && this.state.activesq14 && this.state.activesq15 && this.state.activesq16) ||
            (this.state.activesq1 && this.state.activesq5 && this.state.activesq9 && this.state.activesq13) ||
            (this.state.activesq2 && this.state.activesq6 && this.state.activesq10 && this.state.activesq14) ||
            (this.state.activesq3 && this.state.activesq7 && this.state.activesq11 && this.state.activesq15) ||
            (this.state.activesq4 && this.state.activesq8 && this.state.activesq12 && this.state.activesq16) ||
            (this.state.activesq1 && this.state.activesq6 && this.state.activesq11 && this.state.activesq16) ||
            (this.state.activesq4 && this.state.activesq7 && this.state.activesq10 && this.state.activesq13)) {
            this.setState({
                winner: true
            })
        }
    }
    hideAlert = () => {
        this.setState({
            winner: false
        })
    }
    render() {
        console.log('this.state.usednums', this.state.usedNums)
        const active1 = this.state.activesq1 === true ? "playerCell active" : "playerCell"
        const active2 = this.state.activesq2 === true ? "playerCell active" : "playerCell"
        const active3 = this.state.activesq3 === true ? "playerCell active" : "playerCell"
        const active4 = this.state.activesq4 === true ? "playerCell active" : "playerCell"
        const active5 = this.state.activesq5 === true ? "playerCell active" : "playerCell"
        const active6 = this.state.activesq6 === true ? "playerCell active" : "playerCell"
        const active7 = this.state.activesq7 === true ? "playerCell active" : "playerCell"
        const active8 = this.state.activesq8 === true ? "playerCell active" : "playerCell"
        const active9 = this.state.activesq9 === true ? "playerCell active" : "playerCell"
        const active10 = this.state.activesq10 === true ? "playerCell active" : "playerCell"
        const active11 = this.state.activesq11 === true ? "playerCell active" : "playerCell"
        const active12 = this.state.activesq12 === true ? "playerCell active" : "playerCell"
        const active13 = this.state.activesq13 === true ? "playerCell active" : "playerCell"
        const active14 = this.state.activesq14 === true ? "playerCell active" : "playerCell"
        const active15 = this.state.activesq15 === true ? "playerCell active" : "playerCell"
        const active16 = this.state.activesq16 === true ? "playerCell active" : "playerCell"

        return (
            <React.Fragment>
                <div className='content'>
                    <table className='bingoCard'>
                        <tr className='tableHeader'>
                            <th className='headerCell'>B</th>
                            <th className='headerCell'>A</th>
                            <th className='headerCell'>T</th>
                            <th className='headerCell'>Z</th>
                        </tr>
                        <tr className='tableRow'>
                            <td onClick={this.toggleActive1} className={active1} ref='square0' id='square0'>{this.state.square1}</td>
                            <td onClick={this.toggleActive2} className={active2} ref='square1' id='square1'>{this.state.square2}</td>
                            <td onClick={this.toggleActive3} className={active3} ref='square2' id='square2'>{this.state.square3}</td>
                            <td onClick={this.toggleActive4} className={active4} ref='square3' id='square3'>{this.state.square4}</td>
                        </tr>
                        <tr className='tableRow'>
                            <td onClick={this.toggleActive5} className={active5} ref='square4' id='square4'>{this.state.square5}</td>
                            <td onClick={this.toggleActive6} className={active6} ref='square5' id='square5'>{this.state.square6}</td>
                            <td onClick={this.toggleActive7} className={active7} ref='square6' id='square6'>{this.state.square7}</td>
                            <td onClick={this.toggleActive8} className={active8} ref='square7' id='square7'>{this.state.square8}</td>
                        </tr>
                        <tr className='tableRow'>
                            <td onClick={this.toggleActive9} className={active9} ref='square8' id='square8'>{this.state.square9}</td>
                            <td onClick={this.toggleActive10} className={active10} ref='square9' id='square9'>{this.state.square10}</td>
                            <td onClick={this.toggleActive11} className={active11} ref='square10' id='square10'>{this.state.square11}</td>
                            <td onClick={this.toggleActive12} className={active12} ref='square11' id='square11'>{this.state.square12}</td>
                        </tr>
                        <tr className='tableRow'>
                            <td onClick={this.toggleActive13} className={active13} ref='square12' id='square12'>{this.state.square13}</td>
                            <td onClick={this.toggleActive14} className={active14} ref='square13' id='square13'>{this.state.square14}</td>
                            <td onClick={this.toggleActive15} className={active15} ref='square14' id='square14'>{this.state.square15}</td>
                            <td onClick={this.toggleActive16} className={active16} ref='square15' id='square15'>{this.state.square16}</td>
                        </tr>
                    </table>
                    <ul>
                        <li>
                            <button type='button' className='btn btn-primary' onClick={() => this.onCardSubmit()}>Submit My Card</button>

                        </li>
                        <li>
                            <button type='button' className='btn btn-danger' onClick={() => this.anotherCard()}>Refresh My Card</button>

                        </li>
                    </ul>
                </div>
                <SweetAlert success title="Congratulation!" show={this.state.winner} onConfirm={this.hideAlert}>
                    You won!
                </SweetAlert>
            </React.Fragment>
        )
    }
}

export default BingoBoard

// const players = [
//     { "id": 0, "name": "Mike Trout", "pic": 'https://www.thesportsdb.com/images/media/player/thumb/mhvrxw1542540970.jpg' },
//     { "id": 1, "name": "JD Martinez", "pic": '' },
//     { "id": 2, "name": "Bryce Harper", "pic": '' },
//     { "id": 3, "name": "Anthony Rizzo", "pic": '' },
//     { "id": 4, "name": "Kris Bryant", "pic": '' },
//     { "id": 5, "name": "Joey Gallo", "pic": '' },
//     { "id": 6, "name": "Mookie Betts", "pic": '' },
//     { "id": 7, "name": "Freddie Freeman", "pic": '' },
//     { "id": 8, "name": "Khris Davis", "pic": '' },
//     { "id": 9, "name": "Mike Stanton", "pic": '' },
//     { "id": 10, "name": "Aaron Judge", "pic": '' },
//     { "id": 11, "name": "Francisco Lindor", "pic": '' },
//     { "id": 12, "name": "Manny Machado", "pic": '' },
//     { "id": 13, "name": "Jose Ramirez", "pic": '' },
//     { "id": 14, "name": "Matt Carpenter", "pic": '' },
//     { "id": 15, "name": "Christian Yelich", "pic": '' },
//     { "id": 16, "name": "Max Muncy", "pic": '' },
//     { "id": 17, "name": "Jesus Aguilar", "pic": '' },
//     { "id": 18, "name": "Javier Baez", "pic": '' },
//     { "id": 19, "name": "Rhys Hoskins", "pic": '' },
//     { "id": 20, "name": "Eugenio Suarez", "pic": '' },
//     { "id": 21, "name": "Alex Bregman", "pic": '' },
//     { "id": 22, "name": "Edwin Encarnacion", "pic": '' },
//     { "id": 23, "name": "Paul Goldschmidt", "pic": '' },
//     { "id": 24, "name": "Charlie Blackmon", "pic": '' },
//     { "id": 25, "name": "Micheal Conforto", "pic": '' },
//     { "id": 26, "name": "Carlos Correa", "pic": '' },
//     { "id": 27, "name": "Aaron Hicks", "pic": '' },
//     { "id": 28, "name": "Justin Upton", "pic": '' },
//     { "id": 29, "name": "Travis Shaw", "pic": '' },
//     { "id": 30, "name": "Matt Olson", "pic": '' },
//     { "id": 31, "name": "Miguel Andujar", "pic": '' },
//     { "id": 32, "name": "Didi Gregorius", "pic": '' },
//     { "id": 33, "name": "Kyle Schwarber", "pic": '' },
//     { "id": 34, "name": "Cody Bellinger", "pic": '' },
//     { "id": 35, "name": "Ronald Acuna", "pic": '' },
//     { "id": 36, "name": "Joc Pederson", "pic": '' },
//     { "id": 37, "name": "Nolan Arenado", "pic": '' },
//     { "id": 38, "name": "C.J. Chron", "pic": '' },

// ]