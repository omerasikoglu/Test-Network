using Unity.Collections;

namespace Network{

  public struct CustomData{

    public FixedString32Bytes Name  {get;}
    public int                Number{get;}
    public bool               IsSth {get;}

    public CustomData(FixedString32Bytes name, int number, bool isSth){
      this.Name   = name;
      this.Number = number;
      this.IsSth  = isSth;
    }
  }

}