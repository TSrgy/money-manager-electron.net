import "./index.css";
import "./i18n/config";

import App from "./components/App";
import { Provider } from "react-redux";
import React from "react";
import ReactDOM from "react-dom";
import { configureStore } from "./store";

ReactDOM.render(
    <React.StrictMode>
        <Provider store={configureStore()}>
            <App />
        </Provider>
    </React.StrictMode>,
    document.getElementById("root")
);
