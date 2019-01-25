using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimber : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Player.GetComponent<PlayerController1>().hanging = true;
            ClimbUp(other.gameObject);
        }
    }

    private void ClimbUp(GameObject objToClimb)
    {
        if (Player.transform.position.x < objToClimb.transform.position.x)    // player climbs wall on right
        {
            RectTransform rt = (RectTransform) objToClimb.transform;
            RectTransform rtPlayer = (RectTransform) Player.transform;
            Vector3 targetPosition = objToClimb.transform.position - new Vector3(rt.rect.width / 2, -rt.rect.height/2, 0) +
                                     new Vector3(rtPlayer.rect.width / 2, rtPlayer.rect.height/2);
            StartCoroutine(MovePlayer(targetPosition));
        }
    }

    private IEnumerator MovePlayer(Vector3 newPosition)
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = newPosition;
    }
    
    
}
