export interface History {
        id: number;
        dateCreated: Date;
        sourceCurrency: string | null;
        targetCurrency: string | null;
        valueCurrency: number;
        result: number;
}