﻿//==============================================================================
//  WARNING!!  This file is overwritten by the Block UI Styler while generating
//  the automation code. Any modifications to this file will be lost after
//  generating the code again.
//
//       Filename:  D:\konx10\application\Postprocess.cs
//
//        This file was generated by the NX Block UI Styler
//        Created by: CXY1
//              Version: NX 11
//              Date: 09-25-2018  (Format: mm-dd-yyyy)
//              Time: 16:44 (Format: hh-mm)
//
//==============================================================================

//==============================================================================
//  Purpose:  This TEMPLATE file contains C# source to guide you in the
//  construction of your Block application dialog. The generation of your
//  dialog file (.dlx extension) is the first step towards dialog construction
//  within NX.  You must now create a NX Open application that
//  utilizes this file (.dlx).
//
//  The information in this file provides you with the following:
//
//  1.  Help on how to load and display your Block UI Styler dialog in NX
//      using APIs provided in NXOpen.BlockStyler namespace
//  2.  The empty callback methods (stubs) associated with your dialog items
//      have also been placed in this file. These empty methods have been
//      created simply to start you along with your coding requirements.
//      The method name, argument list and possible return values have already
//      been provided for you.
//==============================================================================

//------------------------------------------------------------------------------
//These imports are needed for the following template code
//------------------------------------------------------------------------------
using System;
using NXOpen;
using NXOpen.BlockStyler;
using NXOpen.UF;
using System.Collections;
using NXOpen.Utilities;
using System.IO;
using System.Collections.Generic;

//------------------------------------------------------------------------------
//Represents Block Styler application class
//------------------------------------------------------------------------------
public class Postprocess
{
    //class members
    private static Session theSession = null;
    private static UI theUI = null;

    NXOpen.UF.UFSession theUfSession = NXOpen.UF.UFSession.GetUFSession();
    NXOpen.Part workPart = Session.GetSession().Parts.Work;

    private string theDlxFileName;
    private NXOpen.BlockStyler.BlockDialog theDialog;
    private NXOpen.BlockStyler.Group group0;// Block type: Group
    private NXOpen.BlockStyler.ListBox list_postName;// Block type: List Box
    private NXOpen.BlockStyler.FileSelection nativeFileBrowser_post;// Block type: NativeFileBrowser
    private NXOpen.BlockStyler.Group group1;// Block type: Group
    private NXOpen.BlockStyler.StringBlock string_outfile;// Block type: String
    private NXOpen.BlockStyler.StringBlock string_lastName;// Block type: String
    private NXOpen.BlockStyler.FolderSelection nativeFolderBrowser_outpath;// Block type: NativeFolderBrowser
    private NXOpen.BlockStyler.Group group;// Block type: Group
    private NXOpen.BlockStyler.StringBlock string_Unit;// Block type: String
    private NXOpen.BlockStyler.Toggle toggle_showIt;// Block type: Toggle
    private NXOpen.BlockStyler.Group group2;// Block type: Group
    private NXOpen.BlockStyler.ListBox list_ncfiles;// Block type: List Box
    private NXOpen.BlockStyler.Button button_output;// Block type: Button


    //自定义数据
    public ArrayList listPostNames = new ArrayList();
    string post_machine_name;
    int post_machine_count;


