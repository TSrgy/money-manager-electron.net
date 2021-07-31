import { Account } from "../../store/accountsSlice";
import React from "react";

interface IProps {
    account: Account;
}

export const AccountView: React.FC<IProps> = ({ account }) => {
    return <p>{account.title}</p>;
};
