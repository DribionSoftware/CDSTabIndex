// Guids.cs
// MUST match guids.h
using System;

namespace CDSTabIndexPackage.CDSTabIndex
{
    static class GuidList
    {
        public const string guidCDSTabIndexPackagePkgString = "4e9d1e67-7d82-43d1-a5d1-b351353894e7";
        public const string guidCDSTabIndexPackageCmdSetString = "504b6127-ab51-4a81-90a3-324719b53b2a";
        public static readonly Guid guidCDSTabIndexPackageCmdSet = new Guid(guidCDSTabIndexPackageCmdSetString);
    }
}