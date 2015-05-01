using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccessibleWeb.UI.Controls
{
    public class TextBox: System.Web.UI.WebControls.TextBox
    {
        [Bindable(false), DefaultValue(""), DescriptionAttribute("Accesibilty group label 'ID'.")]
        public string AriaLabedBy
        {
            get
            {
                object o = ViewState["AriaLabedBy"];
                if (o == null) { return string.Empty; }
                else { return (string)o; }
            }
            set { ViewState["AriaLabedBy"] = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(AriaLabedBy))
            {
                this.Attributes.Add("aria-labelledby", AriaLabedBy);
            }
            base.Render(writer);
        }
    }
}
