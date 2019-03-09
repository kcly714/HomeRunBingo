import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import BingoBoard from './components/bingoCard/BingoBoard';

class App extends Component {
  render() {
    return (
      <div className="App" userScalable='yes'>
        {/* <header className="App-header">
          <img src='http://pngimg.com/uploads/baseball/baseball_PNG19018.png' className="App-logo" alt="logo" />

        </header> */}
      
        <BingoBoard />
      </div>
    );
  }
}

export default App;
