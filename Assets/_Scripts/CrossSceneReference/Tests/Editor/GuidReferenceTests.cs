using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class GuidReferenceTests
{
    // Tests - make a new GUID
    // duplicate it
    // make it a prefab
    // delete it
    // reference it
    // dereference it

    string prefabPath;
    GuidComponent guidBase;
    GameObject prefab;
    GuidComponent guidPrefab;

    [OneTimeSetUp]
    public void Setup()
    {
        prefabPath = "Assets/TemporaryTestGuid.prefab";

        guidBase = CreateNewGuid();
		
#if UNITY_2018_3_OR_NEWER
		prefab = PrefabUtility.SaveAsPrefabAsset(guidBase.gameObject, prefabPath);
#else
        prefab = PrefabUtility.CreatePrefab(prefabPath, guidBase.gameObject);
#endif

        guidPrefab = prefab.GetComponent<GuidComponent>();
    }

    public GuidComponent CreateNewGuid()
    {
        GameObject newGO = new GameObject("GuidTestGO");
        return newGO.AddComponent<GuidComponent>();
    }
    
    [UnityTest]
    public IEnumerator GuidCreation()
    {
        GuidComponent guid1 = guidBase;
        GuidComponent guid2 = CreateNewGuid();

        Assert.AreNotEqual(guid1.GetGuid().ToString(), guid2.GetGuid().ToString());

        yield return null;
    }

    [UnityTest]
    public IEnumerator GuidDuplication()
    {
        LogAssert.Expect(LogType.Warning, "Guid Collision Detected while creating GuidTestGO(Clone).\nAssigning new Guid.");
        
        GuidComponent clone = GameObject.Instantiate<GuidComponent>(guidBase);

        Assert.AreNotEqual(guidBase.GetGuid().ToString(), clone.GetGuid().ToString());

        yield return null;
    }

    [UnityTest]
    public IEnumerator GuidPrefab()
    {
        Assert.AreNotEqual(guidBase.GetGuid().ToString(), guidPrefab.GetGuid().ToString());
        Assert.AreEqual(guidPrefab.GetGuid().ToString(), System.Guid.Empty.ToString());

        yield return null;
    }

    [UnityTest]
    public IEnumerator GuidPrefabInstance()
    {
        GuidComponent instance = GameObject.Instantiate<GuidComponent>(guidPrefab);
        Assert.AreNotEqual(guidBase.GetGuid().ToString(), instance.GetGuid().ToString());
        Assert.AreNotEqual(instance.GetGuid().ToString(), guidPrefab.GetGuid().ToString());

        yield return null;
    }

    [UnityTest]
    public IEnumerator GuidValidReference()
    {
        GuidReference reference = new GuidReference(guidBase);
        Assert.AreEqual(reference.gameObject, guidBase.gameObject);

        yield return null;
    }

    [UnityTest]
    public IEnumerator GuidInvalidReference()
    {
        GuidComponent newGuid = CreateNewGuid();
        GuidReference reference = new GuidReference(newGuid);
        Object.DestroyImmediate(newGuid);

        Assert.IsNull(reference.gameObject);

        yield return null;
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        AssetDatabase.DeleteAsset(prefabPath);
    }
}
