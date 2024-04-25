import { Selector } from 'testcafe';

fixture(`Currency Converter App`)
    .page('http://localhost:4200');

test('Amount input field should be present', async t => {
    const amountInput = Selector('#amount');
    await t.expect(amountInput.exists).ok();
});
