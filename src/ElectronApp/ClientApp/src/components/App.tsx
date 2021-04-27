import "./App.css";

import { Account } from "../store/accounts/types";
import { AppState } from "../store";
import { Layout } from "antd";
import React from "react";
import { SideMenu } from "./SideMenu";
import { useSelector } from "react-redux";

const { Header, Content } = Layout;

const App: React.FC = () => {
    const accounts = useSelector((state: AppState) => state.accounts.accounts);
    const selectedAccountdId = useSelector((state: AppState) => state.accounts.selectedAccountdId);
    let selectedAccount: Account | undefined | null;
    if (selectedAccountdId) {
        selectedAccount = accounts.find((a) => a.id === selectedAccountdId);
    }

    return (
        <Layout style={{ minHeight: "100vh" }}>
            <SideMenu />
            <Layout className="site-layout">
                <Header className="site-layout-background" style={{ padding: 0 }} />
                <Content style={{ margin: "0 16px" }}>
                    <div className="site-layout-background" style={{ padding: 24, minHeight: 360 }}>
                        {selectedAccount?.title}
                    </div>
                </Content>
            </Layout>
        </Layout>
    );
};

export default App;
