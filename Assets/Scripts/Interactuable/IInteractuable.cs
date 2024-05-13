namespace BGS.Interactuable
{
    public interface IInteractuable
    {
        string Info { get; }

        void Interact();

        void StartHighlight();

        void StopHighlight();
    }
}