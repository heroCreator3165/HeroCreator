namespace PlayElements
{
    public class Sound : PlayElement
    {
        public string ClipPath { get; set; }
        public float StartTime { get; set; } = 0f;
        public float Duration { get; set; } = -1;


        public override string[] SerializeValues()
        {
            return new[] {Time.ToString(), ClipPath, StartTime.ToString(), Duration.ToString()};
        }

        public override void Deserialize(string[] values)
        {
            base.Deserialize(values);
            ClipPath = values[1];
            StartTime = float.Parse(values[2]);
            Duration = float.Parse(values[3]);
        }
    }
}