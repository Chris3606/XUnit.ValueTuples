# XUnit.ValueTuples
A small library that contains a custom XUnit attribute for using IEnumerables of value tuples and specific types as the data source for Theories.

# Platform Support
This library supports .NET Framework >= v4.7.1, .NET Core >= v2.0, and anything implementing .NET Standard >= v2.1.  Although the `ITuple` interface on which this library depends is available in .NET Framework v4.7.1 and .NET Core v2.0, it is not implemented into .NET Standard 2.0.  As such, the package is multi-targeted to .NET Framework, Core, and the oldest version of .NET Standard that does support `ITuple`.  This should cover most possible use cases.

It is possible to accomplish iteration over arbitrary tuples without `ITuple` by using reflection (and thus to do so before the afforementioned versions), however it is prone to error and as such isn't used for this library.  The reflection method (along with the `ITuple`-based method this library uses) is described [here](https://josephwoodward.co.uk/2017/04/csharp-7-valuetuple-types-and-their-limitations).