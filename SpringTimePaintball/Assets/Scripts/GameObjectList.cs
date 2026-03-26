using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Collections/GameObjectList")]
public class GameObjectList : ScriptableObject
{
    public List<GameObject> gameObjects;
    public int index;

    public UnityEvent OnListEmpty;
    public UnityEvent OnListCountChange;

    private int counting;
    
    public void RandomizeIndex()
    {
        index = Random.Range(0, gameObjects.Count - 1);
    }
    
    public void ClearList()
    {
        gameObjects.Clear();
        // Id.set(0);
    }
    
    public void AddObjectToList(GameObject obj)
    {
        var newObj = obj;
        gameObjects.Add(newObj);
        OnListCountChange.Invoke();
    }
    // public void AddThisObjectToList()
    // {
    //     var newObj = this.gameObject;
    //     gameObjects.Add(newObj);
    // }

    public int GetIndex(GameObject obj)
    {
        return gameObjects.IndexOf(obj);
    }

    public int GetCount()
    {
        return gameObjects.Count;
    }

    public void RemoveObjectAtIndex(int i)
    {
        gameObjects.RemoveAt(i);
    }
    public void DeleteObjectAtIndex(int i)
    {
        Destroy(gameObjects[i]);
        CheckCount();
    }

    public void CheckCount()
    {
        if(GetCount() <= 0)
        {
            OnListEmpty.Invoke();
        }
    }

    public GameObject GetObjectAtIndex(int i)
    {
        return gameObjects[i];
    }

    
    // public void AddRectTransform (RectTransform obj)
    // {
    //     var newObj = CreateInstance<Vector3Data>();
    //     newObj.value = obj.position;
    //     vector3Datas.Add(newObj);
    // }
    
    // public void TransformToVector3Data (IEnumerable<Transform> transforms)
    // {
    //     foreach (var obj in transforms)
    //     {
    //         var newObj = CreateInstance<Vector3Data>();
    //         newObj.value = obj.position;
    //         vector3Datas.Add(newObj);
    //     }
    // }
}
