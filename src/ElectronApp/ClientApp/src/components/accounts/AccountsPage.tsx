import { Account, selectAllAccounts } from "../../store/accountsSlice";
import { Card, Col, PageHeader, Row } from "antd";
import { Link, matchPath, useHistory, useLocation, useRouteMatch } from "react-router-dom";

import { AccountView } from "./AccountView";
import React from "react";
import { useSelector } from "react-redux";
import { useTranslation } from "react-i18next";

export const AccountsPage: React.FC = () => {
    const { t } = useTranslation();
    const match = useRouteMatch();
    const accountPath = `${match.path}/:accountId`;
    const allAccounts = useSelector(selectAllAccounts);
    const history = useHistory();

    const location = useLocation();
    const accountMatch = matchPath<{ accountId?: string }>(location.pathname, {
        path: accountPath,
        exact: false
    });

    let matchedAccount: Account | undefined;
    if (accountMatch != null) {
        const accountId = parseInt(accountMatch.params.accountId || "");
        matchedAccount = allAccounts.find((a) => a.id === accountId);
    }

    const renderAccountCard = (account: Account) => {
        return (
            <Card>
                <Link to={`${match.url}/${account.id}`}>{account.title}</Link>
            </Card>
        );
    };

    let pageContent: React.ReactElement;
    let onBack: (() => void) | undefined;
    let subTitle: string | undefined;

    if (matchedAccount != null) {
        subTitle = matchedAccount.title;
        pageContent = <AccountView account={matchedAccount} />;
        onBack = () => {
            history.push(match.url);
        };
    } else {
        pageContent = (
            <Row gutter={[16, 16]}>
                {allAccounts.map((a) => (
                    <Col key={a.id} span={6}>
                        {renderAccountCard(a)}
                    </Col>
                ))}
            </Row>
        );
    }

    return (
        <PageHeader title={t("bankAccounts")} subTitle={subTitle} onBack={onBack}>
            {pageContent}
        </PageHeader>
    );
};
