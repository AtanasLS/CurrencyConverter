import { Component, OnInit } from '@angular/core';
import { HistoryService } from './history.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'front-end';
  
  historyResponse: any;
  amount: number = 0;
  fromCurrency: string = 'USD';
  toCurrency: string = 'JPY';
  result: number = 0; 
  all: any[] = [];
  previousConversions: any[] = [];


  constructor(private historyService: HistoryService) {}


  ngOnInit(): void {
    this.getPreviousConversions();
  }

  convertCurrency() {
    this.historyService.createNewHistory(this.fromCurrency, this.toCurrency, this.amount).subscribe(
      (response: any) => { 
        this.result = response.responseData.result; 
        console.log('Converted Amount:', this.result);
        console.log('History saved', response);
      },
      (error) => {
        console.error('Error saving history:', error);
      }
    );
  }
  getPreviousConversions() {
    this.historyService.getPreviousConversions().subscribe(
      (response: any) => {
        this.previousConversions = response.responseData;
        this.all = this.previousConversions;

        console.log('Here are the previousCurrencies: ',this.all);
      },
      (error: any) => {
        console.error('Error with getting the previous conversions:', error);
      }
    );
  }
}
