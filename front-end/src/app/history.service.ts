import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  baseURL : string;


  constructor(private http: HttpClient) {
    this.baseURL = environment.production ? environment.apiUrl : environment.testApiUrl
   }

  createNewHistory(sourceCurrency: string, targetCurrency: string, valueCurrency: number){
    return this.http.post<History>(this.baseURL + 'createCurrency', {
        id: 0,
        dateCreated: null,
        sourceCurrency: sourceCurrency,
        targetCurrency: targetCurrency,
        valueCurrency: valueCurrency,
        result: 0
    }); 
  }
  getPreviousConversions() : Observable<any[]>{
    return this.http.get<any[]>(this.baseURL + 'currency').pipe(
      catchError((error: any) => {
        console.error('An error occurred:', error);
        return throwError(error); 
      })
    );  }
}
