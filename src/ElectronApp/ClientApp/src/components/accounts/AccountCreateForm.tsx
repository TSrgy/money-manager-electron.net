import { Form, Input } from "antd";

import Modal from "antd/lib/modal/Modal";
import React from "react";
import { createAccount } from "../../store/accountsSlice";
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

        dispatch(
            createAccount({
                accountName: accountName,
                callback: () => {
                    form.resetFields();
                    onReadyToClose(true);
                }
            })
        );
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
