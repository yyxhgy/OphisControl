using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OphisControl.GUI.Base
{
    /// <summary>
    /// 线条类型
    /// </summary>
    public enum LineTypes
    {
        /// <summary>
        /// 无
        /// </summary>
        No,
        /// <summary>
        /// 实线
        /// </summary>
        Solid,
        /// <summary>
        /// 长虚线
        /// </summary>
        LongDashes,
        /// <summary>
        /// 短虚线
        /// </summary>
        ShortDashes
    }
    /// <summary>
    /// 端点类型
    /// </summary>
    public enum EndpointTypes
    {
        /// <summary>
        /// 无端点
        /// </summary>
        No,
        /// <summary>
        /// 实心箭头开始
        /// </summary>
        StartSolidArrow,
        /// <summary>
        /// 实心箭头结束
        /// </summary>
        EndSolidArrow,
        /// <summary>
        /// 两侧均为实心箭头
        /// </summary>
        BothSolidArrow,
        /// <summary>
        /// 线箭头开始
        /// </summary>
        StartLineArrow,
        /// <summary>
        /// 线箭头结束
        /// </summary>
        EndLineArrow,
        /// <summary>
        /// 两侧均为线箭头
        /// </summary>
        BothLineArrow,
        /// <summary>
        /// 圆点开始
        /// </summary>
        StartDot,
        /// <summary>
        /// 圆点结束
        /// </summary>
        EndDot,
        /// <summary>
        /// 两侧均为圆点
        /// </summary>
        BothDot
    }
    /// <summary>
    /// 联系点类型
    /// </summary>
    public enum LinkNodeTypes
    {
        LEFT = 1,
        TOP = 2,
        RIGHT = 3,
        BOTTOM = 4,
        CENTER = 5,
        START = 6,
        END = 7,
        NULL = 8
    }
    /// <summary>
    /// 控制点类型
    /// </summary>
    public enum CtrlNodeTypes
    {
        LEFT,
        TOP,
        RIGHT,
        BOTTOM,
        LEFT_TOP,
        RIGHT_TOP,
        RIGHT_BOTTOM,
        LEFT_BOTTOM,
        /// <summary>
        /// 所有方向均可移动
        /// </summary>
        ALL,
        /// <summary>
        /// 连接线的起点移动
        /// </summary>
        START,
        /// <summary>
        /// 连接线的终点移动
        /// </summary>
        END,
        /// <summary>
        /// 修改位置
        /// </summary>
        POSITION,
        /// <summary>
        /// 不作任何修改
        /// </summary>
        NO_CHANGE
    }
    /// <summary>
    /// 改变的属性
    /// </summary>
    public enum ChangedPropertys
    {
        /// <summary>
        /// 被选中
        /// </summary>
        SelectTrue,
        /// <summary>
        /// 取消选中
        /// </summary>
        SelectFalse,
        /// <summary>
        /// 尺寸改变
        /// </summary>
        Size,
        /// <summary>
        /// 位置改变
        /// </summary>
        Position
    }
    /// <summary>
    /// 连接线的线型
    /// </summary>
    public enum LinkLineTypes
    {
        /// <summary>
        /// 直线
        /// </summary>
        Straight,
        /// <summary>
        /// 折线
        /// </summary>
        Broken,
        /// <summary>
        /// 曲线
        /// </summary>
        Curve,
        /// <summary>
        /// 圆弧
        /// </summary>
        Arc
    }
    public enum UnitShapeTypes
    {
        /// <summary>
        /// 流程
        /// </summary>
        ShapeProcess = 1,
        /// <summary>
        /// 判断
        /// </summary>
        ShapeJudge = 2,

        /// <summary>
        /// 折线连接线
        /// </summary>
        LinkBroken = 101,
        /// <summary>
        /// 直线连接线
        /// </summary>
        LinkStraight = 102
    }
    /// <summary>
    /// 构成连接线的点的类型
    /// </summary>
    public enum LinePointTypes
    {
        /// <summary>
        /// 起点
        /// </summary>
        StartPoint,
        /// <summary>
        /// 终点
        /// </summary>
        EndPoint,
        /// <summary>
        /// 转折点
        /// </summary>
        BreakPoint,
        /// <summary>
        /// 中点
        /// </summary>
        MiddlePoint
    }
}
