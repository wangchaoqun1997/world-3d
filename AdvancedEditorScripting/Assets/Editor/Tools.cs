using UnityEngine;
using UnityEditor;
public class Tools{

    // Use this for initialization
    [MenuItem("Tools/test/test1")]
    static void test1() {
        Debug.Log("x");
    }


    [MenuItem("Window/test2")]
    static void test2() {
        Debug.Log("xx");
    }

    [MenuItem("GameObject/test3",false,10)]
    static void test3() {
        Debug.Log("xxx");
    }
}
