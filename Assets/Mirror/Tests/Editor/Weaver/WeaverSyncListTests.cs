using NUnit.Framework;

namespace Mirror.Weaver.Tests
{
    public class WeaverSyncListTests : BatchedWeaverTests
    {
        [Test]
        public void SyncList()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListByteValid()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListGenericAbstractInheritance()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListGenericInheritance()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorForGenericInheritanceWithMultipleGeneric()
        {
            AssertErrorListHasMatch(@"Mirror\.Weaver error: Could not find generic arguments for Mirror\.SyncList`1 using SyncListErrorForGenericInheritanceWithMultipleGeneric\.SomeListInt");
            AssertErrorListHasMatch(@"Mirror\.Weaver error: Too many generic argument for SyncListErrorForGenericInheritanceWithMultipleGeneric\.SomeList`2<System.String,System.Int32>");
        }

        [BatchedTest(true)]
        public void SyncListInheritance()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorForMissingParamlessCtor()
        {
            string weaverError = @"Mirror\.Weaver error:";
            string fieldType = @"SyncListErrorForMissingParamlessCtor\.SyncListString2 SyncListErrorForMissingParamlessCtor\.MyBehaviour::Foo";
            string errorMessage = @"Can not intialize field because no default constructor was found\. Manually intialize the field \(call the constructor\) or add constructor without Parameter";
            AssertErrorListHasMatch($"{weaverError} {fieldType} {errorMessage}");
        }

        [BatchedTest(true)]
        public void SyncListMissingParamlessCtorManuallyInitialized()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListNestedStruct()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListNestedInAbstractClass()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorForNestedInAbstractClassWithInvalid()
        {
            // we need this negative test to make sure that SyncList is being processed 
            AssertErrorListHasMatch(@"Mirror\.Weaver error: UnityEngine\.Object SyncListErrorForNestedInAbstractClassWithInvalid\.SomeAbstractClass/MyNestedStruct::target has unsupported type\. Use a type supported by Mirror instead");
        }

        [BatchedTest(true)]
        public void SyncListNestedInStruct()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorForNestedInStructWithInvalid()
        {
            // we need this negative test to make sure that SyncList is being processed 
            AssertErrorListHasMatch(@"Mirror\.Weaver error: UnityEngine\.Object SyncListErrorForNestedInStructWithInvalid\.SomeData::target has unsupported type\. Use a type supported by Mirror instead");
        }

        [BatchedTest(true)]
        public void SyncListStruct()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListStructWithCustomDeserializeOnly()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListStructWithCustomMethods()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(true)]
        public void SyncListStructWithCustomSerializeOnly()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorForGenericStruct()
        {
            string weaverError = @"Mirror\.Weaver error:";
            string type = @"SyncListErrorForGenericStruct\.MyGenericStructList";
            string errorMessage = @"Can not create Serialize or Deserialize for generic element\. Override virtual methods with custom Serialize and Deserialize to use SyncListErrorForGenericStruct.MyGenericStruct`1<System.Single> in SyncList";
            AssertErrorListHasMatch($"{weaverError} {type} {errorMessage}");
        }

        [BatchedTest(false)]
        public void SyncListErrorForGenericStructWithCustomDeserializeOnly()
        {
            string weaverError = @"Mirror\.Weaver error:";
            string type = @"SyncListErrorForGenericStructWithCustomDeserializeOnly\.MyGenericStructList";
            string errorMessage = @"Can not create Serialize or Deserialize for generic element\. Override virtual methods with custom Serialize and Deserialize to use SyncListErrorForGenericStructWithCustomDeserializeOnly.MyGenericStruct`1<System.Single> in SyncList";
            AssertErrorListHasMatch($"{weaverError} {type} {errorMessage}");
        }

        [BatchedTest(false)]
        public void SyncListErrorForGenericStructWithCustomSerializeOnly()
        {
            string weaverError = @"Mirror\.Weaver error:";
            string type = @"SyncListErrorForGenericStructWithCustomSerializeOnly\.MyGenericStructList";
            string errorMessage = @"Can not create Serialize or Deserialize for generic element\. Override virtual methods with custom Serialize and Deserialize to use SyncListErrorForGenericStructWithCustomSerializeOnly.MyGenericStruct`1<System.Single> in SyncList";
            AssertErrorListHasMatch($"{weaverError} {type} {errorMessage}");
        }

        [BatchedTest(true)]
        public void SyncListGenericStructWithCustomMethods()
        {
            AssertThatWeaverErrorIs(false);
        }

        [BatchedTest(false)]
        public void SyncListErrorWhenUsingGenericListInNetworkBehaviour()
        {
            string weaverError = @"Mirror\.Weaver error:";
            string type = @"SyncListErrorWhenUsingGenericListInNetworkBehaviour\.SomeList`1<System\.Int32> SyncListErrorWhenUsingGenericListInNetworkBehaviour.MyBehaviour::someList";
            string errorMessage = @"Can not use generic SyncObjects directly in NetworkBehaviour\. Create a class and inherit from the generic SyncObject instead\.";
            AssertErrorListHasMatch($"{weaverError} {type} {errorMessage}");
        }
    }
}
