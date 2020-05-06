using System;
using System.IO;
using NUnit.Framework;
using Reinspector;
using Reinspector.Serializable;
using UnityEngine;

namespace ReinspectorLibTest
{
    [TestFixture]
    public class SerializerTest
    {
        private void TestValue<T>(T value)
        {
            var ser = new Serializer();
            var res = ser.Serialize(value);
            var d = ser.Deserialize<T>(res);
            Assert.AreEqual(value, d);
        }

        [Test]
        public void TestPrimitiveArray()
        {
            TestValue(new bool[] { false, true, false });
            TestValue(new char[] { 'a', 'b', 'c' });
            TestValue(new short[] { -1, 2, 3 });
            TestValue(new int[] { -1, 2, 3 });
            TestValue(new long[] { -1, 2, 3 });
            TestValue(new ushort[] { 1, 2, 3 });
            TestValue(new uint[] { 1, 2, 3 });
            TestValue(new ulong[] { 1, 2, 3 });
            TestValue(new float[] { -1, 2, 3 });
            TestValue(new double[] { -1, 2, 3 });
        }

        [Test]
        public void TestString()
        {
            TestValue("hello, world!");
            TestValue("こんにちは世界");
            TestValue(new string[] { "hello, world!" });
        }

        struct Foo
        {
            public int a;
            public double b;
        }

        [Test]
        public void TestStruct()
        {
            var obj = new Foo { a = -1, b = 2000 };
            TestValue(obj);
        }

        class Bar : IEquatable<Bar>
        {
            public int a;
            public double b;

            public bool Equals(Bar p)
            {
                if (ReferenceEquals(p, null))
                {
                    return false;
                }

                if (ReferenceEquals(this, p))
                {
                    return true;
                }

                if (GetType() != p.GetType())
                {
                    return false;
                }

                return (a == p.a) && (b == p.b);
            }
        }

        [Test]
        public void TestClass()
        {
            var obj = new Bar { a = -1, b = 2000 };
            TestValue(obj);
        }

        struct ParentFoo
        {
            public Foo child;
            public int a;
        }

        [Test]
        public void TestNestedStruct()
        {
            var obj = new ParentFoo { a = -1, child = new Foo { a = 1, b = 2 } };
            TestValue(obj);
        }

        class ParentBar : IEquatable<ParentBar>
        {
            public Bar child;
            public string a;

            public bool Equals(ParentBar p)
            {
                if (ReferenceEquals(p, null))
                {
                    return false;
                }

                if (ReferenceEquals(this, p))
                {
                    return true;
                }

                if (GetType() != p.GetType())
                {
                    return false;
                }

                return (a == p.a) && (child?.Equals(p.child) ?? (child == null && p.child == null));
            }
        }

        [Test]
        public void TestNestedClass()
        {
            var obj = new ParentBar { a = "bar", child = new Bar { a = 1, b = 2 } };
            TestValue(obj);
        }

        [Test]
        public void TestUnityStruct()
        {
            TestValue(new Vector2(1, 2));
            TestValue(new Vector3(1, 2, 3));
            TestValue(new Matrix4x4 { m00 = 1, m01 = 2 });
        }

        [Test]
        public void TestGameObjectSerializable()
        {
            var go = new GameObjectSerializable 
            {
                components = new []
                {
                    new ComponentUnion 
                    {
                        camera = new CameraSerializable
                        {
                            backgroundColor = Color.red
                        }
                    }
                }
            };
            var ser = new Serializer();
            var res = ser.Serialize(go);
            var d = ser.Deserialize<GameObjectSerializable>(res);
            Assert.AreEqual(go.components[0].camera.backgroundColor, d.components[0].camera.backgroundColor);
        }

        [Test]
        public void TestNull()
        {
            TestValue(new ParentBar { a = null, child = null });
        }

        class EmptyClass : IEquatable<EmptyClass>
        {
            public bool Equals(EmptyClass p)
            {
                if (ReferenceEquals(p, null))
                {
                    return false;
                }

                if (ReferenceEquals(this, p))
                {
                    return true;
                }

                return GetType() == p.GetType();
            }
        }

        [Test]
        public void TestEmptyClass()
        {
            TestValue(new MessageUnion());
        }

        [Test]
        public void TestMessage()
        {
            var ser = new Serializer();
            var res = ser.Serialize(new[] 
            {
                new MessageUnion(new Reinspector.Message.RequestSaveAllScenes()),
                new MessageUnion(new Reinspector.Message.RequestSaveAllScenes())
            });
            var d = ser.Deserialize<MessageUnion[]>(res);
            Assert.AreEqual(d.Length, 2);
            Assert.AreEqual(d[0].Value.GetType(), typeof(Reinspector.Message.RequestSaveAllScenes));
            Assert.AreEqual(d[1].Value.GetType(), typeof(Reinspector.Message.RequestSaveAllScenes));
        }
    }
}
