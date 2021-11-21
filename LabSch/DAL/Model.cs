using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabSch.DAL
{
    public class Model
    {
        public DataTable getDays()
        {
            String sql = "SELECT * FROM days";
            using (SqlDataAdapter dad = new SqlDataAdapter(sql, Db.getConnection()))
            {
                DataTable dtDays = new DataTable();
                dad.Fill(dtDays);

                return dtDays;
            }
        }

        public DataTable getSlots()
        {
            String sql = "SELECT * FROM slots";
            using (SqlDataAdapter dad = new SqlDataAdapter(sql, Db.getConnection()))
            {
                DataTable dtSlots = new DataTable();
                dad.Fill(dtSlots);
                foreach (DataRow row in getDays().Rows)
                {
                    dtSlots.Columns.Add(new DataColumn(row["dayname"].ToString(), typeof(System.String)));
                }
                return dtSlots;
            }
        }

        public Dictionary<string, Course> getdLabSch()
        {
            String sql = "SELECT labschedule.schid, course.*, labschedule.dayid, labschedule.slotid " +
                "FROM course RIGHT OUTER JOIN  " +
                "labschedule ON course.courseid = labschedule.courseid";
            using (SqlDataAdapter dad = new SqlDataAdapter(sql, Db.getConnection()))
            {
                Dictionary<string, Course> schs = new Dictionary<string, Course>();
                DataTable dtLabs = new DataTable();
                dad.Fill(dtLabs);
                String key = "";
                foreach(DataRow row in dtLabs.Rows)
                {
                    key = row["slotid"] + "-" + row["dayid"];

                    Course course = new Course()
                    {
                        CourseId = (int)row["courseid"], 
                        CourseName = (string)row["coursename"], 
                        SectionName = (string)row["sectionname"],
                        Faculty = (string)row["faculty"],
                    };

                    schs.Add(key, course);
                }
                return schs;
            }
        }
    }
}