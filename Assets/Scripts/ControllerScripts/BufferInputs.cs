using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferInputs {
    Dictionary<string, BufferNode> bufferNodes = new Dictionary<string, BufferNode>();

    public void addInput(string inputName)
    {
        if (!bufferNodes.ContainsKey(inputName))
        {
            bufferNodes.Add(inputName, new BufferNode(inputName));
        }
    }

    public void update(float deltaTime)
    {
        foreach (BufferNode b in bufferNodes.Values)
        {
            if (Input.GetButtonDown(b.name))//This will probably change in order to include GetButtonUp
            {
                b.activate();
            }
            b.tick(deltaTime);
        }
    }

    public bool getInputActive(string inputName)
    {
        return bufferNodes[inputName].isActive();
    }

    private class BufferNode
    {
        public string name;
        public float bufferTime;

        float currentTime;

        public BufferNode(string name) : this(name, .24f)
        {

        }

        public BufferNode(string name, float bufferTime)
        {
            this.name = name;
            this.bufferTime = bufferTime;
            this.currentTime = 0;
        }

        public void tick(float deltaTime)
        {
            currentTime = Mathf.MoveTowards(currentTime, 0, deltaTime);
        }

        public bool isActive()
        {
            return currentTime > 0;
        }

        public void deactivate()
        {
            currentTime = 0;
        }

        public void activate()
        {
            currentTime = bufferTime;
        }
    }
}
