import React, { useState } from "react";

import { AccountCreateForm } from "./accounts/AccountCreateForm";
import { FileAddOutlined } from "@ant-design/icons";
import { Header } from "antd/lib/layout/layout";
import { Menu } from "antd";
import { useTranslation } from "react-i18next";

export const HeaderTools: React.FC = () => {
    const { t } = useTranslation();
    const [visibleOfAccountCreateForm, setVisibleOfAccountCreateForm] = useState(false);
    return (
        <Header>
            <Menu theme="dark" mode="horizontal" selectable={false}>
                <Menu.Item key="addAccount" icon={<FileAddOutlined />} onClick={() => setVisibleOfAccountCreateForm(true)}>
                    {t("addAccount")}
                </Menu.Item>
            </Menu>
            <AccountCreateForm visible={visibleOfAccountCreateForm} onReadyToClose={() => setVisibleOfAccountCreateForm(false)} />
        </Header>
    );
};
