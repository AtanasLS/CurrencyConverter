export interface History {
        id: number | null;
        dateCreated: Date | null;
        sourceCurrency: string;
        targetCurrency: string;
        valueCurrency: number;
        result: number | null;
}