/* eslint-disable @typescript-eslint/explicit-module-boundary-types */

import { Account } from "./types";

export const createSelectAccountAction = (accountId: number) => {
    return {
        type: "@@accounts/SELECT_ACCOUNT",
        payload: accountId
    } as const;
};

export const createAccountAction = (name: string) => {
    return {
        type: "@@accounts/CREATE_ACCOUNT",
        paylod: name
    } as const;
};

export const createAccountSuccessAction = (account: Account) => {
    return {
        type: "@@accounts/CREATE_ACCOUNT_SUCCESS",
        createdAccount: account
    } as const;
};

export const createAccountFailedAction = () => {
    return {
        type: "@@accounts/CREATE_ACCOUNT_FAILED"
    } as const;
};

export const createFetchAccountsAction = () => {
    return {
        type: "@@accounts/FETCH_ACCOUNTS"
    } as const;
};

export const createFetchAccountsSuccessAction = (accounts: Account[]) => {
    return {
        type: "@@accounts/FETCH_ACCOUNTS_SUCCESS",
        payload: accounts
    } as const;
};

export const createFetchAccountsFailedAction = () => {
    return {
        type: "@@accounts/FETCH_ACCOUNTS_FAILED"
    } as const;
};