    //------------------------------------------------------------------------------
    //Constructor for NX Styler class
    //------------------------------------------------------------------------------
    public Postprocess()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theDlxFileName = "Postprocess.dlx";
            theDialog = theUI.CreateDialog(theDlxFileName);
            theDialog.AddApplyHandler(new NXOpen.BlockStyler.BlockDialog.Apply(apply_cb));
            theDialog.AddOkHandler(new NXOpen.BlockStyler.BlockDialog.Ok(ok_cb));
            theDialog.AddUpdateHandler(new NXOpen.BlockStyler.BlockDialog.Update(update_cb));
            theDialog.AddInitializeHandler(new NXOpen.BlockStyler.BlockDialog.Initialize(initialize_cb));
            theDialog.AddDialogShownHandler(new NXOpen.BlockStyler.BlockDialog.DialogShown(dialogShown_cb));
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            throw ex;
        }
    }
    //------------------------------- DIALOG LAUNCHING ---------------------------------
    //
    //    Before invoking this application one needs to open any part/empty part in NX
    //    because of the behavior of the blocks.
    //
    //    Make sure the dlx file is in one of the following locations:
    //        1.) From where NX session is launched
    //        2.) $UGII_USER_DIR/application
    //        3.) For released applications, using UGII_CUSTOM_DIRECTORY_FILE is highly
    //            recommended. This variable is set to a full directory path to a file 
    //            containing a list of root directories for all custom applications.
    //            e.g., UGII_CUSTOM_DIRECTORY_FILE=$UGII_BASE_DIR\ugii\menus\custom_dirs.dat
    //
    //    You can create the dialog using one of the following way:
    //
    //    1. Journal Replay
    //
    //        1) Replay this file through Tool->Journal->Play Menu.
    //
    //    2. USER EXIT
    //
    //        1) Create the Shared Library -- Refer "Block UI Styler programmer's guide"
    //        2) Invoke the Shared Library through File->Execute->NX Open menu.
    //
    //------------------------------------------------------------------------------
    public static void Main()
    {
        Postprocess thePostprocess = null;
        try
        {
            thePostprocess = new Postprocess();
            // The following method shows the dialog immediately
            
            thePostprocess.Show();
            



}
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        finally
        {
            if(thePostprocess != null)
                thePostprocess.Dispose();
                thePostprocess = null;
        }

        
    }
    //------------------------------------------------------------------------------
    // This method specifies how a shared image is unloaded from memory
    // within NX. This method gives you the capability to unload an
    // internal NX Open application or user  exit from NX. Specify any
    // one of the three constants as a return value to determine the type
    // of unload to perform:
    //
    //
    //    Immediately : unload the library as soon as the automation program has completed
    //    Explicitly  : unload the library from the "Unload Shared Image" dialog
    //    AtTermination : unload the library when the NX session terminates
    //
    //
    // NOTE:  A program which associates NX Open applications with the menubar
    // MUST NOT use this option since it will UNLOAD your NX Open application image
    // from the menubar.
    //------------------------------------------------------------------------------
     public static int GetUnloadOption(string arg)
    {
        //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
         return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
        // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
    }
    
    //------------------------------------------------------------------------------
    // Following method cleanup any housekeeping chores that may be needed.
    // This method is automatically called by NX.
    //------------------------------------------------------------------------------
    public static void UnloadLibrary(string arg)
    {
        try
        {
            //---- Enter your code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
    //------------------------------------------------------------------------------
    //This method shows the dialog on the screen
    //------------------------------------------------------------------------------
    public NXOpen.UIStyler.DialogResponse Show()
    {
        try
        {
            theDialog.Show();
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
    
    //------------------------------------------------------------------------------
    //Method Name: Dispose
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        if(theDialog != null)
        {
            theDialog.Dispose();
            theDialog = null;
        }
    }
    
    //------------------------------------------------------------------------------
    //---------------------Block UI Styler Callback Functions--------------------------
    //------------------------------------------------------------------------------
    
    //------------------------------------------------------------------------------
    //Callback Name: initialize_cb
    //------------------------------------------------------------------------------
    public void initialize_cb()
    {
        try
        {
            group0 = (NXOpen.BlockStyler.Group)theDialog.TopBlock.FindBlock("group0");
            list_postName = (NXOpen.BlockStyler.ListBox)theDialog.TopBlock.FindBlock("list_postName");
            nativeFileBrowser_post = (NXOpen.BlockStyler.FileSelection)theDialog.TopBlock.FindBlock("nativeFileBrowser_post");
            group1 = (NXOpen.BlockStyler.Group)theDialog.TopBlock.FindBlock("group1");
            string_outfile = (NXOpen.BlockStyler.StringBlock)theDialog.TopBlock.FindBlock("string_outfile");
            string_lastName = (NXOpen.BlockStyler.StringBlock)theDialog.TopBlock.FindBlock("string_lastName");
            nativeFolderBrowser_outpath = (NXOpen.BlockStyler.FolderSelection)theDialog.TopBlock.FindBlock("nativeFolderBrowser_outpath");
            group = (NXOpen.BlockStyler.Group)theDialog.TopBlock.FindBlock("group");
            string_Unit = (NXOpen.BlockStyler.StringBlock)theDialog.TopBlock.FindBlock("string_Unit");
            toggle_showIt = (NXOpen.BlockStyler.Toggle)theDialog.TopBlock.FindBlock("toggle_showIt");
            group2 = (NXOpen.BlockStyler.Group)theDialog.TopBlock.FindBlock("group2");
            list_ncfiles = (NXOpen.BlockStyler.ListBox)theDialog.TopBlock.FindBlock("list_ncfiles");
            button_output = (NXOpen.BlockStyler.Button)theDialog.TopBlock.FindBlock("button_output");
            //------------------------------------------------------------------------------
            //Registration of ListBox specific callbacks
            //------------------------------------------------------------------------------
            //list_postName.SetAddHandler(new NXOpen.BlockStyler.ListBox.AddCallback(AddCallback));

            //list_postName.SetDeleteHandler(new NXOpen.BlockStyler.ListBox.DeleteCallback(DeleteCallback));

            //list_ncfiles.SetAddHandler(new NXOpen.BlockStyler.ListBox.AddCallback(AddCallback));

            //list_ncfiles.SetDeleteHandler(new NXOpen.BlockStyler.ListBox.DeleteCallback(DeleteCallback));

            //------------------------------------------------------------------------------

            

            


        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: dialogShown_cb
    //This callback is executed just before the dialog launch. Thus any value set 
    //here will take precedence and dialog will be launched showing that value. 
    //------------------------------------------------------------------------------
    public void dialogShown_cb()
    {
        try
        {
            //---- Enter your callback code here -----
            show_postNameList();

        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
    }

    public void show_postNameList()
    {

        

        //遍历所有目前有的后处理器，并添加到列表框中
        //测试后置处理器名称
        int postCount;
        string[] postNames;
        theUfSession.Cam.OptAskPostNames(out postCount, out postNames);
        post_machine_count = postCount;
        //theUfSession.Ui.DisplayMessage(list_postName.GetSelectedItemBooleans().Length.ToString(), 1);

        //加入判断，如果是已经添加的将不再添加，否则会在列表框中重复出现一条

        //添加到列表框中
        for (int i = 0; i < postCount; i++)
        {
            
                listPostNames.Add(postNames[i]);
            
        }
        //对ArrayList进行判断将重复添加的名字剔除掉
        //getSingleList(listPostNames);
        //for(int i=0; i<postCount; i++)
        //{
        //    theUfSession.Ui.DisplayMessage(listPostNames[i].ToString(), 1);
        //}
        string[] temppostarray = (string[])listPostNames.ToArray(typeof(string));
        
        list_postName.SetListItems(temppostarray);


        //theUfSession.Ui.DisplayMessage(list_postName.GetSelectedItemBooleans().Length.ToString(), 1);

    }

    //进行重复元素删除操作的函数
    public static ArrayList getSingleList(ArrayList list)
    {
        ArrayList newArrayList = new ArrayList();
        foreach (string str in list)
        {
            if (!newArrayList.Contains(str))
            {
                newArrayList.Add(str);
            }
        }
        return newArrayList;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: apply_cb
    //------------------------------------------------------------------------------
    public int apply_cb()
    {
        int errorCode = 0;
        try
        {
            //---- Enter your callback code here -----

            string[] alltext = list_postName.GetSelectedItemStrings();
            for (int j = 0; j < alltext.Length; j++)
            {
                theUfSession.Ui.DisplayMessage(alltext[j], 1);
            }



        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            errorCode = 1;
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return errorCode;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: update_cb
    //------------------------------------------------------------------------------
    public int update_cb( NXOpen.BlockStyler.UIBlock block)
    {
        try
        {
            if(block == list_postName)
            {
            //---------Enter your code here-----------
            }
            else if(block == nativeFileBrowser_post)
            {
                //---------Enter your code here-----------

                string env_path = Environment.GetEnvironmentVariable("UGII_BASE_DIR");  //读取环境变量中NX的安装目录
                string env_post_path = env_path + "\\MACH\\resource\\postprocessor\\";  //进一步寻找后处理文件所在位置
                //theUfSession.Ui.DisplayMessage("测试环境变量的路径： " + env_post_path , 1);
                string post_template = env_post_path + "template_post.dat";
                //theUfSession.Ui.DisplayMessage(post_template, 1);
                


                string using_path = nativeFileBrowser_post.Path; //输出整个选择的绝对路径
                string[] post_all = using_path.Split('\\');  //通过‘\’将绝对路径进行分割
                int co = post_all.Length;  //  取得分割后字符串数组的个数
                string post_usr_all = post_all[co - 1]; //去最后一个字符数组中的字符
                string[] post_usr_all_cut = post_usr_all.Split('.'); //用'.'进行最后文件名的分割
                string post_usr_name = post_usr_all_cut[0];  //去'.'分割的第一部分，即为我们要用的文件名

                string[] add_post_name = new string[1];
                add_post_name[0] = post_usr_name;
                list_postName.SetListItems(add_post_name);
                listPostNames.Add(post_usr_name);
                string[] temparray = (string[])listPostNames.ToArray(typeof(string));
                list_postName.SetListItems(temparray);



                //先读取模板文件，按条读取，然后查重
                //theUfSession.Ui.DisplayMessage(post_template, 1); 
                StreamReader sr = new StreamReader(post_template,System.Text.Encoding.Default);
                int findstr = 0;
                
                while (sr.Peek() > -1)
                {
                    string sk = sr.ReadLine();

                    //theUfSession.Ui.DisplayMessage(sk, 1);
                    //st.WriteLine(sk);
                    int indexofcoma = sk.IndexOf(","); //加入判断，只有该举有“，”存在才进行分割，并对findstr++；
                    if (indexofcoma > -1)
                    {
                        string[] splitstr = sk.Split(',');
                        if (splitstr[0] == post_usr_name)
                        {

                            findstr++;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    //theUfSession.Ui.DisplayMessage(splitstr[0], 1);
                    //theUfSession.Ui.DisplayMessage((post_usr_name, 1);

                }
                sr.Close();
               
                //theUfSession.Ui.DisplayMessage(findstr.ToString(), 1);
                StreamWriter sw = new StreamWriter(post_template, true, System.Text.Encoding.UTF8);
                if (findstr == 0)
                {
                    sw.WriteLine(post_usr_name + "," + "${UGII_CAM_POST_DIR}" + post_usr_name + ".tcl" + "," + "${UGII_CAM_POST_DIR}" + post_usr_name + ".def");
                }

                sw.Close();
                

                //向模板文件写入
                //using (StreamWriter sw = new StreamWriter(post_template, true, System.Text.Encoding.UTF8))
                //{
                //    //先进行判断是否有重复的项，有重复的部需要重写

                //    sw.WriteLine(post_usr_name + "," + "${UGII_CAM_POST_DIR}" + post_usr_name + ".tcl" + "," + "${UGII_CAM_POST_DIR}" + post_usr_name + ".def");
                //    sw.Close();
                //}

                //复制后处理相关文件到NX后处理默认目录
                string post_file_path = nativeFileBrowser_post.Path; //后处理文件所在位置
                //theUfSession.Ui.DisplayMessage("后处理所在位置： " + post_file_path, 1);
                int laindex = post_file_path.LastIndexOf(post_usr_name + "." + "pui");
                string using_post_path = post_file_path.Substring(0, laindex);
                //theUfSession.Ui.DisplayMessage("用来复制的路径" + using_post_path, 1);

                string sc1 = using_post_path + post_usr_name + ".tcl";
                string sc2 = using_post_path + post_usr_name + ".def";
                string sc3 = using_post_path + post_usr_name + ".pui";

                string aim_path = env_post_path;  //要复制到的路径
                string ncf1 = aim_path + post_usr_name + ".tcl";
                string ncf2 = aim_path + post_usr_name + ".def";
                string ncf3 = aim_path + post_usr_name + ".pui";
                //合成复制文件路径
                var ncf1_path = Path.Combine(ncf1);
                var ncf2_path = Path.Combine(ncf2);
                var ncf3_path = Path.Combine(ncf3);

                //复制文件
                File.Copy(sc1, ncf1_path, true);
                File.Copy(sc2, ncf2_path, true);
                File.Copy(sc3, ncf3_path, true);

                


            }
            else if(block == string_outfile)
            {
                //---------Enter your code here-----------
                
               

            }
            else if(block == string_lastName)
            {
            //---------Enter your code here-----------
            }
            else if(block == nativeFolderBrowser_outpath)
            {
            //---------Enter your code here-----------
            }
            else if(block == string_Unit)
            {
            //---------Enter your code here-----------
            }
            else if(block == toggle_showIt)
            {
            //---------Enter your code here-----------
            }
            else if(block == list_ncfiles)
            {
            //---------Enter your code here-----------
            }
            else if(block == button_output)
            {
                //---------Enter your code here-----------

                //输出后处理
                //将选中的节点的数量及tag返回
                int selectNodeCount;
                Tag[] selTags;
                theUfSession.UiOnt.AskSelectedNodes(out selectNodeCount, out selTags);
                string[] postlistName = new string[selectNodeCount];

                NXOpen.CAM.CAMObject[] camObjects = new NXOpen.CAM.CAMObject[selectNodeCount];

                //取得当前工作部件的目录，并将其设置在输出目录里
                string wholepath = workPart.FullPath;
                string part_name = workPart.Name;
                int indexofName = wholepath.LastIndexOf(part_name);
                string workpath = wholepath.Substring(0, indexofName);
                //theUfSession.Ui.DisplayMessage(workpath, 1);  //测试工作目录是否正确


                //返回选中的后处理器的名称

                string[] usingpostname = list_postName.GetSelectedItemStrings();  //获取选中的后处理器的名称，用于后处理设置中给定的machine name，每次后处理只允许选取一个后处理器，不允许多选，因此取“0”个元素
                //theUfSession.Ui.DisplayMessage("选中的列的文本： " + usingpostname[0], 1);
                
                string[] all_postmachin_name = list_postName.GetListItems();
                post_machine_name = usingpostname[0];


                //开始设置循环，进行多个程序文件的后处理
                for (int i = 0; i < selectNodeCount; i++)
                {
                    camObjects[i] = (NXOpen.CAM.CAMObject)NXObjectManager.Get(selTags[i]);
                    postlistName[i] = camObjects[i].Name + "." + string_lastName.Value;
                    //theUfSession.Ui.DisplayMessage("选中的后处理器名称" + post_machine_name, 1);
                    string testpath = string_outfile.Value + @"\" + postlistName[i];
                    //theUfSession.Ui.DisplayMessage("路径是： " + testpath, 1);
                    NXOpen.CAM.CAMObject[] tempObj = new NXOpen.CAM.CAMObject[1];
                    tempObj[0] = camObjects[i];
                    //nativeFolderBrowser_outpath.Path = string_outfile.Value + "\\" + camObjects[i].Name;
                    //theUfSession.Ui.DisplayMessage("输出文件路径： " + nativeFile_outfilepath.Path, 1);
                    //workPart.CAMSetup.OutputClsf(tempObj, enum_clsf.ValueAsString, nativeFolderBrowser_Path.Path + camObjects[i].Name, NXOpen.CAM.CAMSetup.OutputUnits.Metric);
                    workPart.CAMSetup.PostprocessWithSetting(tempObj, post_machine_name, string_outfile.Value + "\\" + postlistName[i], NXOpen.CAM.CAMSetup.OutputUnits.Metric, NXOpen.CAM.CAMSetup.PostprocessSettingsOutputWarning.PostDefined, NXOpen.CAM.CAMSetup.PostprocessSettingsReviewTool.PostDefined);
                }

                


            }
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return 0;
    }
    
    //------------------------------------------------------------------------------
    //Callback Name: ok_cb
    //------------------------------------------------------------------------------
    public int ok_cb()
    {
        int errorCode = 0;
        try
        {
            errorCode = apply_cb();
            //---- Enter your callback code here -----
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            errorCode = 1;
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return errorCode;
    }
    //------------------------------------------------------------------------------
    //ListBox specific callbacks
    //------------------------------------------------------------------------------
    //public int  AddCallback (NXOpen.BlockStyler.ListBox list_box)
    //{
    //}
    
    //public int  DeleteCallback(NXOpen.BlockStyler.ListBox list_box)
    //{
    //}
    
    //------------------------------------------------------------------------------
    
    //------------------------------------------------------------------------------
    //Function Name: GetBlockProperties
    //Returns the propertylist of the specified BlockID
    //------------------------------------------------------------------------------
    public PropertyList GetBlockProperties(string blockID)
    {
        PropertyList plist =null;
        try
        {
            plist = theDialog.GetBlockProperties(blockID);
        }
        catch (Exception ex)
        {
            //---- Enter your exception handling code here -----
            theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
        }
        return plist;
    }
    
}
