import { Selector } from 'testcafe';

fixture(`Currency Converter App`)
    .page('http://213.199.36.5:4201/');

test('Amount input field should be present', async t => {
    const amountInput = Selector('#amount');
    await t.expect(amountInput.exists).ok();
});
