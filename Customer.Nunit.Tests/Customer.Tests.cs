using NUnit.Framework;
using System;
namespace LogicCustomer.NUnit.Tests
{
	[TestFixture()]
	public class CustomerTests
	{
		[TestCase("A", null, ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
		[TestCase("s", null, ExpectedResult = "Customer record: Jeffrey Richter")]
		[TestCase("D", null, ExpectedResult = "Customer record: +1 (425) 555-0100")]
		[TestCase("f", null, ExpectedResult = "Customer record: 1,000,000.00")]
		[TestCase("G", null, ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
		public string ToString_PositiveTests(string format, IFormatProvider formatProvider)
		{
			Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
			return customer.ToString(format, formatProvider);
		}

	}
}
