using OphisControl.GUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OphisControl.GUI.Unit
{
    public class DockedLinkNodeArgs
    {
        private int _Id;
        /// <summary>
        /// 产生停靠事件的点的序号
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private bool _Flag;
        /// <summary>
        /// 鼠标是否停靠在某个联系点上。鼠标离开某个联系点时=false;在某个联系点上时=true
        /// </summary>
        public bool Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
        private IUnitBase _UnitBase;
        /// <summary>
        /// 鼠标停靠的组件
        /// </summary>
        public IUnitBase UnitBase
        {
            get { return _UnitBase; }
            set { _UnitBase = value; }
        }
        private SimpleLinkNode _LinkNode;
        /// <summary>
        /// 鼠标停靠的联系点
        /// </summary>
        public SimpleLinkNode DocketLinkNode
        {
            get { return this._LinkNode; }
            set { this._LinkNode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flag">是否停靠在联系点上</param>
        /// <param name="unit">停靠的组件</param>
        /// <param name="linkNode">停靠的联系点</param>
        public DockedLinkNodeArgs(int id, bool flag, IUnitBase unit, SimpleLinkNode linkNode)
        {
            _Id = id;
            _Flag = flag;
            _UnitBase = unit;
            _LinkNode = linkNode;
        }
    }
}
