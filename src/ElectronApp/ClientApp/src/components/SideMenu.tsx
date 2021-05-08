import { Layout, Menu } from "antd";
import React, { useEffect, useState } from "react";
import {
    createFetchAccountsAction,
    createFetchAccountsFailedAction,
    createFetchAccountsSuccessAction,
    createSelectAccountAction
} from "../store/accounts/actionCreators";
import { useDispatch, useSelector } from "react-redux";

import { Account } from "../store/accounts/types";
import { ApiClient } from "../ApiClient";
import { AppState } from "../store";
import { FolderOutlined } from "@ant-design/icons";
import { useTranslation } from "react-i18next";

const { Sider } = Layout;

const { SubMenu } = Menu;

export const SideMenu: React.FC = () => {
    const [collapsed, setCollapsed] = useState(false);

    const { t } = useTranslation();
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(createFetchAccountsAction());
        const client = new ApiClient();
        client
            .accounts_Get()
            .then((data) => {
                let payload: Account[] = [];
                if (data.accounts) {
                    payload = data.accounts.map((x) => {
                        return new Account(x.id, x.name);
                    });
                }
                dispatch(createFetchAccountsSuccessAction(payload));
            })
            .catch(() => {
                dispatch(createFetchAccountsFailedAction());
            });
    }, [dispatch]);

    const accounts: Account[] = useSelector((state: AppState) => state.accounts.accounts);

    const selectedAccountId = useSelector((state: AppState) => state.accounts.selectedAccountdId);

    const dispatchSelectAccount = (accountId: number) => dispatch(createSelectAccountAction(accountId));

    const renderAccountsMenu = () => {
        return accounts.map((account: Account) => (
            <Menu.Item key={account.id} isSelected={selectedAccountId === account.id} onClick={() => dispatchSelectAccount(account.id)}>
                {account.title}
            </Menu.Item>
        ));
    };

    return (
        <Sider theme="light" collapsible collapsed={collapsed} onCollapse={setCollapsed}>
            <div className="logo" />
            <Menu defaultSelectedKeys={["1"]} mode="inline">
                <SubMenu title={t("bankAccounts")} key="accounts" icon={<FolderOutlined />}>
                    {renderAccountsMenu()}
                </SubMenu>
            </Menu>
        </Sider>
    );
};
