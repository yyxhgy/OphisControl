using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OphisControl.GUI.Base
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public abstract class UnitBase 
    {
        private UnitShapeTypes _UnitSharpTypes;
        public UnitShapeTypes UnitSharpType
        {
            get { return _UnitSharpTypes; }
            set { _UnitSharpTypes = value; }
        }

        public void OnDragDrop()
        {
            
        }
    }
}
