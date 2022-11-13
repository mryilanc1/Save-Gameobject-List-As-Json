using System.Collections.Generic;
namespace Editor
{
    [System.Serializable]
    public class ObjectUnit
    {
        public string ObjectName;
        public int ObjectID;
        public string ColliderName;
        public string LayerName;
        public List<MaterialUnit> Materials = new List<MaterialUnit>();
        
    }
}
