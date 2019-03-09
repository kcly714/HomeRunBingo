import React from 'react'
import HR_Leaders from '../../axios/HR_Leaders'
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';


class BingoBoard extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            usedNums: [],
            players: [],
            usedPlayers: []

        }
        HR_Leaders.HRLeaders(this.onSuccess, this.onError)

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
            usedNums: [
                usedNumsArr
            ],
            sq0: usedNamesArr[0],
            sq1: usedNamesArr[1],
            sq2: usedNamesArr[2],
            sq3: usedNamesArr[3],
            sq4: usedNamesArr[4],
            sq5: usedNamesArr[5],
            sq6: usedNamesArr[6],
            sq7: usedNamesArr[7],
            sq8: usedNamesArr[8],
            sq9: usedNamesArr[9],
            sq10: usedNamesArr[10],
            sq11: usedNamesArr[11],
            sq12: usedNamesArr[12],
            sq13: usedNamesArr[13],
            sq14: usedNamesArr[14],
            sq15: usedNamesArr[15],

        })

    }

    getNewNum = () => {
        return Math.floor(Math.random() * 75);

    }

    anotherCard = () => {

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
            usedNums: [
                usedNumsArr
            ],
            sq0: usedNamesArr[0],
            sq1: usedNamesArr[1],
            sq2: usedNamesArr[2],
            sq3: usedNamesArr[3],
            sq4: usedNamesArr[4],
            sq5: usedNamesArr[5],
            sq6: usedNamesArr[6],
            sq7: usedNamesArr[7],
            sq8: usedNamesArr[8],
            sq9: usedNamesArr[9],
            sq10: usedNamesArr[10],
            sq11: usedNamesArr[11],
            sq12: usedNamesArr[12],
            sq13: usedNamesArr[13],
            sq14: usedNamesArr[14],
            sq15: usedNamesArr[15],

        })
        this.setState({
            usedPlayers: usedNamesArr
        })


    }
    render() {
        return (
            <React.Fragment>
                <div className='content'>
                    <div className="triangle"></div>
                    <div className="row">
                        {this.state.usedPlayers === "" ?
                            <Paper >
                                <Table>
                                    <TableHead>
                                        <TableRow>
                                            <TableCell >Player</TableCell>
                                        </TableRow>
                                    </TableHead>
                                    <TableBody>
                                        {this.state.usedPlayers.map((row, id) => (
                                            <TableRow key={id}>
                                                <TableCell >{row}</TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table>
                            </Paper>
                            : ""}
                        <table className='bingoCard'>
                            <tr classNam='tableHeader'>
                                <th className='headerCell'>B</th>
                                <th className='headerCell'>A</th>
                                <th className='headerCell'>T</th>
                                <th className='headerCell'>Z</th>
                            </tr>
                            <tr classNam='tableRow'>
                                <td className='playerCell' ref='square0' id='square0'>{this.state.sq0}</td>
                                <td className='playerCell' ref='square1' id='square1'>{this.state.sq1}</td>
                                <td className='playerCell' ref='square2' id='square2'>{this.state.sq2}</td>
                                <td className='playerCell' ref='square3' id='square3'>{this.state.sq3}</td>
                            </tr>
                            <tr classNam='tableRow'>
                                <td className='playerCell' ref='square4' id='square4'>{this.state.sq4}</td>
                                <td className='playerCell' ref='square5' id='square5'>{this.state.sq5}</td>
                                <td className='playerCell' ref='square6' id='square6'>{this.state.sq6}</td>
                                <td className='playerCell' ref='square7' id='square7'>{this.state.sq7}</td>
                            </tr>
                            <tr classNam='tableRow'>
                                <td className='playerCell' ref='square8' id='square8'>{this.state.sq8}</td>
                                <td className='playerCell' ref='square9' id='square9'>{this.state.sq9}</td>
                                <td className='playerCell' ref='square10' id='square10'>{this.state.sq10}</td>
                                <td className='playerCell' ref='square11' id='square11'>{this.state.sq11}</td>
                            </tr>
                            <tr classNam='tableRow'>
                                <td className='playerCell' ref='square12' id='square12'>{this.state.sq12}</td>
                                <td className='playerCell' ref='square13' id='square13'>{this.state.sq13}</td>
                                <td className='playerCell' ref='square14' id='square14'>{this.state.sq14}</td>
                                <td className='playerCell' ref='square15' id='square15'>{this.state.sq15}</td>
                            </tr>
                        </table>
                    </div>

                    <button type='btn' className='refreshBtn btn-primary mt-3' onClick={() => this.anotherCard()}>Refresh My Card</button>
                </div>
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