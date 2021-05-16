import { Layout, Menu } from "antd";
import React, { useEffect, useState } from "react";
import {
    createFetchAccountsAction,
    createFetchAccountsFailedAction,
    createFetchAccountsSuccessAction
} from "../store/accounts/actionCreators";

import { Account } from "../store/accounts/types";
import { ApiClient } from "../ApiClient";
import { FolderOutlined } from "@ant-design/icons";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { useTranslation } from "react-i18next";

const { Sider } = Layout;

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

    return (
        <Sider theme="light" collapsible collapsed={collapsed} onCollapse={setCollapsed}>
            <div className="logo" />
            <Menu defaultSelectedKeys={["accounts"]} mode="inline">
                <Menu.Item key="accounts" icon={<FolderOutlined />}>
                    <Link to="/accounts">{t("bankAccounts")}</Link>
                </Menu.Item>
            </Menu>
        </Sider>
    );
};
