using DBSlideDataContext.DTO;
using I3.DBSlideASP.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I3.DBSlideASP.MVC.Handlers
{
    public static class Mapper
    {
        public static StudentListItem ToListItem(this Student student)
        {
            if (student is null) return null;
            return new StudentListItem
            {
                Id = student.Student_ID,
                Nom = student.Last_Name,
                Prenom = student.First_Name,
                Section_id = student.Section_ID
            };
        }
    }
}
