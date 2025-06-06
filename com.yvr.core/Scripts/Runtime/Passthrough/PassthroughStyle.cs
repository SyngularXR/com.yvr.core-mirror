using System;
using System.Collections;
using System.Collections.Generic;

namespace YVR.Core
{
    public struct PassthroughStyle
    {
        public PassthroughColorMapType textureColorMapType;
        public UInt64 lutSource;
        public float lutWeight;

        public override string ToString()
        {
            return $"textureColorMapType:{textureColorMapType}, " +
                   $"lutSource:{lutSource}, " +
                   $"lutWeight:{lutWeight}";
        }
    }
}

