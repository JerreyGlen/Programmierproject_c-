using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Inventor;

namespace AddIn_Client
{
    public class AddinGlobal
    {
        public static Inventor.Application InventorApp;

        public static string RibbonPanelId;
        public static RibbonPanel assemblyRibbonPanel;
        public static RibbonPanel partRibbonPanel;
        public static RibbonPanel drawingRibbonPanel;
        public static List<RibbonPanel> RibbonPanels = new List<RibbonPanel>(3);
        public static List<InventorButton> ButtonList = new List<InventorButton>();

        private static string mClassId;
        public static string ClassId
        {
            get
            {
                if (!string.IsNullOrEmpty(mClassId))
                    return AddinGlobal.mClassId;
                else
                    throw new System.Exception("The addin server class id hasn't been gotten yet!");
            }
            set { AddinGlobal.mClassId = value; }
        }

        public static void GetAddinClassId(Type t)
        {
            GuidAttribute guidAtt = (GuidAttribute)GuidAttribute.GetCustomAttribute(t, typeof(GuidAttribute));
            mClassId = "{" + guidAtt.Value + "}";
        }
    }
}
