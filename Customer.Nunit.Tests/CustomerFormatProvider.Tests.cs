using NUnit.Framework;
using System;
namespace LogicCustomer.NUnit.Tests
{
	[TestFixture()]
	public class CustomerFormatProviderTests
	{
		[TestCase("A1", null, ExpectedResult = "Full Customer record(name,phone,revenue): Jeffrey Richter, +1 (425) 555-0100, 1,000,000.00")]
		[TestCase("s1", null, ExpectedResult = "Short Customer record(name): Jeffrey Richter")]
		[TestCase("D1", null, ExpectedResult = "Short Customer record(phone): +1 (425) 555-0100")]
		[TestCase("f1", null, ExpectedResult = "Short Customer record(revenue): 1,000,000.00")]
		[TestCase("G1", null, ExpectedResult = "Default Customer record(name,phone): Jeffrey Richter, +1 (425) 555-0100")]
		public string ToString_PositiveTests(string format, IFormatProvider formatProvider)
		{
			CustomerFormatProvider c = new CustomerFormatProvider();
			Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
            return c.Format(format, customer, formatProvider);
		}
		[Test]
		public void ToString_ThrowsFormatException()
		{
			CustomerFormatProvider c = new CustomerFormatProvider();
			Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);
			Assert.Throws<FormatException>(() => c.Format("a2", customer, null));
		}
	}
}