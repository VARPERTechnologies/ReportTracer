using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTreeList;

namespace ReportTracer
{
    public partial class RouteReport : DevExpress.XtraReports.UI.XtraReport
    {

        FormattingRule frFonts = new FormattingRule();

        public RouteReport()
        {
            InitializeComponent();
            InitializeCustomComponents();

        }

        public RouteReport(TreeList tlDevicesToRoute)
        {
            InitializeComponent();
            InitializeCustomComponents();

            this.BeginUpdate();
            this.Name.MultiValue = true;
            //this.Name; 

            DevExpress.DataAccess.ObjectBinding.ObjectDataSource ds = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            ds.Name = "sampleDS";
            ds.DataSource = typeof(DemoModel);
            ds.DataMember = "Items";

            var p = new DevExpress.DataAccess.ObjectBinding.Parameter(
                "sampleParameter",
                typeof(DevExpress.DataAccess.Expression),
                new DevExpress.DataAccess.Expression("[Parameters.sampleParameterInt]", typeof(int)));

            ds.Constructor = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo(p);

            this.DataSource = ds;

            this.Parameters.Add(new DevExpress.XtraReports.Parameters.Parameter()
            {
                Name = "sampleParamInt",
                Type = typeof(int),
                Value = 2334
            });

            this.RequestParameters = false;

            CreateReportControls("testingParameter", this);

            //System.Collections.ArrayList strNames = new System.Collections.ArrayList();
            //int
            //    devices = tlDevicesToRoute.Nodes.Count,
            //    hops;
            //for(int i = 0; i < devices; i++)
            //{
            //    hops = tlDevicesToRoute.Nodes[i].Nodes.Count;
            //    if(hops > 0)
            //    {
            //        for (int j = 0; i < hops; j++)
            //        {
            //            strNames.Add(tlDevicesToRoute.Nodes[i].Nodes[j].GetValue(0));
            //            strNames.Add("<br/>");
            //        }
            //    }
            //    else
            //    {
            //        strNames.Add(tlDevicesToRoute.Nodes[i].GetValue(0));
            //        strNames.Add("<br/>");
            //    }

            //}
            //this.Name.Value = strNames;

            //this.EndUpdate();
        }

        private void InitializeCustomComponents()
        {
            //frFonts.Formatting.Font = new Font("Arial", 10.0f);
            //this.Report.FormattingRules.Add(frFonts);
        }

        private static void CreateReportControls(string parameterName, XtraReport report)
        {
            var pageHeader = new PageHeaderBand();
            var paramValueLbl = new XRLabel()
            {
                Name = "label1",
                Borders = DevExpress.XtraPrinting.BorderSide.Bottom,
                Font = new System.Drawing.Font("Calibri", 18f),
                SizeF = new System.Drawing.SizeF(200, 50),
                LocationF = new System.Drawing.PointF(5, 5)
            };
            paramValueLbl.DataBindings.Add(new XRBinding(report.Parameters[parameterName], "Text", "Parameter value:{0}"));
            pageHeader.Controls.Add(paramValueLbl);
            report.Bands.Add(pageHeader);

            var detail1 = new DetailBand();
            var xrLabel1 = new XRLabel()
            {
                Name = "label1",
                Font = new System.Drawing.Font("Calibri", 18f),
                SizeF = new System.Drawing.SizeF(200, 50),
                LocationF = new System.Drawing.PointF(0, 0)
            };
            xrLabel1.DataBindings.Add(new XRBinding("Text", null, "Name", "Name: {0}"));
            detail1.Controls.Add(xrLabel1);
            report.Bands.Add(detail1);
        }

        private object GenerateObjectDataSource(string reportParamName, string dataSourceParamName)
        {
            DevExpress.DataAccess.ObjectBinding.ObjectDataSource objds = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            objds.Name = "ObjectDataSource1";
            objds.DataMember = "Items";
            objds.DataSource = typeof(DemoModel);

            // Uncomment the following line to explicitly specify the object data source parameter value.
            // var p = new DevExpress.DataAccess.ObjectBinding.Parameter("p1", typeof(int), 3);

            // The following code maps a data source parameter to the report parameter.
            var p = new DevExpress.DataAccess.ObjectBinding.Parameter(
                dataSourceParamName,
                typeof(DevExpress.DataAccess.Expression),
                new DevExpress.DataAccess.Expression("[Parameters." + reportParamName + "]", typeof(int)));

            objds.Constructor = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo(p);
            return objds;
        }
    }
    public class DemoModel
    {
        public ItemList Items { get; set; }
        public DemoModel(int p1)
        {
            Items = new ItemList(p1);
        }
    }
    public class ItemList : List<Item>
    {
        public ItemList()
            : this(10)
        {

        }
        public ItemList(int itemNumber)
        {
            for (int i = 0; i < itemNumber; i++)
            {
                Add(new Item() { Name = i.ToString() });
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
    }
}
