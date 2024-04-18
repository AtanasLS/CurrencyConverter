import { Component } from '@angular/core';
import { HistoryService } from './history.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'front-end';
  
  historyResponse: any;
  amount: number = 0;
  fromCurrency: string = 'USD';
  toCurrency: string = 'JPY';
  result: number = 0; 

  constructor(private historyService: HistoryService) {}

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
}
