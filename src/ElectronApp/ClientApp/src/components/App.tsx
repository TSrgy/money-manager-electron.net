import "./App.css";

import { Route, Switch } from "react-router-dom";

import { AccountsPage } from "./accounts/AccountsPage";
import { HeaderTools } from "./HeaderTools";
import { Layout } from "antd";
import React from "react";
import { SideMenu } from "./SideMenu";

const { Content } = Layout;

const App: React.FC = () => {
    // const accounts = useSelector((state: AppState) => state.accounts.accounts);
    // const selectedAccountdId = useSelector((state: AppState) => state.accounts.selectedAccountdId);
    // let selectedAccount: Account | undefined | null;
    // if (selectedAccountdId) {
    //     selectedAccount = accounts.find((a) => a.id === selectedAccountdId);
    // }

    return (
        <Layout style={{ minHeight: "100vh" }}>
            <HeaderTools />
            <Layout>
                <SideMenu />
                <Content style={{ margin: "0 16px" }}>
                    <Switch>
                        <Route path="/accounts">
                            <AccountsPage />
                        </Route>
                    </Switch>
                </Content>
            </Layout>
        </Layout>
    );
};

export default App;
