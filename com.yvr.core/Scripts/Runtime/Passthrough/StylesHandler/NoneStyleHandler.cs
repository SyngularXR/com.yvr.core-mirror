namespace YVR.Core
{
    internal class NoneStyleHandler : IStyleHandler
    {
        public bool isValid => true;

        public void ApplyStyleSettings(ref PassthroughStyle style)
        {
        }

        public void Update(LutSettings settings)
        {
        }

        public void Clear()
        {
        }
    }
}