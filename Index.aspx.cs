using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace NeedleAndHay
{
    public partial class Index : System.Web.UI.Page
    {
        private ArrayList haystack = new ArrayList();
        private Random rnd = new Random(); // object used to create random numbers
        private Hay h;
        private Needle n;
        private Object o;
        private bool found;

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= rnd.Next(2, 7); i++) haystack.Add(new Hay());
            haystack.Add(new Needle());
            for (int i = 1; i <= rnd.Next(2, 7); i++) haystack.Add(new Hay());

            // using try catch to find needle
            found = false; 
            for (int i = 0; i < haystack.Count && !found; i++) // stop searching when needle found
            {
                try
                {
                    h = (Hay)haystack[i];
                    ListBoxResults.Items.Add("I found " + h.ToString());
                }
                catch (InvalidCastException ice)
                {
                    n = (Needle)haystack[i];
                    ListBoxResults.Items.Add("I found " + n.ToString());
                    found = true;
                }
            }
            ListBoxResults.Items.Add("");

            // Alternative nr 2:
            // use getType and name to get the object class
            found = false;
            for (int i = 0; i < haystack.Count && !found; i++)
            {
                o = haystack[i];
                if(o.GetType().Name == "Needle") // when we don't know the object type (?)
                {
                    found = true;
                }
                ListBoxResults.Items.Add("I found " + o.ToString());
            }
        }
    }
}