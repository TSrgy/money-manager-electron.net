import "./index.css";
import "./i18n/config";

import App from "./components/App";
import { Provider } from "react-redux";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { configureStore } from "./store";

ReactDOM.render(
    <Router>
        <React.StrictMode>
            <Provider store={configureStore()}>
                <App />
            </Provider>
        </React.StrictMode>
    </Router>,
    document.getElementById("root")
);
