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
        case "@@accounts/CREATE_ACCOUNT":
            return {
                ...state,
                loading: true
            };
        case "@@accounts/CREATE_ACCOUNT_SUCCESS":
            return {
                ...state,
                accounts: [...state.accounts, action.createdAccount],
                loading: false
            };
        case "@@accounts/CREATE_ACCOUNT_FAILED":
            return {
                ...state,
                loading: false
            };
        default:
            return state;
    }
};

export default reducer;
