import { Redirect, Route, Switch } from "react-router-dom";

import { AccountsPage } from "./accounts/AccountsPage";
import { HeaderTools } from "./HeaderTools";
import { Layout } from "antd";
import React from "react";
import { SideMenu } from "./SideMenu";

const { Content } = Layout;

const App: React.FC = () => {
    return (
        <Layout style={{ minHeight: "100vh" }}>
            <HeaderTools />
            <Layout>
                <SideMenu />
                <Content style={{ margin: "0 16px" }}>
                    <Switch>
                        <Route exact path="/">
                            <Redirect to="/accounts" />
                        </Route>
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
