import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import BingoBoard from './components/bingoCard/BingoBoard';
import NavBar from './components/navBar/NavBar';
import Layout from './components/layout/Layout';

class App extends Component {
  render() {
    return (
      <div className="App" >
        {/* <header className="App-header">
          <img src='http://pngimg.com/uploads/baseball/baseball_PNG19018.png' className="App-logo" alt="logo" />

        </header> */}
        <Layout />
      </div>
    );
  }
}

export default App;
