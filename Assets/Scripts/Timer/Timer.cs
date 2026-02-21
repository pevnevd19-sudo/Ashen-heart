using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
   public IEnumerator Timer1Sec()
    {
        yield return new WaitForSeconds(1f);
    }
   public IEnumerator Timer2Sec()
    {
        yield return new WaitForSeconds(2f);
    }
   public IEnumerator Timer3Sec()
    {
        yield return new WaitForSeconds(3f);
    }
   public IEnumerator Timer4Sec()
    {
        yield return new WaitForSeconds(4f);
    }
   public IEnumerator Timer5Sec()
    {
        yield return new WaitForSeconds(5f);
    }
   public IEnumerator Timer6Sec()
    {
        yield return new WaitForSeconds(6f);
    }
}
