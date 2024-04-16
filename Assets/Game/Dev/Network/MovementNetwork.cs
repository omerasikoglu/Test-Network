using Unity.Netcode;
using UnityEngine;

namespace Network{

  public class MovementNetwork : NetworkBehaviour{

    public float moveSpeed = 5f;

    void Update(){
      if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
      }
    }

  }

}