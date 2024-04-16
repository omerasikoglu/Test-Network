using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Network{

  public class Movement : NetworkBehaviour{

    NetworkVariable<CustomData> randomData = new(new CustomData("first", 1, true),
      NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public float moveSpeed = 5f;

    public struct CustomData : INetworkSerializable{

      FixedString32Bytes name;
      int                number;
      bool               isSth;
      
      public FixedString32Bytes Name   => name;
      public int                Number => number;
      public bool               IsSth  => isSth;

      public CustomData(FixedString32Bytes name, int number, bool isSth){
        this.name   = name;
        this.number = number;
        this.isSth  = isSth;
      }

      public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter{
        serializer.SerializeValue(ref name);
        serializer.SerializeValue(ref number);
        serializer.SerializeValue(ref isSth);
      }
    }

    public override void OnNetworkSpawn(){
      randomData.OnValueChanged += (prevData, newData) => {
        // Debug.Log($"<color=green>{OwnerClientId}: {randomData.Value}</color>");
        Debug.Log($"<color=green>ID:{OwnerClientId}: Name:{randomData.Value.Name}, No:{randomData.Value.Number}, Bool:{randomData.Value.IsSth}</color>");
      };
    }

    void Update(){
      if (!IsOwner) return;

      if (Input.GetKeyDown(KeyCode.R)){ randomData.Value = new( "changed", 11, false ); }

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

  }

}