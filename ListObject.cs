using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Editor
{
    [System.Serializable]
    public class ListObject
    {
        public List<ObjectUnit> ObjectList = new ();
    }
}