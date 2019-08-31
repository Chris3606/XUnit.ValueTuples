using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit;
using Xunit.Sdk;

namespace XUnit.ValueTuples
{
	/// <summary>
	/// Improved member data attribute that can source data from IEnumerable&lt;ValueTuple&gt; in addition to
	/// IEnumerable&lt;object[]&gt;.
	/// </summary>
	[DataDiscoverer("Xunit.Sdk.MemberDataDiscoverer", "xunit.core")]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	public sealed class MemberDataTupleAttribute : MemberDataAttributeBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MemberDataAttribute"/> class.
		/// </summary>
		/// <param name="memberName">The name of the public static member on the test class that will provide the test data</param>
		/// <param name="parameters">The parameters for the member (only supported for methods; ignored for everything else)</param>
		public MemberDataTupleAttribute(string memberName, params object[] parameters)
			: base(memberName, parameters) { }

		/// <inheritdoc/>
		protected override object[] ConvertDataItem(MethodInfo testMethod, object item)
		{
			if (item == null)
				return null;

			if (item is object[] array)
				return array;

			if (item is ITuple tuple)
			{
				List<object> objs = new List<object>(tuple.Length);
				for (int i = 0; i < tuple.Length; i++)
					objs.Add(tuple[i]);

				return objs.ToArray();
			}

			throw new ArgumentException($"Property {MemberName} on {MemberType ?? testMethod.DeclaringType} yielded an item that is not an object[] or ITuple");
		}
	}
}
