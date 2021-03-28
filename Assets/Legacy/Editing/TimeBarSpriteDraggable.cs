using UnityEngine;

namespace Legacy.Editing
{
    public class TimeBarSpriteDraggable : SpriteDraggable
    {
        protected override void MoveByMouse(Vector3 position)
        { 
            transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        }
    }
}
