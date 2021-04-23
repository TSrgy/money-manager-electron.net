import * as actionTypes from "../actions/actionTypes";

import { combineReducers } from "redux";

const initialState: AccountsState = {
    accounts: [
        {
            id: 1,
            title: "Test 1",
        },
    ],
    selectedAccount: 1
};

const accountsReducer = (state: AccountsState = initialState, action: AccountAction): AccountsState => {
    switch (action.type) {
        case actionTypes.ACCOUNT_SELECTED:
            return {
                ...state,
                selectedAccount: action.account.id,
            };
    }
    return state;
};

export default accountsReducer;
