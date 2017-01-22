using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {
    public const bool RIGHT = true;
    public const bool LEFT = false;
    public SpriteRenderer spriteRenderer;
    public bool isRight = true;
    public bool startsRight = false;//This is in case the sprite is drawn with a left facing orientation.
    public bool flipSpriteOnly = false;
    public bool flipSpriteActive = true;

    float hInput;

    // Use this for initialization
    void Start () {
        setDirection(isRight);
	}
	
	// Update is called once per frame
	void Update () {
        if (!flipSpriteActive) return;
	    if (hInput < -0.01f)
        {
            setDirection(LEFT);
        }
        else if (hInput > .01f)
        {
            setDirection(RIGHT);
        }
	}

    public void setHorizontalInput(float hInput)
    {
        this.hInput = hInput;
    }

    void updateDirection()
    {
        if (flipSpriteOnly)
        {
            if (spriteRenderer == null) return;
            if (isRight) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }
        else
        {
            float x = transform.localScale.x;
            float y = transform.localScale.y;
            float z = transform.localScale.z;

            if (isRight)
            {

                transform.localScale = new Vector3(Mathf.Abs(x), y, z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(x), y, z);
            }
        }
    }

    public void setDirection(bool direction)
    {
        isRight = direction;
        if (startsRight) isRight = !direction;
        updateDirection();
    }

    public bool getIsRight()
    {
        return isRight;
    }
}