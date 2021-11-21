using LabSch.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabSch
{
    public partial class GridView : System.Web.UI.Page
    {
        Model model = new Model();
        Dictionary<string, Course> schs = new Model().getdLabSch();
        DataTable days = new Model().getDays();
        int[] arr = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
        protected void Page_Load(object sender, EventArgs e)
        {
            gvLabs.DataSource = model.getSlots();
            gvLabs.DataBind();
        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            LinkButton lnkButton = sender as LinkButton;
            int rowIndex = (lnkButton.NamingContainer as GridViewRow).RowIndex;
        }

        protected void gvLabs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int index = 1, id = 1;
                String key = "", nkey = "";
                int span = 0, cnt = 0, dayid = 0;

                int slotid = (int)DataBinder.Eval(e.Row.DataItem, "slotid");

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

                    if (schs.ContainsKey(key))
                    {
                        Course course = (Course)schs[key];
                        LinkButton lnkButton = new LinkButton
                        {
                            ID = "lnkButton_" + (id++),
                            Text = course.CourseName + "<br>" + course.Faculty,
                            CommandArgument = key
                            
                        };
                        lnkButton.Click += new System.EventHandler(lnkButton_Click);

                        e.Row.Cells[index].Controls.Add(lnkButton);

                        //e.Row.Cells[index].Text = course.CourseName+"<br>"+course.Faculty;
                        if (e.Row.RowIndex == 0)
                        {
                            arr[dayid - 1] = span;
                            e.Row.Cells[index].RowSpan = span;
                        }
                        else
                        {
                            if (--arr[dayid - 1] != 0)
                            {
                                //arr[dayid - 1]--;
                                e.Row.Cells[index].Attributes.CssStyle.Add("display", "none");
                            }
                            else
                            {
                                arr[dayid - 1] = span;
                                e.Row.Cells[index].RowSpan = span;
                            }
                        }
                    }
                    index++;
                }
            }
        }
    }
}