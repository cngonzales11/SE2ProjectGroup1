using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class CheckItemExsist
    {
        public List<Items> items = new List<Items>();
        //check if Item exists
        public bool CheckItem(Items item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == item.ID)
                    return true;
            }
            return false;
        }
    }

