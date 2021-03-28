namespace PlayElements
{
    public class Text : PlayElement
    {
        public string DisplayText { get; set; }
        public float StartTime { get; set; } = 0f;
        public float Duration { get; set; } = -1;


        public override string[] SerializeValues()
        {
            return new[] { Time.ToString(), DisplayText, StartTime.ToString(), Duration.ToString() };
        }

        public override void Deserialize(string[] values)
        {
            base.Deserialize(values);
            DisplayText = values[1];
            StartTime = float.Parse(values[2]);
            Duration = float.Parse(values[3]);
        }
    }
}