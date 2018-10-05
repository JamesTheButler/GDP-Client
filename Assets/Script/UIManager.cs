﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum commands{
    UP,
    RIGHT,
    DOWN,
    LEFT
}

public class UIManager : MonoBehaviour {
    public Text queueText;
    public GameObject buttonPrefab;
    public GameObject canvas;
    List<commands> commandList;

    void Start() {
        commandList = new List<commands>();
    }

    private void addCommandToList(commands cmd) {
        commandList.Add(cmd);
        displayQueue();
    }

    public void addUpCmd() { addCommandToList(commands.UP); }
    public void addDownCmd() { addCommandToList(commands.DOWN); }
    public void addRightCmd() { addCommandToList(commands.RIGHT); }
    public void addLeftCmd() { addCommandToList(commands.LEFT); }

    public void displayQueue() {
        for(int j=0; j<canvas.transform.childCount; j++){
            Destroy(canvas.transform.GetChild(j).gameObject);
        }
        string s = "";
        for (int i = 0; i<commandList.Count; i++)
        {
            createButton(i, commandList[i]);
            switch (commandList[i]) {
                case commands.UP:
                    s +="U";
                    break;
                case commands.DOWN:
                    s += "D";
                    break;
                case commands.RIGHT:
                    s += "R";
                    break;
                case commands.LEFT:
                    s += "L";
                    break;
            }
        }
        queueText.text = s;
    }

    public void confirmQueue() {
        Debug.LogError("not implemented yet");
    }

    private void createButton(int id, commands cmd)
    {
        GameObject button = Instantiate(buttonPrefab, canvas.transform);
        button.GetComponent<RectTransform>().position = new Vector3( 20f+id*220, 20f, 0);
        button.GetComponent<SelfDelete>().id = id;
        Debug.Log(button.GetComponent<SelfDelete>().id);
        switch (cmd)
        {
            case commands.UP:
                button.GetComponentInChildren<Text>().text = "U";
                break;
            case commands.DOWN:
                button.GetComponentInChildren<Text>().text = "D";
                break;
            case commands.RIGHT:
                button.GetComponentInChildren<Text>().text = "R";
                break;
            case commands.LEFT:
                button.GetComponentInChildren<Text>().text = "L";
                break;
        }
    }

    public void deleteItemFromList(int id)
    {
        commandList.RemoveAt(id);
        displayQueue();

    }

    public void deletequeue()
    {
        commandList.Clear();
        displayQueue();
    }
}
