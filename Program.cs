using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace DeleteSPListColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite spSite = new SPSite("http://mySPSite:9000"))
            {
                using (SPWeb spWeb = spSite.OpenWeb())
                {

                    SPList isoDocs = spWeb.Lists["List Name Goes Here"];
                    SPField field = isoDocs.Fields[new Guid("Item GUID Goes Here")];
                    Console.WriteLine("Field Name:" + field.InternalName);

                    field.Hidden = false;
                    field.ReadOnlyField = false;
                    field.Update();
                    isoDocs.Fields.Delete(field.InternalName);
                    Console.WriteLine("Field deleted - Done!");
                }
        }
            Console.WriteLine("Press any key...");
            Console.Read();
        }
    }
}
