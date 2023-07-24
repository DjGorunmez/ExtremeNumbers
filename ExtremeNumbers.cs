namespace ExtremeNumbers
{

    /// <summary>
    /// This class parses extreme numbers to readable objects.
    /// </summary>
    public static class ExtremeNumbers
    {
        /// <summary>
        /// Gets the ExtremeNumber notation for the string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReadableExtremeNumber(this string value)
        {
            return Parse(value).Value;
        }

        /// <summary>
        /// Parses a extreme number to readable string.
        /// </summary>
        /// <param name="value">The input string to parse. For example 1000000,00.</param>
        public static ExtremeNumbersResult Parse(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            // Remove unwanted chars
            value = value.Replace(".", string.Empty);

            // Initialize
            // Get the number from given parameter.
            // right to left interpetation.
            string bl;
            decimal segments;
            bool hasComma = false;
            if (value.Contains(","))
            {
                bl = value.Split(",")[0];
                hasComma = true;
            }
            else bl = value;

            //Calculate segments.
            segments = Convert.ToDecimal(bl.Length) / 3;

            //Execute method
            //No segments return original.
            if (segments == 0) return new ExtremeNumbersResult(value);
            else
            {
                int position;
                int replacePosition;
                //Interpert the segments.
                for (decimal i = segments; i >= 0 ; i-- )
                {
                    //Get position and insert the number markers.
                    position = Convert.ToInt32(i) * 3;
                    replacePosition = bl.Length - position;

                    switch (position)
                    {
                        case 3:  bl = bl.Insert(replacePosition, "k."); break;
                        case 6:  bl = bl.Insert(replacePosition, "m."); break;
                        case 9:  bl = bl.Insert(replacePosition, "M."); break;
                        case 12: bl = bl.Insert(replacePosition, "T."); break;
                        case 15: bl = bl.Insert(replacePosition, "B."); break;
                        case 18: bl = bl.Insert(replacePosition, "o."); break;
                        case 21: bl = bl.Insert(replacePosition, "N."); break;
                        case 24: bl = bl.Insert(replacePosition, "E."); break;
                        case 27: bl = bl.Insert(replacePosition, "S."); break;
                        default: break;
                    }
                }
            }

            //Return the value, with comma digits when present.
            return new ExtremeNumbersResult(bl + (hasComma ? $",{value.Split(",")[1]}" : ""));
        }

        /// <summary>
        /// Converts a ExtremeNumbersResult to decimal.
        /// </summary>
        /// <param name="item">The item that needs to be converted.</param>
        public static decimal ToDecimal(ExtremeNumbersResult item)
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

    public class ExtremeNumbersResult
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
        public ExtremeNumbersResult(string value)
        {
            this.Value = value;
        }
    }
}