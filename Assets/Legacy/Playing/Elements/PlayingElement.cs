namespace Legacy.Playing.Elements
{
    public interface PlayingElement
    {
        float StartPosition { get; set; }
        float EndPosition { get; set; }

        float Duration { get; }
    }
}