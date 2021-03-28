using System.Collections.Generic;
using UnityEngine;

namespace Misc
{
    [RequireComponent(typeof(SpriteRenderer))]

// Generates a nice set of repeated sprites inside a streched sprite renderer
// @NOTE Vertical only, you can easily expand this to horizontal with a little tweaking
    public class RepeatSpriteBoundary : MonoBehaviour
    {
        private List<Object> _created;

        public void Resize(Vector2? size = null)
        {
            ClearCreated();

            // Get the current sprite with an unscaled size
            var sprite = GetComponent<SpriteRenderer>();
            var boxCollider = GetComponent<BoxCollider2D>();
            var colliderSize = boxCollider.bounds.size;
            Vector2 spriteSize = size ?? new Vector2(sprite.bounds.size.x / colliderSize.x, sprite.bounds.size.y / colliderSize.y);

            // Generate a child prefab of the sprite renderer
            GameObject childPrefab = new GameObject();
            SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
            childPrefab.transform.position = transform.position;
            childSprite.sprite = sprite.sprite;

            // Loop through and spit out repeated tiles
            GameObject child;
            for (int i = 1, l = (int)Mathf.Round(sprite.bounds.size.x); i < l; i++)
            {
                child = Instantiate(childPrefab) as GameObject;
                child.transform.parent = transform;
                child.transform.position = transform.position + (new Vector3(spriteSize.x, 0, 0) * i);
                _created.Add(child);
            }

            // Set the parent last on the prefab to prevent transform displacement
            childPrefab.transform.parent = transform;

            // Disable the currently existing sprite component since its now a repeated image
            sprite.enabled = false;
        }

        private void OnDestroy()
        {
            ClearCreated();
        }

        private void ClearCreated()
        {
            if(_created == null)
                _created = new List<Object>();
            foreach (var o in _created)
            {
                Destroy(o);
            }
            _created.Clear();
        }
    }
}
