using System;

namespace PlayElements
{
    public abstract class PlayElement
    {
        public float Time { get; set; }

        #region Serialization

        public static PlayElement Parse(string serializedElement)
        {
            var split = serializedElement.Split('{', '}');
            var type = Type.GetType(split[0]);
            if (type == null) return null;
            var element = Activator.CreateInstance(type) as PlayElement;
            element?.Deserialize(split[1].Split(','));
            return element;
        }

        public string Serialize()
        {
            return GetType() + "{" + string.Join(",", SerializeValues()) + "}";
        }

        public virtual string[] SerializeValues()
        {
            return new[] {Time.ToString()};
        }

        public virtual void Deserialize(string[] values)
        {
            Time = float.Parse(values[0]);
        }

        #endregion
    }
}