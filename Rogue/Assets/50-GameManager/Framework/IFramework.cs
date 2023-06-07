using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceOfObjectsFw : IFramework
{
    private readonly GameObject trueOption;
    private readonly GameObject falseOption;
    private readonly string anchorName;
    private readonly bool choice;
    private readonly float turn;

    public ChoiceOfObjectsFw(GameObject trueOption, GameObject falseOption, bool choice, string anchorName, float turn = 0.0f)
    {
        this.trueOption = trueOption;
        this.falseOption = falseOption;
        this.choice = choice;
        this.anchorName = anchorName;
        this.turn = turn;
    }

    public List<string> GetAchorName() => new List<string> { anchorName };

    public bool GetCreate() => true;

    public float GetYRotate() => turn;

    public GameObject GetGameObject() => (choice) ? trueOption : falseOption;
}

public class ArrayOfObjectsFw : IFramework
{
    private readonly GameObject[] additionList;
    private readonly List<string> anchorName;
    private readonly float turn = 0.0f;
    private readonly bool create = true;

    public ArrayOfObjectsFw(GameObject[] additionList, List<string> anchorName, float turn = 0.0f, bool create = true)
    {
        this.additionList = additionList;
        this.anchorName = anchorName;
        this.turn = turn;
        this.create = create;
    }

    public List<string> GetAchorName() => anchorName;

    public bool GetCreate() => create;
   
    public float GetYRotate() => turn;

    public GameObject GetGameObject()
    {
        int selection = Random.Range(0, additionList.Length);

        return (additionList[selection]);
    }
}

public interface IFramework 
{
    public GameObject GetGameObject();
    public List<string> GetAchorName();
    public float GetYRotate();
    public bool GetCreate();
}


