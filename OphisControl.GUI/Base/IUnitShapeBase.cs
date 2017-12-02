using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OphisControl.GUI.Base
{
    public interface IUnitShapeBase
    {
        /// <summary>
        /// 组件形状类型
        /// </summary>
        UnitShapeTypes UnitShapeType
        {
            get;
        }
        /// <summary>
        /// 拖动事件
        /// </summary>
        void OnDragDrop();
    }
}
