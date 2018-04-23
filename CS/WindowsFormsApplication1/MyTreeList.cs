using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.ComponentModel;

namespace WindowsFormsApplication1 {
    [System.ComponentModel.DesignerCategory("")]
    public class InitNewNodeEventArgs : EventArgs {
        public InitNewNodeEventArgs(int nodeId) {
            this.nodeId = nodeId;
        }
        private int nodeId;
       
        public int NodeId {
            get { return nodeId; }
        }
    }

 
    public class MyTreeList : TreeList {
        public delegate void InitNewNodeEventHandler(object sender, InitNewNodeEventArgs a);
        private event InitNewNodeEventHandler initNewNode;
        private TreeListNode _NewAddedNode;

        public MyTreeList()
            : base() {
               
        }

        [ Category("Data")]
		public event InitNewNodeEventHandler InitNewNode {
			add { this.Events.AddHandler(initNewNode, value); }
			remove { this.Events.RemoveHandler(initNewNode, value); }
		}
        public MyTreeList(object ignore) : base(ignore) { }
     
      

        public void AddNewNode() {
            int Id = -1;

            _NewAddedNode = this.AppendNode(null, Id);
            isNewRowDirty = false;
            this.FocusedNode = _NewAddedNode;
            RaiseInitNewNode(new InitNewNodeEventArgs(_NewAddedNode.Id));
        }

        private bool isNewRowDirty = false;
        protected override void OnMouseDown(MouseEventArgs e) {
            TreeListHitInfo info = this.CalcHitInfo(e.Location);
            if (info.HitInfoType == HitInfoType.Cell) {
                    isNewRowDirty = true;
                    this.RefreshNode(_NewAddedNode);
            }
            base.OnMouseDown(e);
        }

        
        protected override void RaiseCustomDrawNodeIndicator(CustomDrawNodeIndicatorEventArgs e) {
            if (e.Node != _NewAddedNode || isNewRowDirty) {
                base.RaiseCustomDrawNodeIndicator(e);
                return;
            }

            e.ImageIndex = 1;
            e.Painter.DrawObject(e.ObjectArgs);
          
        }

        protected virtual void RaiseInitNewNode(InitNewNodeEventArgs e) {
            InitNewNodeEventHandler handler = (InitNewNodeEventHandler)this.Events[initNewNode];

            if (handler != null) {
                handler(this, e);
            }
        }

        public bool IsNewNode(int nodeId) {
            return nodeId == _NewAddedNode.Id;
        }

        
    }
}
