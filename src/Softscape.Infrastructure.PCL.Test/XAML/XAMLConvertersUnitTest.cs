using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Softscape.Infrastructure.PCL.XAML;

namespace Softscape.Infrastructure.PCL.Test.XAML
{
    [TestClass]
	// ReSharper disable once InconsistentNaming
    public class XAMLConvertersUnitTest
    {
		[TestMethod]
		public void Int64FormatConverterTestMethod()
		{
			var converter = new Int64FormatConverter();
			converter.Convert(null, typeof(String), null, "ro");
		}
    }
}
