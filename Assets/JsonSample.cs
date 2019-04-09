using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class JsonSample : MonoBehaviour
{
    public Text CurrentStatus;
    public Text ResultOfParse;
    public Button Trigger;

    bool running;
    int updated;

    // Start is called before the first frame update
    void Start()
    {
        updated = 0;
        running = true;
        OnClick();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            executeParser();
        }
    }

    public void OnClick()
    {
        running = !running;
        Trigger.GetComponentInChildren<UnityEngine.UI.Text>().text = running ? "stop" : "start";
    }

    // create json text with current datetime text and parse it.
    void executeParser()
    {
        var jsonSource = $@"{{
            ""number"": 123.456,
            ""bool"": true,
            ""string"": ""C/C++ C# Unity"",
            ""array"": [1,2,3,4,5,6,7],
            ""object"": {{ ""1"": 20 }},
            ""datetime"": ""{System.DateTime.Now.ToString()}""
        }}";
        for (var i = 0; i < 1000; i++)
        {
            var rr = rapidjson.Document.Parse(jsonSource);
        }
        var r = rapidjson.Document.Parse(jsonSource);
        var now = r.Root["datetime"].ToString();
        ResultOfParse.text = now;
        CurrentStatus.text = updated.ToString();
        updated++;
    }
}
