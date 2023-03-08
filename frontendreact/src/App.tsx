import React from 'react';
import logo from './logo.svg';
import './App.css';
import ExpenseItem from './components/ReactComponent';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
            Learn React
        </a>
        
        <ExpenseItem
            expenseName = "Test"
            amount = '1.00'
        />  

          </header>
    </div>
  );
}

export default App;
