import { DesktopOutlined, FileOutlined, FolderOutlined, TeamOutlined, UserOutlined } from "@ant-design/icons";
import { Layout, Menu } from "antd";
import React, { Dispatch, useState } from "react";
import { shallowEqual, useDispatch, useSelector } from "react-redux";

import { selectAccount } from "../store/actions";

const { Sider } = Layout;


const { SubMenu } = Menu;


export const SideMenu: React.FC = () => {
    const [collapsed, setCollapsed] = useState(false);
    const accounts: readonly IAccount[] = useSelector((state: AccountsState) => state.accounts);
    const selectedAccountId: number = useSelector((state: AccountsState) => state.selectedAccount);

    const renderAccountsMenu = () => {
        return accounts.map((account: IAccount) => <Menu.Item key={account.id} isSelected={selectedAccountId === account.id} onSelect={()=> selectAccount(account)}>{account.title}</Menu.Item>);
    };

   

    return (
        <Sider collapsible collapsed={collapsed} onCollapse={setCollapsed}>
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={["1"]} mode="inline">
                <SubMenu title="Accounts" key="accounts" icon={<FolderOutlined />}>
                    {renderAccountsMenu()}
                    <Menu.Item key="_create">Create new</Menu.Item>
                </SubMenu>
            </Menu>
        </Sider>
    );
};
