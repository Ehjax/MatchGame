/* Sam Cox - 2009 - FrictionPointStudios.com 
 */

using UnityEngine;
using System.Collections;

public class MyBezier {

    Vector3[] vectorArray;

    public MyBezier(FlythoughWaypoint[] waypointsArray)
    {
        vectorArray = new Vector3[waypointsArray.Length];

        for (int i = 0; i < waypointsArray.Length; i++)
        {
            vectorArray[i] = waypointsArray[i].CurrentPosition;
        }
    }

    public Vector3 GetPointAtTime(float t)
    {
        return CreateBenzierForPoint(t);
    }

    private Vector3 CreateBenzierForPoint(float t)
    {
        int x = (int) (t * (float)vectorArray.Length);

        if (x == vectorArray.Length)
        {
            x = 0;
        }

        // This is based off http://homepage.mac.com/nephilim/sw3ddev/bezier.html
        float newT = (t * (float)vectorArray.Length) - (float)x;

        Vector3 prevl = vectorArray[CheckWithinArray(x, vectorArray.Length)];
        Vector3 thisl = vectorArray[CheckWithinArray(x + 1, vectorArray.Length)];
        Vector3 nextl = vectorArray[CheckWithinArray(x + 2, vectorArray.Length)];
        Vector3 farl = vectorArray[CheckWithinArray(x + 3, vectorArray.Length)];

        Vector3 delta1 = (nextl - prevl) * .166f;
        Vector3 delta2 = (farl - thisl) * .166f;

        return DoBenzierForNPoints(newT, new Vector3[] { thisl, thisl + delta1, nextl - delta2, nextl });

    }

    private int CheckWithinArray(int x, int c)
    {
        if (x >= c)
        {
            return x % c;
        }
        else
        {
            return x;
        }
    }

    private Vector3 DoBenzierForNPoints(float t, Vector3[] currentArray)
    {
        Vector3 returnVector = Vector3.zero;
        
        float oneMinusT = (1f - t);

        int n = currentArray.Length - 1;

        for (int i = 0; i <= n; i++)
        {
            returnVector += BinomialCoefficient(n, i) * Mathf.Pow(oneMinusT, n - i) * Mathf.Pow(t, i) * currentArray[i];
        }

        return returnVector;
    }

    #region Standard Maths methods

    private float BinomialCoefficient(int n, int k)
    {
        if ((k < 0) || (k > n)) return 0;
        k = (k > n / 2) ? n - k : k;
        return (float) FallingPower(n, k) / Factorial(k);
    }

    private int Factorial(int n)
    {
        if (n == 0) return 1;
        int t = n;
        while (n-- > 2) 
            t *= n;
        return t;
    }

    private int FallingPower(int n, int p)
    {
        int t = 1;
        for (int i = 0; i < p; i++) t *= n--;
        return t;
    }

    #endregion

}
