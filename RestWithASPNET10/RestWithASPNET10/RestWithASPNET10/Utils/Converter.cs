namespace RestWithASPNET10.Tools
{
    public static class Converter
    {
		public static decimal ToDecimal(this string strNumber)
		{
			if (decimal.TryParse(strNumber,
					System.Globalization.NumberStyles.Any,
					System.Globalization.NumberFormatInfo.InvariantInfo,
					out decimal decimalValue))
			{
				return decimalValue;
			}
			return 0;
		}
	}
}
