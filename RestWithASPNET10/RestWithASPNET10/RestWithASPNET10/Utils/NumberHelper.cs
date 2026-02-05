namespace RestWithASPNET10.Tools
{
    public static class NumberHelper
    {
		public static bool IsNumeric(this string strNumber)
		{
			return decimal.TryParse(
						strNumber,
						System.Globalization.NumberStyles.Any,
						System.Globalization.NumberFormatInfo.InvariantInfo,
						out decimal _);
		}
	}
}
