import { Selector } from 'testcafe';

fixture(`Currency Converter App`)
    .page(`http://213.199.36.5:4201/`);

test('Convert button should be present and clickable', async t => {
    const convertButton = Selector('.flex-button');
    await t.expect(convertButton.exists).ok();
    await t.click(convertButton);
});
