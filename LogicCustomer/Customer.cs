using System;
using System.Globalization;
namespace LogicCustomer
{
	public class Customer : IFormattable
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }
		/// <summary>
		/// Gets the contact phone.
		/// </summary>
		/// <value>The contact phone.</value>
		public string ContactPhone { get; private set; }
		/// <summary>
		/// Gets the revenue.
		/// </summary>
		/// <value>The revenue.</value>
		public decimal Revenue { get; private set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LogicCustomer.Customer"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="contactphone">Contactphone.</param>
		/// <param name="revenue">Revenue.</param>
		public Customer(string name, string contactphone, decimal revenue)
		{
			Name = name;
			ContactPhone = contactphone;
			Revenue = revenue;
		}
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:LogicCustomer.Customer"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:LogicCustomer.Customer"/>.</returns>
		public override string ToString()
		{
			 return this.ToString("G", CultureInfo.CurrentCulture);
		}
		/// <summary>
		/// Tos the string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="format">Format.</param>
		/// <param name="formatProvider">Format provider.</param>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (string.IsNullOrEmpty(format)) format = "G";
			if (ReferenceEquals(formatProvider, null)) formatProvider = CultureInfo.InvariantCulture;

			switch (format.ToUpperInvariant())
			{
				case "A": return $"Customer record: {Name}, {ContactPhone}, {Revenue.ToString("N", formatProvider)}";
                case "S": return "Customer record: " + Name;
                case "D": return "Customer record: " + ContactPhone;
                case "F": return "Customer record: " + Revenue.ToString("N", formatProvider);
				case "G": return $"Customer record: {Name}, {ContactPhone}";
				default:
					throw new FormatException($"The format of '{format}' is invalid.");
			}
		}
	 }
}
