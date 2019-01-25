using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimber : MonoBehaviour
{
    private bool climpingUp;
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
//            Player.GetComponent<PlayerController1>().hanging = true;
print("Climbing up");
            ClimbUp(other.gameObject);
        }
    }

    private void ClimbUp(GameObject objToClimb)
    {
        if (climpingUp)
            return;
        climpingUp = true;
        print("Try climbing");

        if (Player.transform.position.x < objToClimb.transform.position.x)    // player climbs wall on right
        {
//            RectTransform rt = (RectTransform) objToClimb.transform;
//            RectTransform rtPlayer = (RectTransform) Player.transform;
            Vector3 targetPosition = objToClimb.transform.position - new Vector3(objToClimb.transform.localScale.x/2, -objToClimb.transform.localScale.y/2, 0) +
                                     new Vector3(Player.transform.localScale.x/2, Player.transform.localScale.y/2);
            StartCoroutine(MovePlayer(targetPosition));
        }
    }

    private IEnumerator MovePlayer(Vector3 newPosition)
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = newPosition;
        climpingUp = false;
    }
    
    
}
