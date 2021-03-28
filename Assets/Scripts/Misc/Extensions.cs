using UnityEngine;

namespace Misc
{
    public static class Extensions
    {
        public static void ScaleToSize(this GameObject obj, Vector3 targetSize)
        {
            Mesh m = obj.GetComponent<MeshFilter>().sharedMesh;
            Bounds meshBounds = m.bounds;
            Vector3 meshSize = meshBounds.size;
            float xScale = targetSize.x / meshSize.x;
            float yScale = targetSize.y / meshSize.y;
            float zScale = targetSize.z / meshSize.z;
            obj.transform.localScale = new Vector3(xScale, yScale, zScale);
        }

        public static void ScaleToSize2D(this GameObject obj, Vector3 targetSize)
        {
            var m = obj.GetComponent<SpriteRenderer>().sprite;
            Bounds meshBounds = m.bounds;
            Vector3 meshSize = meshBounds.size;
            float xScale = targetSize.x / meshSize.x;
            float yScale = targetSize.y / meshSize.y;
            float zScale = targetSize.z / meshSize.z;
            obj.transform.localScale = new Vector3(xScale, yScale, zScale);
        }
    }
}