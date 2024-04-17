using Unity.Netcode;
using UnityEngine;

namespace Network{

  public class Movement : NetworkBehaviour{

    readonly NetworkVariable<CustomData> randomData = new(new CustomData("first", 1, true),
      NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public float moveSpeed = 5f;

    public override void OnNetworkSpawn(){
      randomData.OnValueChanged += (prevData, newData) => {
        Debug.Log($"<color=green>ID:{OwnerClientId}: " +
                  $"Name:{randomData.Value.Name}, " +
                  $"No:{randomData.Value.Number}, " +
                  $"Bool:{randomData.Value.IsSth}</color>");
      };
    }

    void Update(){
      if (!IsOwner) return;

      if (Input.GetKeyDown(KeyCode.R)){
        TestServerRpc();
        // randomData.Value = new("changed", 11, false);
      }

      HandleMovement();
    }

    void HandleMovement(){
      if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
        transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
      }

      if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
        transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
      }

      if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        transform.Translate(Vector2.up * (moveSpeed * Time.deltaTime));
      }

      if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
      }
    }

    [ServerRpc] void TestServerRpc(){
      Debug.Log($"<color=green>Owner Client ID: {OwnerClientId}</color>");
    }

  }

}