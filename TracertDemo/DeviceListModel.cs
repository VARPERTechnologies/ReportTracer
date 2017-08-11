using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Aga.Controls.Tree;
using System.Drawing;
using System.Threading;
using System.ComponentModel;


namespace TracertDemo
{
    class DeviceListModel : ITreeModel
    {
        public event EventHandler<TreeModelEventArgs> NodesChanged;
        public event EventHandler<TreeModelEventArgs> NodesInserted;
        public event EventHandler<TreeModelEventArgs> NodesRemoved;
        public event EventHandler<TreePathEventArgs> StructureChanged;

        protected List<DeviceItem> devices;

        public DeviceListModel()
        {
            devices = new List<DeviceItem>(5);
            
        }
        
        public IEnumerable GetChildren(TreePath treePath)
        {
            if (treePath.IsEmpty()/* || treePath.LastNode == devices*/)
            {
                foreach (DeviceItem dev in devices)
                {
                    yield return dev;
                }
            }
            else
            {
                //List<BasicItem> items = new List<BasicItem>();
                BasicItem parent = treePath.LastNode as BasicItem;
                if (parent != null)
                {

                    foreach (BasicItem itm in parent.Children)
                    {
                        yield return itm;
                    }
                    //foreach (string str in Directory.GetDirectories(parent.ItemPath))
                    //    items.Add(new FolderItem(str, parent));
                    //foreach (string str in Directory.GetFiles(parent.ItemPath))
                    //    items.Add(new FileItem(str, parent));

                    //_itemsToRead.AddRange(items);
                    //if (!_worker.IsBusy)
                    //    _worker.RunWorkerAsync();

                    //foreach (BaseItem item in items)
                    //    yield return item;
                }
            }
        }

        public bool IsLeaf(TreePath treePath)
        {
            BasicItem item = treePath.FirstNode as BasicItem;

            return !item.HasChildren(); 
        }

        public void AddHop(HopItem hop)
        {
            //BasicItem item = hop.FirstNode as BasicItem;

            //item.Children.Add(new DeviceItem());

            //foreach (BasicItem itm in devices.Children)
            //{
            //    if(itm is DeviceItem)
            //    {
            //        itm.Children.Add(hop);
            //    }
            //}
            //NodesInserted(this, new TreeModelEventArgs(GetPath(root.Parent), root.Children));
        }

        public void AddDevice(DeviceItem device)
        {
            devices.Add(device);

            //device.Parent = devices;
            //devices.Children.Add(device);

            if(NodesChanged != null)
            {
                //List<BasicItem> children = device.Parent.Children;
                //object[] objChildren = new object[children.Count];
                //for (int i = 0; i < children.Count; i++)
                //{
                //    objChildren[i] = children[i];
                //}

                TreePath tp = GetPath(device.Parent);
                NodesChanged(this, new TreeModelEventArgs(tp, new object[]{ device }));
            }
           
        }

        public bool IsHop(TreePath path)
        {
            return IsLeaf(path);
        }

        private TreePath GetPath(BasicItem item)
        {
            Stack<object> stack = new Stack<object>();
            //while (!(item is DeviceItem))
            while (/*item != root &&*/ item != null)
            {
                stack.Push(item);
                item = item.Parent;
            }
            return new TreePath(stack.ToArray());
        }

    }

    public abstract class BasicItem
    {
        List<BasicItem> children;

        private string _path = "";
        public string ItemPath
        {
            get { return _path; }
            set { _path = value; }
        }

        private Image _icon;
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private string _size = "";
        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private string _date = "";
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public abstract string Name
        {
            get;
            set;
        }

        private BasicItem _parent;

        public BasicItem Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public List<BasicItem> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        public bool HasChildren()
        {
            return children.Count != 0;
        }
    }

    public class DeviceItem : BasicItem
    {
        private string strName;

        public DeviceItem()
        {
            //this.strName = "";

            this.Name = "";
            Children = new List<BasicItem>();
        }

        public DeviceItem(string name)
        {
            //this.strName = name;

            this.Name = name;

            Children = new List<BasicItem>();
        }

        public override string Name
        {
            get
            {
                return strName;
            }

            set
            {
                strName = value;
            }
        }
    }

    public class HopItem : BasicItem
    {
        string strName;

        public override string Name
        {
            get
            {
                return strName; 
            }

            set
            {
                strName = value;
            }
        }
    }
}
