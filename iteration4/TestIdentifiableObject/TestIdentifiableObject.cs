using NUnit.Framework.Legacy;
using System;
using SwinAdventure;

namespace UnitTest
{
    public class IdentifiableObjectTest
    {
        private IdentifiableObject _identifiableObject;
        [SetUp]
        public void Setup()
        {
            _identifiableObject = new IdentifiableObject(new string[] { "105292912", "Khant Thu", "Aung" });
        }

        [Test]
        public void TestAreYou()
        {
            ClassicAssert.True(_identifiableObject.AreYou("105292912"));
            ClassicAssert.IsTrue(_identifiableObject.AreYou("Khant Thu"));
            ClassicAssert.IsTrue(_identifiableObject.AreYou("Aung"));
        }
        [Test]
        public void TestNotAreYou()
        {
            ClassicAssert.False(_identifiableObject.AreYou("1052929121"));
            ClassicAssert.IsFalse(_identifiableObject.AreYou("Khant"));
            ClassicAssert.IsFalse(_identifiableObject.AreYou("Aung Aung"));
        }
        [Test]
        public void TestCaseSEnsitive()
        {
            ClassicAssert.IsTrue(_identifiableObject.AreYou("aUnG"));
        }
        [Test]
        public void TestFirstID()
        {
            ClassicAssert.AreEqual("105292912", _identifiableObject.FirstID);
        }
        [Test]
        public void TestFirstIDWithNoIDs()
        {
            IdentifiableObject emptyIdentifiableObject = new IdentifiableObject(new string[] { });
            ClassicAssert.AreEqual("", emptyIdentifiableObject.FirstID);
        }
        [Test]
        public void TestAddID()
        {
            string[] testStrings = { "Python", "Dotnet", "Ruby", "Django" };
            foreach (string testString in testStrings)
            {
                _identifiableObject.AddIdentifier(testString);
            }
            foreach (string testString in testStrings)
            {
                ClassicAssert.IsTrue(_identifiableObject.AreYou(testString));
            }
        }
        public void TestPrivilegeEscalation()
        {
            _identifiableObject.PrivilegeEscalation("2912");
            ClassicAssert.AreEqual("105292912", _identifiableObject.FirstID);
        }


    }

}
