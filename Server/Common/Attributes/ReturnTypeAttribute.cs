﻿using System;

namespace Common.Attributes
{
    /// <summary>
    /// The expected Typescript return type
    /// </summary>
    public class ReturnTypeAttribute : Attribute
    {
        public ReturnTypeAttribute(string type)
        {
        }
    }
}
