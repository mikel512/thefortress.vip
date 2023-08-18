using System;

namespace vDomain.Attributes;

/// <summary>
/// The expected Typescript return type
/// </summary>
public class ReturnTypeAttribute : Attribute
{
    public ReturnTypeAttribute(string type)
    {
    }
}
