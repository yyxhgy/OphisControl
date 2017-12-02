using OphisControl.GUI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OphisControl.GUI.Unit;
using System.ComponentModel;
using System.Collections;
using System.Windows.Threading;

namespace OphisControl.GUI
{
    public delegate void delRefreshTmpLine(System.Windows.Media.Geometry geometry);
    /// <summary>
    /// LinkBase.xaml 的交互逻辑
    /// </summary>
    public abstract partial class LinkBase : UserControl, IUnitBase
    {
        public LinkBase()
        {
            InitializeComponent();
        }
        public event delMouseClick evtMouseClick;
        public event delMouseDoubleClick evtDoubleMouseClick;
        /// <summary>
        /// 刷新临时连接线
        /// </summary>
        public event delRefreshTmpLine evtRefreshTmpLine;
        protected void OnRefreshTmpLine(Geometry geometry)
        {
            evtRefreshTmpLine?.Invoke(geometry);
        }
        /// <summary>
        /// 是否手动设置过
        /// </summary>
        protected bool IsManualSetted = false;
        private LinkLineTypes _LinkLineTypes = LinkLineTypes.Straight;
        public LinkLineTypes LinkLineTypes
        {
            get { return _LinkLineTypes; }
            set { _LinkLineTypes = value; }
        }
        private LineTerminalPoint _StartPnt;
        /// <summary>
        /// 起点
        /// </summary>
        public LineTerminalPoint StartPnt
        {
            get { return this._StartPnt; }
            set { this._StartPnt = value; }
        }
        LineTerminalPoint _EndPnt;
        /// <summary>
        /// 终点
        /// </summary>
        public LineTerminalPoint EndPnt
        {
            get { return this._EndPnt; }
            set { this._EndPnt = value; }
        }
        PointCollection _ShapePnt = new PointCollection();
        /// <summary>
        /// 形状点
        /// </summary>
        public PointCollection ShapePnt
        {
            get { return this._ShapePnt; }
            set { this._ShapePnt = value; }
        }
        private Hashtable _Properties = new Hashtable();
        /// <summary>
        /// 需要显示的属性集合
        /// </summary>
        public Hashtable Properties
        {
            get
            {
                _Properties["desc"] = txtDescription.Text;
                return _Properties;
            }
            set { _Properties = value; }
        }
        private void pathRange_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }
        /// <summary>
        /// 鼠标点击计数器
        /// </summary>
        private int _MouseClickCounter = 0;
        private void pathRange_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Offset = e.GetPosition(pathRange);

            _MouseClickCounter += 1;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; _MouseClickCounter = 0; };
            timer.IsEnabled = true;

            if (_MouseClickCounter % 2 == 0)
            {
                timer.IsEnabled = false;
                _MouseClickCounter = 0;

                evtDoubleMouseClick?.Invoke(this, txtDescription.Text);
            }
            else
            {
                if (!IsMutiSelected)
                {
                    IsSelected = true;
                }
                evtMouseClick?.Invoke(this, txtDescription.Text);
            }
        }
        #region IUnitBase 成员
        private string _Id = Guid.NewGuid().ToString();
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _CloneSourceId;
        public string CloneSourceId
        {
            get { return _CloneSourceId; }
            set { _CloneSourceId = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set
            {
                txtDescription.Text = value;
                if (value.Trim().Length == 0)
                {
                    txtDescription.Visibility = Visibility.Hidden;
                }
                else
                {
                    txtDescription.Visibility = Visibility.Visible;
                    SetDescTextPosition();
                }
            }
        }
        private bool _IsSetProperty = false;
        public bool IsSetProperty
        {
            get { return _IsSetProperty; }
            set { _IsSetProperty = value; }
        }
        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (value)
                {
                    if (_IsMutiSelected)
                    {
                        return;
                    }
                    else
                    {
                        _IsSelected = value;
                        OnPropertyChanged(value ? ChangedPropertys.SelectTrue : ChangedPropertys.SelectFalse);
                    }
                }
                else
                {
                    _IsSelected = value;
                }
            }
        }

        private bool _IsMutiSelected = false;
        public bool IsMutiSelected
        {
            get { return _IsMutiSelected; }
            set
            {
                _IsMutiSelected = value;
                if (value)
                {
                    pathLink.Stroke = new SolidColorBrush(Colors.Fuchsia);
                }
                else
                {
                    pathLink.Stroke = new SolidColorBrush(Colors.Black);
                }
            }
        }
        private PointCollection _Range = new PointCollection();
        public PointCollection Range
        {
            get { return _Range; }
        }

        public List<SimpleLinkNode> LinkNode
        {
            get
            {
                List<SimpleLinkNode> pnts = new List<SimpleLinkNode>();
                pnts.Add(new SimpleLinkNode(LinkNodeTypes.START, StartPnt.Position));
                pnts.Add(new SimpleLinkNode(LinkNodeTypes.END, EndPnt.Position));
                return pnts;
            }
        }

        public abstract UnitShapeTypes UnitSharpType { get; }
        private Point _Offset = new Point(0, 0);
        public Point Offset
        {
            get { return _Offset; }
            set { _Offset = value; }
        }

        public double width => throw new NotImplementedException();


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(ChangedPropertys changedPropertys)
        {
            if (null != PropertyChanged)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(changedPropertys.ToString());
                PropertyChanged(this, e);
            }
        }

        public void AcceptPointMove(Point point, int seq)
        {
            throw new NotImplementedException();
        }

        public void AcceptUnitMove(IUnitBase unit)
        {
            throw new NotImplementedException();
        }

        public void ChangePositionAndSize(double difLeft, double difTop, double difWidth, double difHeight)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void CreateUnit()
        {
            throw new NotImplementedException();
        }

        public IUnitBase FromBytes(byte[] data, int index, out int length)
        {
            throw new NotImplementedException();
        }

        public bool GetDescriptionPosition(out Point position)
        {
            throw new NotImplementedException();
        }

        public void MoveToClone(IUnitBase cloneUnit)
        {
            throw new NotImplementedException();
        }

        public byte[] ToBytes()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
