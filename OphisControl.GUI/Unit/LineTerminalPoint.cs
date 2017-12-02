using OphisControl.GUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OphisControl.GUI.Unit
{
    /// <summary>
    /// 连接线端点
    /// </summary>
    public class LineTerminalPoint : ICloneable
    {
        private Point _Position=new Point(0,0);
        /// <summary>
        /// 点位置
        /// </summary>
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        private bool _DockedFlag = false;
        /// <summary>
        /// 是否停靠在联系点上
        /// </summary>
        public bool DockedFlag
        {
            get { return _DockedFlag; }
            set { _DockedFlag = value; }
        }
        private string _RelatedUnitId = "";
        /// <summary>
        /// 关系点关联的组件编号
        /// </summary>
        public string RelatedUnitId
        {
            get { return _RelatedUnitId; }
            set { _RelatedUnitId = value; }
        }
        private LinkNodeTypes _RelatedType = LinkNodeTypes.NULL;
        /// <summary>
        /// 关系点与关联组件的关联方式
        /// </summary>
        public LinkNodeTypes RelatedType
        {
            get { return _RelatedType; }
            set { _RelatedType = value; }
        }
        public LineTerminalPoint(Point point)
        {
            Position = point;
        }

        public LineTerminalPoint()
        {
        }

        public object Clone()
        {
            LineTerminalPoint point = new LineTerminalPoint();
            point._Position = new Point(_Position.X, _Position.Y);
            point._DockedFlag = _DockedFlag;
            point._RelatedType = _RelatedType;
            point._RelatedUnitId = _RelatedUnitId;
            return point;

        }
    }
}
