//#define DEBUG_DrawGizmos
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ScreenBounds : MonoBehaviour {

	static private ScreenBounds S;

	public float zScale = 10;

	private Camera mainCamera;
	BoxCollider boxCollider;
    float cachedOrthographicSize;
    float cachedAspect;
    Vector3 cachedCamScale;

    private void Start()
    {
		S = this;
		mainCamera = Camera.main;
        if (!mainCamera.orthographic)
        {
			Debug.Log("ScreenBounds: Start() Must be orthographic to for it to work");
        }

		boxCollider = GetComponent<BoxCollider>();
		boxCollider.size = Vector3.one;
		transform.position = Vector3.zero;

		ScaleSelf();
    }

    private void Update()
    {
        ScaleSelf();
    }

    private void ScaleSelf()
    {
        if (mainCamera.orthographicSize != cachedOrthographicSize || mainCamera.aspect != cachedAspect
            || mainCamera.transform.localScale != cachedCamScale)
        {
            transform.localScale = CalculateScale();
        }
    }

    private Vector3 CalculateScale()
    {
        //will only run once til values are set.
        cachedOrthographicSize = mainCamera.orthographicSize;
        cachedAspect = mainCamera.aspect;
        cachedCamScale = mainCamera.transform.localScale;

        //Debug.Log("calculate scale" + cachedOrthographicSize + " , " + cachedAspect + " , " + cachedCamScale);

        Vector3 scaleDesired;
        scaleDesired.z = zScale;
        scaleDesired.y = mainCamera.orthographicSize * 2;
        scaleDesired.x = scaleDesired.y * mainCamera.aspect;

        //What it does not important but learn how extensions are important...
        
        //var scaleColl = scaleDesired.ComponentDivide(cachedCamScale);

        return scaleDesired;
    }

    //returns random point that will be on screen
    //because static need to use singleton here
    static public Vector3 RANDOM_ON_SCREEN_LOC
    {
        get
        {
            Vector3 min = S.boxCollider.bounds.min;
            Vector3 max = S.boxCollider.bounds.max;
            Vector3 randomLocation = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), 0);
            return randomLocation;
        }
    }

    static public Bounds BOUNDS
    {
        get

        {
            if(S == null)
            {
                Debug.Log("Bounds: S is null");
                return new Bounds();
            }

            if(S.boxCollider == null)
            {
                Debug.Log("Bounds: S.BoxCollider is null");
                return new Bounds();
            }

            
            return S.boxCollider.bounds;
        }
    }

    static public bool OOB(Vector3 worldPos)
    {
        //sends bool on whether a point is out of bounds or not; should test
        //local position relative to S.transform - the screen bound object
        Vector3 localPosition = S.transform.InverseTransformPoint(worldPos);
        float maxDist = Mathf.Max(Mathf.Abs(localPosition.x), Mathf.Abs(localPosition.y), Mathf.Abs(localPosition.z));        
        return maxDist > 0.5f;
    }

    static public int OOB_X(Vector3 worldPos)
    {
        Vector3 localPosition = S.transform.InverseTransformPoint(worldPos);
        return _OOB(localPosition.x);
    }

    static public int OOB_Y(Vector3 worldPos)
    {
        Vector3 localPosition = S.transform.InverseTransformPoint(worldPos);
        return _OOB(localPosition.y);

    }

    static public int OOB_Z(Vector3 worldPos)
    {
        Vector3 localPosition = S.transform.InverseTransformPoint(worldPos);
        return _OOB(localPosition.z);
    }

    static private int _OOB(float num)
    {
        if (num > 0.5) return 1;
        if (num < -0.5) return -1;
        return 0;
    }


#if DEBUG_DrawGizmos
    public void OnDrawGizmos()
    {
        var size = new Vector3(0.5f, 0.5f, 0.5f);
        Gizmos.color = Color.white;
        Gizmos.DrawCube(boxCollider.bounds.min, size);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.max, size);
    }
#endif
}
