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
        public string AriaLabelledBy
        {
            get
            {
                object o = ViewState["AriaLabelledBy"];
                if (o == null) { return string.Empty; }
                else { return (string)o; }
            }
            set { ViewState["AriaLabelledBy"] = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!string.IsNullOrEmpty(AriaLabelledBy))
            {
                this.Attributes.Add("aria-labelledby", AriaLabelledBy);
            }
            base.Render(writer);
        }
    }
}
