using LabSch.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LabSch
{
    public partial class Default : System.Web.UI.Page
    {
        Model model = new Model();
        Dictionary<string, Course> schs = new Model().getdLabSch();
        DataTable days = new Model().getDays();
        int[] arr = new int[] { 0, 0, 0, 0, 0, 0, 0 };
        protected void Page_Load(object sender, EventArgs e)
        {
            rptHDays.DataSource = model.getDays();
            rptHDays.DataBind();

            rptSlots.DataSource = model.getSlots();
            rptSlots.DataBind();
        }

        protected void rptSlots_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int slotid = (int)DataBinder.Eval(e.Item.DataItem, "slotid");
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tblRow");
                String key = "", nkey="";
                int span = 0, cnt=0, dayid=0;

                foreach (DataRow row in days.Rows)
                {
                    cnt = 1;
                    span = 0;

                    dayid = (int)row["dayid"];

                    key = slotid + "-" + row["dayid"];
                    nkey = key;

                    while (((Course)schs[nkey]).CourseId == ((Course)schs[key]).CourseId)
                    {
                        nkey = (slotid + cnt++) + "-" + row["dayid"];
                        span++;
                        if (!schs.ContainsKey(nkey))
                        {
                            break;
                        }
                    }

                    HtmlTableCell td = new HtmlTableCell();
                    if (schs.ContainsKey(key))
                    {
                        td.InnerText = ((Course)schs[key]).CourseName;
                        if (e.Item.ItemIndex == 0)
                        {
                            arr[dayid - 1] = span;
                            td.RowSpan = span;
                        }
                        else
                        {
                            if (--arr[dayid - 1] != 0)
                            {
                                //arr[dayid - 1]--;
                                td.Attributes.CssStyle.Add("display", "none");
                            }
                            else
                            {
                                arr[dayid - 1] = span;
                                td.RowSpan = span;
                            }
                        }
                    }
                    tr.Cells.Add(td);
                }

                //Repeater rptDays = e.Item.FindControl("rptDays") as Repeater;
                //rptDays.DataSource = model.getDays();
                //rptDays.DataBind();
            }
        }

        protected void rptDays_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }
    }
}