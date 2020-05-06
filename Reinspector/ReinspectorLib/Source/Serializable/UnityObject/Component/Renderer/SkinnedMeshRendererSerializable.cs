using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class SkinnedMeshRendererSerializable: RendererSerializable
    {
        public SkinQuality quality;
        public bool updateWhenOffscreen;
        public MeshSerializable sharedMesh;
        public bool skinnedMotionVectors;
        public Bounds localBounds;
        public TransformReferenceList bones;
        public TransformReference rootBone;

        public SkinnedMeshRendererSerializable(): base() { }

        public SkinnedMeshRendererSerializable(SkinnedMeshRenderer renderer): base(renderer)
        {
            quality = renderer.quality;
            updateWhenOffscreen = renderer.updateWhenOffscreen;
            sharedMesh = renderer.sharedMesh != null ? new MeshSerializable(renderer.sharedMesh) : null;
            skinnedMotionVectors = renderer.skinnedMotionVectors;
            localBounds = renderer.localBounds;
            bones = renderer.bones != null ? new TransformReferenceList(renderer.bones) : null;
            rootBone = renderer.rootBone != null ? new TransformReference(renderer.rootBone) : null;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var renderer = component as SkinnedMeshRenderer;
            renderer.quality = quality;
            renderer.updateWhenOffscreen = updateWhenOffscreen;
            renderer.sharedMesh = sharedMesh?.Instantiate();
            renderer.skinnedMotionVectors = skinnedMotionVectors;
            renderer.localBounds = localBounds;
            bones?.Restore(post, t => renderer.bones = t);
            rootBone?.Restore(post, t => renderer.rootBone = t);
        }
    }
}
