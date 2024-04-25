import { Selector } from 'testcafe';

fixture('Currency Converter App')
  .page('http://213.199.36.5:4201/'); // Replace with your app's URL

  
  const amountInput = Selector('#amount');
  const fromCurrencySelect = Selector('#fromCurrency');
  const fromCurrencyOption = fromCurrencySelect.find('option');
  const toCurrencySelect = Selector('#toCurrency');
  const toCurrencyOption = toCurrencySelect.find('option');
  const convertButton = Selector('.flex-button');
  const convertedAmount = Selector('#convertedAmount');


test('Convert currency', async (t) => {
  // Input values
  
  // Set input values
  await t
  .typeText(amountInput, '100')
  .click(fromCurrencySelect)
  .click(fromCurrencyOption.withText('USD'))
  .expect(fromCurrencySelect.value).eql('USD')
   // Wait for the target currency dropdown to be visible
  .click(toCurrencySelect)
  .click(toCurrencyOption.withText('EUR'))
  .expect(toCurrencySelect.value).eql('EUR')
  .wait(1000)
 
  .click(convertButton)

  // Verify the converted amount
  .expect(convertedAmount.textContent).eql('93'); // Adjust the selector as needed
});
