import { AccountsState, ActionTypes } from "./types";

import { Reducer } from "redux";

const initialState: AccountsState = {
    accounts: [],
    loading: false
};

const reducer: Reducer<AccountsState> = (state: AccountsState = initialState, action: ActionTypes) => {
    switch (action.type) {
        case "@@accounts/FETCH_ACCOUNTS":
            return {
                ...state,
                loading: true
            };
        case "@@accounts/FETCH_ACCOUNTS_SUCCESS":
            return {
                ...state,
                accounts: action.payload,
                loading: false
            };
        case "@@accounts/FETCH_ACCOUNTS_FAILED":
            return {
                ...state,
                loading: false
            };
        case "@@accounts/SELECT_ACCOUNT":
            return {
                ...state,
                selectedAccountdId: action.payload
            };
        default:
            return state;
    }
};

export default reducer;