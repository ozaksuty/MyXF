namespace MyXF.Client.mobilebase.Selectors.interfaces
{
    public interface IApiRequest<out T>
    {
        T Speculative { get; }
        T UserInitiated { get; }
        T Background { get; }
    }
}