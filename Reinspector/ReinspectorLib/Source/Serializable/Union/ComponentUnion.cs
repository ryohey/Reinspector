using Reinspector.Serializable.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Reinspector.Serializable
{
    public class ComponentUnion
    {
        public AudioListenerSerializable audioListener;
        public BoxColliderSerializable boxCollider;
        public CameraSerializable camera;
        public CanvasSerializable canvas;
        public CanvasRendererSerializable canvasRenderer;
        public ColliderSerializable collider;
        public ComponentSerializable component;
        public LightSerializable light;
        public MeshFilterSerializable meshFilter;
        public MeshRendererSerializable meshRenderer;
        public RendererSerializable renderer;
        public SkinnedMeshRendererSerializable skinnedMeshRenderer;
        public TransformSerializable transform;

        // UI

        public TextSerializable text;
        public MaskableGraphicSerializable maskableGraphic;
        public GraphicSerializable graphic;

        public OutlineSerializable outline;
        public ShadowSerializable shadow;
        public BaseMeshEffectSerializable baseMeshEffect;

        public GraphicRaycasterSerializable graphicRaycaster;
        public BaseRaycasterSerializable baseRaycaster;

        public CanvasScalerSerializable canvasScaler;

        public UIBehaviourSerializable uiBehaviour;

        public ComponentSerializable Value => 
            audioListener as ComponentSerializable
            ?? boxCollider as ComponentSerializable
            ?? camera  as ComponentSerializable
            ?? canvas as ComponentSerializable
            ?? canvasRenderer as ComponentSerializable
            ?? collider as ComponentSerializable
            ?? component as ComponentSerializable
            ?? light as ComponentSerializable
            ?? meshFilter as ComponentSerializable
            ?? meshRenderer as ComponentSerializable
            ?? renderer as ComponentSerializable
            ?? skinnedMeshRenderer as ComponentSerializable
            ?? transform as ComponentSerializable
            ?? text as ComponentSerializable
            ?? maskableGraphic as ComponentSerializable
            ?? graphic as ComponentSerializable
            ?? outline as ComponentSerializable
            ?? shadow as ComponentSerializable
            ?? baseMeshEffect as ComponentSerializable
            ?? graphicRaycaster as ComponentSerializable
            ?? baseRaycaster as ComponentSerializable
            ?? canvasScaler as ComponentSerializable
            ?? uiBehaviour as ComponentSerializable
            ;

        public ComponentUnion() { }

        public ComponentUnion(Component obj)
        {
            switch (obj)
            {
                case Camera c:
                    camera = new CameraSerializable(c);
                    break;
                case Canvas c:
                    canvas = new CanvasSerializable(c);
                    break;
                case CanvasRenderer r:
                    canvasRenderer = new CanvasRendererSerializable(r);
                    break;
                case AudioListener a:
                    audioListener = new AudioListenerSerializable(a);
                    break;
                case Light l:
                    light = new LightSerializable(l);
                    break;
                case MeshFilter m:
                    meshFilter = new MeshFilterSerializable(m);
                    break;
                case SkinnedMeshRenderer r:
                    skinnedMeshRenderer = new SkinnedMeshRendererSerializable(r);
                    break;
                case MeshRenderer r:
                    meshRenderer = new MeshRendererSerializable(r);
                    break;
                case Renderer r:
                    Debug.LogWarning("Serialize as base class Renderer: " + obj.GetType().FullName);
                    renderer = new RendererSerializable(r);
                    break;
                case BoxCollider c:
                    boxCollider = new BoxColliderSerializable(c);
                    break;
                case Collider c:
                    Debug.LogWarning("Serialize as base class Collider: " + obj.GetType().FullName);
                    collider = new ColliderSerializable(c);
                    break;
                case Transform t:
                    transform = new TransformSerializable(t);
                    break;

                // UI

                case Text t:
                    text = new TextSerializable(t);
                    break;
                case MaskableGraphic g:
                    maskableGraphic = new MaskableGraphicSerializable(g);
                    break;
                case Graphic g:
                    Debug.LogWarning("Serialize as base class Graphic: " + obj.GetType().FullName);
                    graphic = new GraphicSerializable(g);
                    break;

                case Outline o:
                    outline = new OutlineSerializable(o);
                    break;
                case Shadow s:
                    shadow = new ShadowSerializable(s);
                    break;
                case BaseMeshEffect e:
                    Debug.LogWarning("Serialize as base class BaseMeshEffect: " + obj.GetType().FullName);
                    baseMeshEffect = new BaseMeshEffectSerializable(e);
                    break;

                case GraphicRaycaster r:
                    graphicRaycaster = new GraphicRaycasterSerializable(r);
                    break;
                case BaseRaycaster r:
                    Debug.LogWarning("Serialize as base class BaseRaycaster: " + obj.GetType().FullName);
                    baseRaycaster = new BaseRaycasterSerializable(r);
                    break;

                case CanvasScaler s:
                    canvasScaler = new CanvasScalerSerializable(s);
                    break;
                case UIBehaviour b:
                    Debug.LogWarning("Serialize as base class UIBehaviour: " + obj.GetType().FullName);
                    uiBehaviour = new UIBehaviourSerializable(b);
                    break;

                default:
                    Debug.LogWarning("Serialize as base class Component: " + obj.GetType().FullName);
                    component = new ComponentSerializable(obj);
                    break;
            }
        }
    }
}
