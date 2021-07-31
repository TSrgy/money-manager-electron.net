import { AccountType, ApiClient, CreateAccountCommand } from "../ApiClient";
import { EntityState, createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";

import { RootState } from ".";

export interface AccountsState {
    readonly loading: boolean;
    readonly accounts: EntityState<Account>;
    readonly selectedAccountdId?: number;
}

export interface Account {
    id: number;
    title: string;
}

export const fetchAccounts = createAsyncThunk("accounts/fetchAccounts", async () => {
    const client = new ApiClient();
    const data = await client.accounts_Get();

    let payload: Account[] = [];
    if (data.accounts) {
        payload = data.accounts.map((x) => {
            return { id: x.id, title: x.name };
        });
    }
    return payload;
});

export const createAccount = createAsyncThunk("accounts/createAccount", async (arg: { accountName: string; callback: () => void }) => {
    const command = new CreateAccountCommand({
        name: arg.accountName,
        accountType: AccountType.Checking,
        currencyId: 1,
        initialBalance: 0,
        notes: ""
    });

    const client = new ApiClient();
    const accountId = await client.accounts_Create(command);
    const account = await client.accounts_GetById(accountId);
    arg.callback();
    return { id: account.id, title: account.name };
});

const accountsAdapter = createEntityAdapter<Account>({
    selectId: (account) => account.id
});

const initialState: AccountsState = {
    accounts: accountsAdapter.getInitialState(),
    loading: false
};

export const accountsSlice = createSlice({
    name: "accounts",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(createAccount.pending, (state) => {
            state.loading = true;
        });
        builder.addCase(createAccount.rejected, (state) => {
            state.loading = false;
        });
        builder.addCase(createAccount.fulfilled, (state, action) => {
            accountsAdapter.addOne(state.accounts, action.payload);
            state.loading = false;
        });

        builder.addCase(fetchAccounts.pending, (state) => {
            state.loading = true;
        });
        builder.addCase(fetchAccounts.rejected, (state) => {
            state.loading = false;
        });
        builder.addCase(fetchAccounts.fulfilled, (state, action) => {
            accountsAdapter.setAll(state.accounts, action.payload);
            state.loading = false;
        });
    }
});

export default accountsSlice.reducer;

export const {
    selectAll: selectAllAccounts,
    selectById: selectAccountById,
    selectEntities: selectAccountEntities,
    selectIds: selectAccountIds,
    selectTotal: selectTotalAccounts
} = accountsAdapter.getSelectors((state: RootState) => state.accounts.accounts);
