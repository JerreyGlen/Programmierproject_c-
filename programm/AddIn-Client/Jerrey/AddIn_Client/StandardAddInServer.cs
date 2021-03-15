using System;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;

namespace AddIn_Client
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("bc64c9d9-d8e7-4103-8657-7a81ca98a92f")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {

        // Inventor application object.
        private Inventor.Application m_inventorApplication;

        public StandardAddInServer()
        {
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {

            // This method is called by Inventor when it loads the addin.
            // The AddInSiteObject provides access to the Inventor Application object.
            // The FirstTime flag indicates if the addin is loaded for the first time.
            AddinGlobal.InventorApp = addInSiteObject.Application;

            // Initialize AddIn members.
            m_inventorApplication = addInSiteObject.Application;
            try
            {
                AddinGlobal.GetAddinClassId(this.GetType());
                Icon icon1 = Properties.Resources.button_turn_on;
                Icon icon2 = Properties.Resources.log_door;
                Icon icon3 = Properties.Resources.chat_31;
                Icon icon4 = Properties.Resources.off_on_power_energy_1_;
                Icon icon5 = null;

                //Icon icon1 = new Icon(this.GetType(), "InventorAddIn1.Properties.AddSlotOption.ico"); //Change it if necessary but make sure it's embedded.
                //Button1
                InventorButton button1 = new InventorButton(
                    "Session erstellen", "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Erstellen Sie eine neue Session",
                    icon1, icon1,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button1.SetBehavior(true, true, true);
                button1.Execute = ButtonAction.Button1_Execute;
                //Button2
                InventorButton button2 = new InventorButton(
                    "Beitreten", "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Eine Session beitreten",
                    icon2, icon2,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button2.SetBehavior(true, true, true);
                button2.Execute = ButtonAction.Button2_Execute;
                //Button3
                InventorButton button3 = new InventorButton(
                    "Messages", "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "See your Messages",
                    icon3, icon3,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button3.SetBehavior(true, true, true);
                button3.Execute = ButtonAction.Button3_Execute;
                //Button4
                InventorButton button4 = new InventorButton(
                    "Beenden", "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Beenden Sie die Session",
                    icon4, icon4,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button4.SetBehavior(true, true, true);
                button4.Execute = ButtonAction.Button4_Execute;
                //Button5
                InventorButton button5 = new InventorButton(
                    "Username: \n Meeting-ID: ", "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Info",
                    icon5, icon5,
                    CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button5.SetBehavior(true, true, true);
                button5.Execute = ButtonAction.Button5_Execute;
                ButtonAction.InventorApp = m_inventorApplication;

                if (firstTime == true)
                {
                    UserInterfaceManager uiMan = AddinGlobal.InventorApp.UserInterfaceManager;
                    if (uiMan.InterfaceStyle == InterfaceStyleEnum.kRibbonInterface) //kClassicInterface support can be added if necessary.
                    {
                        /*Inventor.Ribbon ribbon = uiMan.Ribbons["Assem"];//["Part"];
                        RibbonTab tab = ribbon.RibbonTabs["id_TabTools"]; //Change it if necessary.*/

                        //Assembly
                        Inventor.Ribbons ribbon = uiMan.Ribbons;
                        Inventor.Ribbon assemblyRibbon = ribbon["Assembly"];
                        RibbonTabs ribbonTabs = assemblyRibbon.RibbonTabs;
                        RibbonTab tab = ribbonTabs["id_AddInsTab"];
                        //CommandBarList ContextMenuList/ CommandBar DefaultMenuBar
                        AddinGlobal.RibbonPanelId = "{d04e0c45-dec6-4881-bd3f-a7a81b99f307}";
                        AddinGlobal.assemblyRibbonPanel = tab.RibbonPanels.Add(
                            "AddOutButtons",
                            "AddOutButtons.RibbonPanel_" + Guid.NewGuid().ToString(),
                            AddinGlobal.RibbonPanelId, String.Empty, true);
                        AddinGlobal.RibbonPanels.Add(AddinGlobal.assemblyRibbonPanel);
                        CommandControls cmdCtrls = AddinGlobal.assemblyRibbonPanel.CommandControls;
                        cmdCtrls.AddButton(button1.ButtonDef, button1.DisplayBigIcon, button1.DisplayText, "", button1.InsertBeforeTarget);
                        cmdCtrls.AddButton(button2.ButtonDef, button2.DisplayBigIcon, button2.DisplayText, "", button2.InsertBeforeTarget);
                        cmdCtrls.AddButton(button3.ButtonDef, button3.DisplayBigIcon, button3.DisplayText, "", button3.InsertBeforeTarget);
                        cmdCtrls.AddButton(button4.ButtonDef, button4.DisplayBigIcon, button4.DisplayText, "", button4.InsertBeforeTarget);
                        
                        //Part
                        Inventor.Ribbon partRibbon = ribbon["Part"];
                        RibbonTabs partRibbonTabs = partRibbon.RibbonTabs;
                        RibbonTab modelRibbonTab = partRibbonTabs["id_AddInsTab"];
                        //CommandBarList ContextMenuList/ CommandBar DefaultMenuBar
                        AddinGlobal.RibbonPanelId = "{d04e0c45-dec6-4881-bd3f-a7a81b99f307}";
                        AddinGlobal.partRibbonPanel = modelRibbonTab.RibbonPanels.Add(
                            "AddOutButtons",
                            "AddOutButtons.RibbonPanel_" + Guid.NewGuid().ToString(),
                            AddinGlobal.RibbonPanelId, String.Empty, true);
                        AddinGlobal.RibbonPanels.Add(AddinGlobal.partRibbonPanel);

                        CommandControls pcmdCtrls = AddinGlobal.partRibbonPanel.CommandControls;
                        pcmdCtrls.AddButton(button1.ButtonDef, button1.DisplayBigIcon, button1.DisplayText, "", button1.InsertBeforeTarget);
                        pcmdCtrls.AddButton(button2.ButtonDef, button2.DisplayBigIcon, button2.DisplayText, "", button2.InsertBeforeTarget);
                        pcmdCtrls.AddButton(button3.ButtonDef, button3.DisplayBigIcon, button3.DisplayText, "", button3.InsertBeforeTarget);
                        pcmdCtrls.AddButton(button4.ButtonDef, button4.DisplayBigIcon, button4.DisplayText, "", button4.InsertBeforeTarget);
                        
                        //Drawing
                        Inventor.Ribbon drawingRibbon = ribbon["Drawing"];
                        RibbonTabs drawingRibbonTabs = drawingRibbon.RibbonTabs;
                        RibbonTab drawingRibbonTab = drawingRibbonTabs["id_AddInsTab"];
                        //CommandBarList ContextMenuList/ CommandBar DefaultMenuBar
                        AddinGlobal.RibbonPanelId = "{d04e0c45-dec6-4881-bd3f-a7a81b99f307}";
                        AddinGlobal.drawingRibbonPanel = drawingRibbonTab.RibbonPanels.Add(
                            "AddOutButtons",
                            "AddOutButtons.RibbonPanel_" + Guid.NewGuid().ToString(),
                            AddinGlobal.RibbonPanelId, String.Empty, true);
                        AddinGlobal.RibbonPanels.Add(AddinGlobal.drawingRibbonPanel);


                        CommandControls dcmdCtrls = AddinGlobal.drawingRibbonPanel.CommandControls;
                        dcmdCtrls.AddButton(button1.ButtonDef, button1.DisplayBigIcon, button1.DisplayText, "", button1.InsertBeforeTarget);
                        dcmdCtrls.AddButton(button2.ButtonDef, button2.DisplayBigIcon, button2.DisplayText, "", button2.InsertBeforeTarget);
                        dcmdCtrls.AddButton(button3.ButtonDef, button3.DisplayBigIcon, button3.DisplayText, "", button3.InsertBeforeTarget);
                        dcmdCtrls.AddButton(button4.ButtonDef, button4.DisplayBigIcon, button4.DisplayText, "", button4.InsertBeforeTarget);

                        /* Get the 2d sketch environment base object
                        Inventor.Environment partSketchEnvironment;
                        partSketchEnvironment = userInterfaceManager.Environments["PMxPartSketchEnvironment"];

                        //make this command bar accessible in the panel menu for the 2d sketch environment.
                        partSketchEnvironment.PanelBar.CommandBarList.Add(slotCommandBar);*/



                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            // TODO: Add ApplicationAddInServer.Activate implementation.
            // e.g. event initialization, command creation etc.
        }

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated

            // TODO: Add ApplicationAddInServer.Deactivate implementation

            // Release objects.
            try
            {
                foreach (InventorButton button in AddinGlobal.ButtonList)
                {
                    if (button.ButtonDef != null) Marshal.FinalReleaseComObject(button.ButtonDef);
                }
                if (AddinGlobal.assemblyRibbonPanel != null) Marshal.FinalReleaseComObject(AddinGlobal.assemblyRibbonPanel);
                if (AddinGlobal.partRibbonPanel != null) Marshal.FinalReleaseComObject(AddinGlobal.partRibbonPanel);
                if (AddinGlobal.drawingRibbonPanel != null) Marshal.FinalReleaseComObject(AddinGlobal.drawingRibbonPanel);
                if (AddinGlobal.InventorApp != null) Marshal.FinalReleaseComObject(AddinGlobal.InventorApp);

                m_inventorApplication = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {
                // TODO: Add ApplicationAddInServer.Automation getter implementation
                return null;
            }
        }

        #endregion

    }
}
