using System;
using System.Globalization;
namespace LogicCustomer
{
	public class CustomerFormatProvider: IFormatProvider, ICustomFormatter
	{
		/// <summary>
		/// Gets the format.
		/// </summary>
		/// <returns>The format.</returns>
		/// <param name="formatType">Format type.</param>
		public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;
		/// <summary>
		/// Format the specified format, arg and formatProvider.
		/// </summary>
		/// <returns>The format.</returns>
		/// <param name="format">Format.</param>
		/// <param name="arg">Argument.</param>
		/// <param name="formatProvider">Format provider.</param>
		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			Customer customer = arg as Customer;

            if (ReferenceEquals(customer, null)) throw new ArgumentNullException($"{nameof(customer)} is null!");
            if (string.IsNullOrEmpty(format)) format = "G1";
            if (ReferenceEquals(formatProvider, null)) formatProvider = CultureInfo.InvariantCulture;

			switch (format.ToUpperInvariant())
			{
				case "A1": return $"Full Customer record(name,phone,revenue): {customer.Name}, {customer.ContactPhone}, {customer.Revenue.ToString("N", formatProvider)}";
				case "S1": return "Short Customer record(name): " + customer.Name;
				case "D1": return "Short Customer record(phone): " + customer.ContactPhone;
				case "F1": return "Short Customer record(revenue): " + customer.Revenue.ToString("N", formatProvider);
				case "G1": return $"Default Customer record(name,phone): {customer.Name}, {customer.ContactPhone}";
				default:
					try
					{
						return HandleOtherFormats(format, arg);
					}
					catch (FormatException e)
					{
						throw new FormatException($"The format of '{format}' is invalid.", e);
					}
			}
		}
		/// <summary>
		/// Handles the other formats.
		/// </summary>
		/// <returns>The other formats.</returns>
		/// <param name="format">Format.</param>
		/// <param name="arg">Argument.</param>
		private string HandleOtherFormats(string format, object arg)
		{
			if (arg is IFormattable)
				return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
			else if (arg != null)
				return arg.ToString();
			else
				return String.Empty;
		}
		
	}
}
