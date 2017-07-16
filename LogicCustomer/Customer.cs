using System;
using System.Globalization;
namespace LogicCustomer
{
	public class Customer : IFormattable
	{
		public string Name { get; private set; }

		public string ContactPhone { get; private set; }

		public decimal Revenue { get; private set; }

		public Customer(string name, string contactphone, decimal revenue)
		{
			Name = name;
			ContactPhone = contactphone;
			Revenue = revenue;
		}

		public override string ToString()
		{
			 return this.ToString("G", CultureInfo.CurrentCulture);
		}

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
