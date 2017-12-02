using OphisControl.GUI.Unit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OphisControl.GUI.Base
{
    /// <summary>
    /// 鼠标单击委托
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="description"></param>
    public delegate void delMouseClick(IUnitBase unit, string description);
    /// <summary>
    /// 鼠标双击委托
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="description"></param>
    public delegate void delMouseDoubleClick(IUnitBase unit, string description);
    /// <summary>
    /// 组件基础接口
    /// </summary>
    public interface IUnitBase:ICloneable,INotifyPropertyChanged
    {
        /// <summary>
        /// 组件的唯一识别号
        /// </summary>
        string Id { get; }
        /// <summary>
        /// 克隆源组件的Id
        /// </summary>
        string CloneSourceId { get; }
        /// <summary>
        /// 描述
        /// </summary>
        string Description { get; }
        /// <summary>
        /// 是否设置了属性
        /// </summary>
        bool IsSetProperty { get; }
        /// <summary>
        /// 是否处于选中状态
        /// </summary>
        bool IsSelected { get; }
        /// <summary>
        /// 是否处于多选状态
        /// </summary>
        bool IsMutiSelected { get; }
        /// <summary>
        /// 形状的范围
        /// </summary>
        PointCollection Range { get; }
        /// <summary>
        /// 形状上可以与其他形状关联点的位置
        /// </summary>
        List<SimpleLinkNode> LinkNode { get; }
        /// <summary>
        /// 组件形状
        /// </summary>
        UnitShapeTypes UnitSharpType { get; }
        /// <summary>
        /// 偏移
        /// </summary>
        Point Offset { get; }
        /// <summary>
        /// 边缘
        /// </summary>
        Thickness Margin { get; }
        /// <summary>
        /// 高度
        /// </summary>
        double Height { get; }
        /// <summary>
        /// 宽度
        /// </summary>
        double width { get; }
        /// <summary>
        /// 在形状上单击时触发的事件
        /// </summary>
        event delMouseClick evtMouseClick;
        /// <summary>
        /// 在形状上双击时触发的事件
        /// </summary>
        event delMouseDoubleClick evtDoubleMouseClick;
        /// <summary>
        /// 创建组件
        /// </summary>
        void CreateUnit();
        /// <summary>
        /// 改变组件位置和尺寸
        /// </summary>
        /// <param name="difLeft"></param>
        /// <param name="difTop"></param>
        /// <param name="difWidth"></param>
        /// <param name="difHeight"></param>
        void ChangePositionAndSize(double difLeft, double difTop, double difWidth, double difHeight);
        /// <summary>
        /// 处理其它形状移动对本身的影响
        /// </summary>
        /// <param name="unit"></param>
        void AcceptUnitMove(IUnitBase unit);
        /// <summary>
        /// 处理其它控制点在自身上面的移动
        /// </summary>
        /// <param name="point"></param>
        /// <param name="seq"></param>
        void AcceptPointMove(Point point, int seq);
        /// <summary>
        /// 移动到克隆形状的位置
        /// </summary>
        /// <param name="cloneUnit"></param>
        void MoveToClone(IUnitBase cloneUnit);
        /// <summary>
        /// 获得说明文字的位置
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool GetDescriptionPosition(out Point position);
        /// <summary>
        /// 转换为可保存的二进制数据
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();
        IUnitBase FromBytes(byte[] data, int index, out int length);
    }
}
