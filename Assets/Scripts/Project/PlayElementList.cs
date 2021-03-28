using System.Collections.Generic;
using System.Linq;
using PlayElements;
using UnityEngine;

namespace Project
{
    public class PlayElementList
    {
        //Keep ordered by time !
        private List<PlayElement> _elements;

        public List<PlayElement> GetElementsByTime(float time, float threshold = 0.01f)
        {
            var result = new List<PlayElement>();
            for (var i = 0; i < _elements.Count; i++)
            {
                var timeDistance = _elements[i].Time - time;
                if (Mathf.Abs(timeDistance) <= threshold)
                {
                    result.Add(_elements[i]);
                }
            }

            return result;
        }

        public void RemoveElement(PlayElement element) => _elements.Remove(element);

        public void AddElements(IEnumerable<PlayElement> elements)
        {
            _elements.AddRange(elements);
            _elements = _elements.OrderBy(x => x.Time).ToList();
        }

        public void AddElement(PlayElement element)
        {
            var firstBigger = _elements.FindIndex(x => x.Time > element.Time);
            var index = firstBigger - 1;
            index = index < 0 ? 0 : index;
            index = index > _elements.Count ? _elements.Count : index;

            _elements.Insert(index, element);
        }
    }
}