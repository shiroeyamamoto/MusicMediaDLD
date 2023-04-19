using DevExpress.Utils.Extensions;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_media;
using System.Windows.Forms;
using System.Runtime.ConstrainedExecution;

namespace Music_media
{
     class HomeMenu
    {
        public static void homeChoice(Form frm, List<XtraTabPage> listPage, int num)
        {

            Control homeCtr = frm.Controls.Find("trackArea",true).FirstOrDefault();
            if(homeCtr != null)
            {
                foreach(Control control in homeCtr.Controls)
                {
                    //Show Control name
                    //MessageBox.Show(control.Name);
                    
                    if (control.Name== "menuControl")
                    {
                        /*foreach (Control ctr in control)
                        {
                            MessageBox.Show(ctr.Name);
                        }*/
                        //control.Text = "Home";
                        //MessageBox.Show("Chay den day");
                        XtraTabControl tabControl = control as XtraTabControl;

                        tabControl.SelectedTabPage= listPage[num];
                        //tabControl.TabPages.Find<>
                    }
                }
            }
        }
        private static Control ResurceControls(Control control, string name)
        {
            foreach(Control childControl in control.Controls)
            {
                if (childControl.Name == name)
                    return childControl;
                ResurceControls(childControl, name);
            }
            return null;
        }
    }
}
