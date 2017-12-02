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
    /// 简单联系点，只包含坐标和连接点类型
    /// </summary>
    public class SimpleLinkNode
    {
        private LinkNodeTypes _linkNodeType;
        private Point _Point = new Point(0, 0);
        public LinkNodeTypes LinkNodeTypes
        {
            get { return _linkNodeType; }
            set { _linkNodeType = value; }
        }
        public Point Point
        {
            get { return _Point; }
            set { _Point = value; }
        }
        public SimpleLinkNode(LinkNodeTypes linkNodeType, Point point)
        {
            _linkNodeType = linkNodeType;
            _Point = point;
        }

    }
}
