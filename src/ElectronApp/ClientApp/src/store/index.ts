import { Store, applyMiddleware, combineReducers, createStore } from "redux";

import { AccountsState } from "./accounts/types";
import accountReducer from "./accounts/reducer";
import { composeWithDevTools } from "redux-devtools-extension/developmentOnly";
import thunk from "redux-thunk";

export interface AppState {
    accounts: AccountsState;
}

const rootReducer = combineReducers<AppState>({
    accounts: accountReducer
});

const composeEnhancers = composeWithDevTools({
    // options like actionSanitizer, stateSanitizer
});

export const configureStore = (): Store<AppState> => {
    const store = createStore(rootReducer, composeEnhancers(applyMiddleware(thunk)));
    return store;
};
