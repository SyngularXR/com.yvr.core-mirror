namespace YVR.Core
{
    internal interface IStyleHandler
    {
        void ApplyStyleSettings(ref PassthroughStyle style);
        void Update(LutSettings settings);
        bool isValid { get; }
        void Clear();
    }
}