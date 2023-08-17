using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOutDestroyer : MonoBehaviour
{
    public static void WallTriggerExit(Collider other, GameObject _gameObject, GameObject fx = null)
    {
        if (other.gameObject.tag == "Wall")
        {
            if(fx != null)
            {
                Instantiate(fx).transform.position = _gameObject.transform.position;
            }

            TrailRenderer trail = _gameObject.GetComponentInChildren<TrailRenderer>();
            if (trail != null)
            {
                trail.Clear();
                trail.emitting = false;
            }

            _gameObject.SetActive(false);
        }
    }
}
