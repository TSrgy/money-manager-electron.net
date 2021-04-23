interface IAccount {
    id: number
    title: string
}

type AccountsState = {
    accounts: IAccount[]
    selectedAccount: number
}

type AccountAction = {
    type: string
    account: IAccount
  }