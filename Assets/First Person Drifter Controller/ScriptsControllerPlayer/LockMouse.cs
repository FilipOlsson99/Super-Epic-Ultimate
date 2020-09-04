// by @torahhorse

using UnityEngine;
using System.Collections;

public class LockMouse : MonoBehaviour
{

    [SerializeField] private bool startLocked = true;
    private bool mouseLocked;

	void Start()
	{
		LockCursor(startLocked);
	}

    void Update()
    {


        // unlock when escape is hit
        if  ( Input.GetKeyDown(KeyCode.Escape) )
        {
            LockCursor(!mouseLocked);

        }

    }
    
    public void LockCursor(bool lockCursor)
    {
        mouseLocked = lockCursor;
        switch (lockCursor)
        {
            case true:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case false:
                Cursor.lockState = CursorLockMode.None;
                break;
        }

    }

    public void UnlockCursor()
    {
        LockCursor(false);
    }
}