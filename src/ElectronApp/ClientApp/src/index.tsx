import './index.css';

import { applyMiddleware, createStore } from "redux";

import App from './components/App';
import { Provider } from "react-redux";
import React from 'react';
import ReactDOM from 'react-dom';
import reducers from "./store/reducers"
import reportWebVitals from './reportWebVitals';
import thunk from "redux-thunk";

ReactDOM.render(
  <React.StrictMode>
    <Provider store={createStore(reducers, applyMiddleware(thunk))}>
      <App />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
