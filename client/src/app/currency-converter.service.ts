import { Injectable } from "@angular/core";
import { environment } from "../environments/environment.prod";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class CurrencyConverterService{
baseURL = environment.apiUrl;

constructor(private http: HttpClient){}

createNewHistory(sourceCurrency: string, targetCurrency: string, valueCurrency: number){
    return this.http.post<History>(this.baseURL + "/createCurrency", {
        id: 0,
        dateCreated: null,
        sourceCurrency: sourceCurrency,
        targetCurrency: targetCurrency,
        valueCurrency: valueCurrency,
        result: 0
    });
}

}