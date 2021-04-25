import "./App.css";

import { Breadcrumb, Layout, Menu } from "antd";
import { FolderOutlined, TeamOutlined, UserOutlined } from "@ant-design/icons";

import React from "react";
import { SideMenu } from "./SideMenu";

const { Header, Content } = Layout;

const App: React.FC = () => {
    return (
        <Layout style={{ minHeight: "100vh" }}>
            <SideMenu />
            <Layout className="site-layout">
                <Header className="site-layout-background" style={{ padding: 0 }} />
                <Content style={{ margin: "0 16px" }}>
                    <Breadcrumb style={{ margin: "16px 0" }}>
                        <Breadcrumb.Item>User</Breadcrumb.Item>
                        <Breadcrumb.Item>Bill</Breadcrumb.Item>
                    </Breadcrumb>
                    <div className="site-layout-background" style={{ padding: 24, minHeight: 360 }}>
                        Bill is a cat.
                    </div>
                </Content>
            </Layout>
        </Layout>
    );
};

export default App;
