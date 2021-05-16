import { AccountType, ApiClient, CreateAccountCommand } from "../../ApiClient";
import { Form, Input } from "antd";
import { createAccountAction, createAccountFailedAction, createAccountSuccessAction } from "../../store/accounts/actionCreators";

import { Account } from "../../store/accounts/types";
import Modal from "antd/lib/modal/Modal";
import React from "react";
import { useDispatch } from "react-redux";
import { useTranslation } from "react-i18next";

interface IProps {
    visible: boolean;
    onReadyToClose: (isCreated: boolean) => void;
}

interface IForm {
    name: string;
}

export const AccountCreateForm: React.FC<IProps> = ({ visible, onReadyToClose }) => {
    const { t } = useTranslation();
    const dispatch = useDispatch();
    const [form] = Form.useForm<IForm>();

    const handleOk = async () => {
        const formFields = await form.validateFields();

        const accountName = formFields.name;
        dispatch(createAccountAction(accountName));
        try {
            const command = new CreateAccountCommand({
                name: accountName,
                accountType: AccountType.Checking,
                currencyId: 1,
                initialBalance: 0,
                notes: ""
            });

            const client = new ApiClient();
            const accountId = await client.accounts_Create(command);
            const account = await client.accounts_GetById(accountId);
            dispatch(createAccountSuccessAction(new Account(account.id, account.name)));
            form.resetFields();
            onReadyToClose(true);
        } catch (e) {
            dispatch(createAccountFailedAction());
        }
    };

    return (
        <Modal title={t("addAccount")} visible={visible} onOk={handleOk} onCancel={() => onReadyToClose(false)}>
            <Form form={form} name="create_account_form">
                <Form.Item
                    name="name"
                    label={t("accountName")}
                    rules={[
                        {
                            required: true,
                            message: "Name is req"
                        }
                    ]}
                >
                    <Input />
                </Form.Item>
            </Form>
        </Modal>
    );
};
