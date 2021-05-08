import { FileAddOutlined } from "@ant-design/icons";
import { Header } from "antd/lib/layout/layout";
import { Menu } from "antd";
import React from "react";
import { useTranslation } from "react-i18next";

export const HeaderTools: React.FC = () => {
    const { t } = useTranslation();
    return (
        <Header>
            <Menu theme="dark" mode="horizontal" selectable={false}>
                <Menu.Item key="addAccount" icon={<FileAddOutlined />}>
                    {t("addAccount")}
                </Menu.Item>
            </Menu>
        </Header>
    );
};
