# ExtremeNumbers

Below 0 usage:
MinimalNumbersResult result = ExtremeNumbers.MinimalNumbers.Parse("123,100000");

Assert.IsTrue(result.Value == "123,100k.000m");

Above 0 usage:
ExtremeNumbersResult result = ExtremeNumbers.ExtremeNumbers.Parse("1000000000000000000");

Assert.IsTrue(result.Value == "1o.000B.000T.000M.000m.000k.000");

Convert back to decimal
decimal value = ExtremeNumbers.ExtremeNumbers.ToDecimal(new ExtremeNumbersResult("10k.000,00"));

Assert.IsTrue(value == 10000);

See also unit tests project, for more examples.
