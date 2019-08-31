using System;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace XUnit.ValueTuples
{
	/// <summary>
	/// Member data attribute that sources data from IEnumerable&lt;T&gt; instead of
	/// IEnumerable&lt;object[]&gt;.  The Theory function this is used on must take a single parameter of type T
	/// in order for this attribute to function properly.
	/// </summary>
	[DataDiscoverer("Xunit.Sdk.MemberDataDiscoverer", "xunit.core")]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public sealed class MemberDataEnumerableAttribute : MemberDataAttributeBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MemberDataAttribute"/> class.
		/// </summary>
		/// <param name="memberName">The name of the public static member on the test class that will provide the test data</param>
		/// <param name="parameters">The parameters for the member (only supported for methods; ignored for everything else)</param>
		public MemberDataEnumerableAttribute(string memberName, params object[] parameters)
			: base(memberName, parameters) { }

		/// <inheritdoc/>
		protected override object[] ConvertDataItem(MethodInfo testMethod, object item)
		{
			if (item == null)
				return null;

			return new object[] { item };
		}
	}
}
