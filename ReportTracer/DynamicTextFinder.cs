using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ReportTracer
{
    /// <summary>
    /// This is a customized TextBox control, that allows to have a placeholder label and has an integrated
    /// search button.
    /// </summary>
    /// 
    //TODO: should be improved the graphics. In the sketch the control is bordered by a rounded border.
    public partial class DynamicTextFinder : UserControl
    {
        private int mgImageIndex;

        /// <summary>
        /// This the event delegate which sends a TextBox object as a sender.
        /// 
        /// </summary>
        /// <param name="txtsender">The sender TextBox. </param>
        /// <param name="tosearch">The related string to search for. </param>
        public delegate void StartSearchHandler(TextBox txtsender, string tosearch);
        public event StartSearchHandler StartSearch;

        public DynamicTextFinder()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }
   
        public bool EnableSearchButton
        {
            get
            {
                return pbSearchControl.Visible;
            }
            set
            {
                pbSearchControl.Visible = value;
            }
        }
        /// <summary>
        /// Contains the current inserted text.
        /// </summary>
        public override string Text
        {
            get
            {
                return tb.Text;
            }
            set
            {
                tb.Text = value;
            }
        }

        public TextBox TextObj
        {
            get
            {
                return tb;
            }
            set
            {
                tb = value;
            }
        }

        public Label LabelObj
        {
            get
            {
                return lblNro;
            }
            set
            {
                lblNro = value;
            }
        }

        /// <summary>
        /// This method initializes all customized elements in this control
        /// </summary>
        private void InitializeCustomComponents()
        {
            mgImageIndex = 0;
            
        }

        /// <summary>
        /// Thrown when the whole control is loaded. 
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void DynamicTextFinder_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Thrown when user enters the glass icon "search button".
        /// </summary> 
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        private void onMagnifyingGlassEntered(object sender, EventArgs e)
        {
            if(mgImageIndex == 0)
            {
                this.pbSearchControl.Image = global::ReportTracer.Generic.search2;
                mgImageIndex = 1;
            }
            else
            {
                this.pbSearchControl.Image = global::ReportTracer.Generic.search;
                mgImageIndex = 0;
            }
        }

        /// <summary>
        /// This slot process signals coming from text changes introduced by user.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event arguments</param>
        //private void OnTextChanged(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// Thrown when user left the magnifying glass button (search button).
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void OnMagnifyingGlassLeft(object sender, EventArgs e)
        {
            this.pbSearchControl.Image = global::ReportTracer.Generic.search;
            mgImageIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMagnifyingGlassClicked(object sender, EventArgs e)
        {
            StartSearch(tb, tb.Text);
        }

        public delegate void TextChangeHandler(TextBox sender, string str);
        public event TextChangeHandler TextChangeEvent;

        private void OnTextChanged(object sender, EventArgs e)
        {
            if(TextChangeEvent != null)
            {
                TextBox txtsource = (TextBox)sender;
                TextChangeEvent(txtsource, txtsource.Text);
            }
        }

        //private void onMagnifyingGlassLeft(object sender, EventArgs e)
        //{

        //}
    }
}
