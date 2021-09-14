const PasswordVerifier = require("./PasswordVerifier.js");

test("shouldFail", () => {
  let x = new PasswordVerifier();
  expect(false).toBe(true);
});
