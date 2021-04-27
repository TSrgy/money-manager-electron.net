import * as actionCreators from "./actionCreators";

export interface AccountsState {
    readonly loading: boolean;
    readonly accounts: Account[];
    readonly selectedAccountdId?: number;
}

export class Account {
    id: number;
    title: string;

    /**
     *
     */
    constructor(id: number, title: string) {
        this.id = id;
        this.title = title;
    }
}

type InferValueTypes<T> = T extends { [key: string]: infer U } ? U : never;

export type ActionTypes = ReturnType<InferValueTypes<typeof actionCreators>>;
