using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSch.DAL
{
    public class Course
    {
        private int _courseid;
        private String _sctionname;
        private String _faculty;
        private String _coursename;

        public int CourseId
        {
            get { return _courseid; }
            set { _courseid = value; }
        }

        public String SectionName
        {
            get { return _sctionname; }
            set { _sctionname= value; }
        }
        public String Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }
        public String CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }

    }
}