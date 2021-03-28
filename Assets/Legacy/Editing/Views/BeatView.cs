using Legacy.Playing.Elements;

namespace Legacy.Editing.Views
{
    public class BeatView : PlayElementView
    {
        private ShowBeat beatComponent;

        protected override void Start()
        {
            beatComponent = beatComponent ?? GetComponent<ShowBeat>();
            base.Start();
        }

        public override PlayElement GetElement()
        {
            return beatComponent ?? (beatComponent = GetComponent<ShowBeat>());
        }
    }
}
