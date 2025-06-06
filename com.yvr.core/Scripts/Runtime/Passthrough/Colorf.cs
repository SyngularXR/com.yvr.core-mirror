using System.Runtime.InteropServices;

namespace YVR.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Colorf
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public override string ToString()
        {
            return $"Colorf(r: {r}, g: {g}, b: {b}, a: {a})";
        }
    }
}