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
    /// 连接线控制点
    /// </summary>
    public class LineCtrlPoint
    {
        private int _Id = 0;
        /// <summary>
        /// 序号
        /// </summary>
        public int Id
        {
            get { return _Id; }
            private set { _Id = value; }
        }
        private System.Windows.Point _Position = new System.Windows.Point(0, 0);
        /// <summary>
        /// 点的中心位置
        /// </summary>
        public System.Windows.Point Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        private LinePointTypes _PointTypes = LinePointTypes.BreakPoint;
        /// <summary>
        /// 点类型
        /// </summary>
        public LinePointTypes PointTypes
        {
            get { return _PointTypes; }
            set { _PointTypes = value; }
        }
        private CtrlNodeTypes _CtrlNodeTypes = CtrlNodeTypes.ALL;
        public CtrlNodeTypes CtrlNodeTypes
        {
            get { return _CtrlNodeTypes; }
            set { _CtrlNodeTypes = value; }
        }
        private LineCtrlPoint _Prev;
        public LineCtrlPoint Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }
        private LineCtrlPoint _Next;
        public LineCtrlPoint Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public LineCtrlPoint(Point position, LinePointTypes linePointType, CtrlNodeTypes ctrlNodeType)
        {
            this._PointTypes = linePointType;
            this._Position = position;
            this._CtrlNodeTypes = ctrlNodeType;
            this.Next = null;
            this.Prev = null;
        }

        public LineCtrlPoint(double x, double y, LinePointTypes linePointType, CtrlNodeTypes ctrlNodeType)
        {
            this._PointTypes = linePointType;
            this._Position = new Point(x, y);
            this._CtrlNodeTypes = ctrlNodeType;
            this.Next = null;
            this.Prev = null;
        }
        /// <summary>
        /// 插入新点
        /// </summary>
        /// <param name="lineCtrlPoint"></param>
        /// <param name="flag">0，插入到当前点之前；1，插入到当前点之后</param>
        public void Insert(LineCtrlPoint lineCtrlPoint, int flag)
        {
            if (0 == flag)
            {
                if (null != _Prev)
                {
                    _Prev._Next = lineCtrlPoint;
                }
                lineCtrlPoint.Prev = _Prev;
                lineCtrlPoint.Next = this;
                _Prev = lineCtrlPoint;
            }
            else if (1 == flag)
            {
                if (null != _Next)
                {
                    _Next._Prev = lineCtrlPoint;
                }
                _Next = lineCtrlPoint;
                lineCtrlPoint.Prev = this;
                _Next = lineCtrlPoint;
            }
        }
        /// <summary>
        /// 将point添加到最后
        /// </summary>
        /// <param name="point"></param>
        /// <param name="linePointTypes"></param>
        /// <param name="ctrlNodeTypes"></param>
        public void Append(System.Windows.Point point, LinePointTypes linePointTypes, CtrlNodeTypes ctrlNodeTypes)
        {
            LineCtrlPoint tmp = this;
            while (null != tmp.Next)
            {
                tmp = tmp.Next;
            }
            LineCtrlPoint lineCtrlPoint = new LineCtrlPoint(point, linePointTypes, ctrlNodeTypes);

            lineCtrlPoint.Id = tmp.Id + 1;
            lineCtrlPoint.Prev = tmp;
            tmp.Next = lineCtrlPoint;
        }
        /// <summary>
        /// 添加到最后
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="linePointType"></param>
        /// <param name="ctrlNodeType"></param>
        public void Append(double x, double y, LinePointTypes linePointType, CtrlNodeTypes ctrlNodeType)
        {
            Append(new Point(x, y), linePointType, ctrlNodeType);
        }
    }
}
