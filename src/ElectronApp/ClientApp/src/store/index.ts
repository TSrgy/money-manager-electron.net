import { Store, applyMiddleware, combineReducers, createStore } from "redux";

import { AccountsState } from "./accounts/types";
import accountReducer from "./accounts/reducer";
import thunk from "redux-thunk";

export interface AppState {
    accounts: AccountsState;
}

const rootReducer = combineReducers<AppState>({
    accounts: accountReducer
});

export const configureStore = (): Store<AppState> => {
    const store = createStore(rootReducer, applyMiddleware(thunk));
    return store;
};
