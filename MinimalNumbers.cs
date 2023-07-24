namespace ExtremeNumbers
{
    public static class MinimalNumbers
    {
        /// <summary>
        /// Gets the ExtremeNumber notation for the string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReadableMinimalNumber(this string value)
        {
            return Parse(value).Value;
        }

        /// <summary>
        /// The input string to parse. For example 0,1000000.
        /// </summary>
        public static MinimalNumbersResult Parse(string value)
        {
            //0,0000001

            if (string.IsNullOrEmpty(value)) return null;

            // Remove unwanted chars
            value = value.Replace(".", string.Empty);

            // Initialize
            // Get the number from given parameter.
            // right to left interpetation.
            string bl = value.Split(",")[1];
            decimal segments = Convert.ToDecimal(bl.Length) / 3;

            //Execute method
            //No segments return original.
            if (segments == 0) return new MinimalNumbersResult(value);
            else
            {
                int position;
                //Interpert the segments.
                for (decimal i = 0; i <= segments; i++)
                {
                    //Get position and insert the number markers.
                    position = Convert.ToInt32(i) * 3;
                    
                    switch (position)
                    {
                        case 3: bl = bl.Insert(position, "k."); break;
                        case 6: bl = bl.Insert(position + 2, "m."); break;
                        case 9: bl = bl.Insert(position + 4, "M."); break;
                        case 12: bl = bl.Insert(position + 6, "T."); break;
                        case 15: bl = bl.Insert(position + 8, "B."); break;
                        case 18: bl = bl.Insert(position + 10, "o."); break;
                        case 21: bl = bl.Insert(position + 12, "N."); break;
                        case 24: bl = bl.Insert(position + 14, "E."); break;
                        case 27: bl = bl.Insert(position + 16, "S."); break;
                        default: break;
                    }
                }
            }

            // clean last .
            bl = bl.Substring(0, bl.Length - 1);

            //Return the value, with comma digits when present.
            return new MinimalNumbersResult($"{value.Split(",")[0]},{bl}");
        }

        /// <summary>
        /// Converts a ExtremeNumbersResult to decimal.
        /// </summary>
        /// <param name="item">The item that needs to be converted.</param>
        public static decimal ToDecimal(MinimalNumbersResult item)
        {
            // Clean ExtremeNumber.
            item.Value = item.Value.Replace(".", string.Empty);
            item.Value = item.Value.Replace("k", string.Empty);
            item.Value = item.Value.Replace("m", string.Empty);
            item.Value = item.Value.Replace("M", string.Empty);
            item.Value = item.Value.Replace("T", string.Empty);
            item.Value = item.Value.Replace("B", string.Empty);
            item.Value = item.Value.Replace("o", string.Empty);
            item.Value = item.Value.Replace("N", string.Empty);
            item.Value = item.Value.Replace("E", string.Empty);
            item.Value = item.Value.Replace("S", string.Empty);

            return Convert.ToDecimal(item.Value);
        }
    }

    public class MinimalNumbersResult
    {
        /// <summary>
        /// Gets or sets the value of the result.
        /// </summary>
        public string Value;

        /// <summary>
        /// Indicates if the value has any characters.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Value);
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="value"></param>
        public MinimalNumbersResult(string value)
        {
            this.Value = value;
        }
    }
}
