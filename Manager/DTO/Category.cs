using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.DTO
{
    public class Category
    {
        public Category(int id, String name)
        {
            this.ID = id;
            this.Name = name;
            
        }

        public Category(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["Name"].ToString();
            
        }

       
        private String name;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
       
    }
}
