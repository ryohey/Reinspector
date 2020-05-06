# Reinspector

Inspect an application made with Unity on Unity Editor.

This system is intended to explore and learn the architecture of Unity applications. 
It is not intended for unauthorized modification or data extraction.

## How it works

Reinspector consists of two components.

- Reinspector Plugin - Inject to the target application with [BepInEx](https://github.com/BepInEx/BepInEx/)
- Reinspector Editor Extension - Communicate with the target application via Reinspector plugin

The Plugin serializes whole scenes into binaries. And the Editor Extension deserialize it on Unity Editor.

## Serialize/Deserialize

Reinspector has own generic serialization mechanism `Serializer` class. I needed to implement a less dependent serialization method that would work for a wide range of applications including .NET 3.5.

### Support Types

- Primitives
- class
- struct
- Array
- *[Unity Built-in types](https://github.com/ryohey/Reinspector/tree/master/Reinspector/ReinspectorLib/Source/Serializable/UnityObject)*

### Limitation

- Classes must have the empty constructor
- Only public fields are serialized
- Circular references are not resolved
- Indexer are not supported 
- Non-built-in shader

## Serialization for Unity Built-in types

In order to implement reliable serialization, Reinspector provides serializable classes mapped from each Built-in types.

- Resolves references to other components including `SkinnedMeshRenderer`
- Texture serialization
- Mesh serialization

## Inter-application communication

- Uses the local web server to communicate between the Editor Extension and the Plugin
- Strongly typed messaging mechanism using `Serializer`
