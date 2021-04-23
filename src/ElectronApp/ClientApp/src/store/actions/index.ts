import { ACCOUNT_SELECTED } from "./actionTypes"

// Action creator
export const selectAccount = (account: IAccount) => {
    return {
        type: ACCOUNT_SELECTED,
        payload: account
    }
}