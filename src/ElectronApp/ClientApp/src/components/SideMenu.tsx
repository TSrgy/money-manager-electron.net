import { Layout, Menu } from "antd";
import React, { useEffect, useState } from "react";

import { FolderOutlined } from "@ant-design/icons";
import { Link } from "react-router-dom";
import { fetchAccounts } from "../store/accountsSlice";
import { useDispatch } from "react-redux";
import { useTranslation } from "react-i18next";

const { Sider } = Layout;

export const SideMenu: React.FC = () => {
    const [collapsed, setCollapsed] = useState(false);

    const { t } = useTranslation();
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(fetchAccounts());
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
