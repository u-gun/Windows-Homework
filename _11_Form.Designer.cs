namespace _9_1113;

partial class _11_Form
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_11_Form));
        ListViewItem listViewItem6 = new ListViewItem(new string[] { "대한민국", "서울", "아시아", "0.5M", "082" }, 1);
        ListViewItem listViewItem7 = new ListViewItem(new string[] { "미국", "워싱턴", "아메리카", "3.0M", "01" }, 2);
        ListViewItem listViewItem8 = new ListViewItem(new string[] { "영국", "파리", "유럽", "0.6M", "33" }, 0);
        ListViewItem listViewItem9 = new ListViewItem(new string[] { "이집트", "카이로", "아프리카", "1.1M", "20" }, -1);
        ListViewItem listViewItem10 = new ListViewItem(new string[] { "호주", "호주", "캔버라", "0.2M", "61" }, -1);
        TreeNode treeNode6 = new TreeNode("바탕화면");
        TreeNode treeNode7 = new TreeNode("다운로드");
        TreeNode treeNode8 = new TreeNode("C:\\");
        TreeNode treeNode9 = new TreeNode("D:\\");
        TreeNode treeNode10 = new TreeNode("내 컴퓨터", 22, 23, new TreeNode[] { treeNode6, treeNode7, treeNode8, treeNode9 });
        imageList_icon = new ImageList(components);
        imageList_winIcon = new ImageList(components);
        imageList_flag = new ImageList(components);
        radioButton_LargeIcon = new RadioButton();
        radioButton_SmallIcon = new RadioButton();
        radioButton_List = new RadioButton();
        radioButton_Tile = new RadioButton();
        radioButton_Details = new RadioButton();
        listView1 = new ListView();
        nation = new ColumnHeader();
        capital = new ColumnHeader();
        area = new ColumnHeader();
        Population = new ColumnHeader();
        Number = new ColumnHeader();
        comboBox_view = new ComboBox();
        label_nation = new Label();
        treeView1 = new TreeView();
        textBox_tree = new TextBox();
        button_insert = new Button();
        button_delete = new Button();
        domainUpDown_class = new DomainUpDown();
        button_insert_class_in_treeView = new Button();
        numericUpDown_Calculator = new NumericUpDown();
        panel_calculator = new Panel();
        trackBar_calculator = new TrackBar();
        C_result_SQRT = new TextBox();
        label3 = new Label();
        C_result_SQR = new TextBox();
        label2 = new Label();
        C_result_log = new TextBox();
        label1 = new Label();
        timer_frame = new System.Windows.Forms.Timer(components);
        label_weightlifting = new Label();
        imageList_weightlifting = new ImageList(components);
        imageList1 = new ImageList(components);
        label_golf = new Label();
        imageList_golf = new ImageList(components);
        imageList_tenis = new ImageList(components);
        label_tenis = new Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Calculator).BeginInit();
        panel_calculator.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar_calculator).BeginInit();
        SuspendLayout();
        // 
        // imageList_icon
        // 
        imageList_icon.ColorDepth = ColorDepth.Depth32Bit;
        imageList_icon.ImageStream = (ImageListStreamer)resources.GetObject("imageList_icon.ImageStream");
        imageList_icon.TransparentColor = Color.Transparent;
        imageList_icon.Images.SetKeyName(0, "Actions_5847.ico");
        imageList_icon.Images.SetKeyName(1, "ActiveServerPage(asp)_11272.ico");
        imageList_icon.Images.SetKeyName(2, "AllLoadedTests_8546.ico");
        imageList_icon.Images.SetKeyName(3, "Assembly_6212.ico");
        imageList_icon.Images.SetKeyName(4, "Assembly-excluded_5817.ico");
        imageList_icon.Images.SetKeyName(5, "Association.ico");
        imageList_icon.Images.SetKeyName(6, "Association_12860.ico");
        imageList_icon.Images.SetKeyName(7, "AssociationEditor_5849.ico");
        imageList_icon.Images.SetKeyName(8, "BarSeries_12624.ico");
        imageList_icon.Images.SetKeyName(9, "Battery.ico");
        imageList_icon.Images.SetKeyName(10, "bios.ico");
        imageList_icon.Images.SetKeyName(11, "BorderElement_10699.ico");
        imageList_icon.Images.SetKeyName(12, "Branch_13220.ico");
        imageList_icon.Images.SetKeyName(13, "BrokenlinktoFile_431_24.ico");
        imageList_icon.Images.SetKeyName(14, "Bullets_11690.ico");
        imageList_icon.Images.SetKeyName(15, "CABProject_5818.ico");
        imageList_icon.Images.SetKeyName(16, "cctprojectnode_ID09.ico");
        imageList_icon.Images.SetKeyName(17, "CheckBox_669.ico");
        imageList_icon.Images.SetKeyName(18, "ClassIcon.ico");
        imageList_icon.Images.SetKeyName(19, "Clearallrequests_8816.ico");
        imageList_icon.Images.SetKeyName(20, "CloudStorageContainer.ico");
        imageList_icon.Images.SetKeyName(21, "CloudStorageContainerCollection.ico");
        imageList_icon.Images.SetKeyName(22, "ColorSelectionTool_202.ico");
        imageList_icon.Images.SetKeyName(23, "CompiledMSHelpFile_11556.ico");
        imageList_icon.Images.SetKeyName(24, "componentcategory.ico");
        imageList_icon.Images.SetKeyName(25, "ComponentDiagramFile_componentdiagram_13449.ico");
        imageList_icon.Images.SetKeyName(26, "computersystemproduct.ico");
        imageList_icon.Images.SetKeyName(27, "Conditions_5855.ico");
        imageList_icon.Images.SetKeyName(28, "Counter_5730.ico");
        imageList_icon.Images.SetKeyName(29, "CPPWMIEventProvider_7864.ico");
        imageList_icon.Images.SetKeyName(30, "CustomActions_6334.ico");
        imageList_icon.Images.SetKeyName(31, "CustomActionsEditor_5850.ico");
        imageList_icon.Images.SetKeyName(32, "DatabaseProject_7342.ico");
        imageList_icon.Images.SetKeyName(33, "DataGrid_674.ico");
        imageList_icon.Images.SetKeyName(34, "DataTable_8468.ico");
        imageList_icon.Images.SetKeyName(35, "DBSchema_12823.ico");
        imageList_icon.Images.SetKeyName(36, "DeadLetterMessages_5733.ico");
        imageList_icon.Images.SetKeyName(37, "Delegate_8339.ico");
        imageList_icon.Images.SetKeyName(38, "DeploymentDiagram(SubsystemMapper)_11298.ico");
        imageList_icon.Images.SetKeyName(39, "DGSL_file_type.ico");
        imageList_icon.Images.SetKeyName(40, "Diagram_8283.ico");
        imageList_icon.Images.SetKeyName(41, "DialogGroup_5846.ico");
        imageList_icon.Images.SetKeyName(42, "DisplayConfiguration.ico");
        imageList_icon.Images.SetKeyName(43, "dmaChannel.ico");
        imageList_icon.Images.SetKeyName(44, "DriverTestCancelledResult.ico");
        imageList_icon.Images.SetKeyName(45, "DriverTestPassingResult.ico");
        imageList_icon.Images.SetKeyName(46, "drivervxd.ico");
        imageList_icon.Images.SetKeyName(47, "Editdatasetwithdesigner_8449.ico");
        imageList_icon.Images.SetKeyName(48, "EllipseElement_10707.ico");
        imageList_icon.Images.SetKeyName(49, "Enumeration_8335.ico");
        imageList_icon.Images.SetKeyName(50, "Error_6206.ico");
        imageList_icon.Images.SetKeyName(51, "Error_grey_677_16x16.ico");
        imageList_icon.Images.SetKeyName(52, "Error_red.ico");
        imageList_icon.Images.SetKeyName(53, "Error_red_16x16_cyan.ico");
        imageList_icon.Images.SetKeyName(54, "EventLog_5735.ico");
        imageList_icon.Images.SetKeyName(55, "EventLogFailureAudit_5737.ico");
        imageList_icon.Images.SetKeyName(56, "EventLogSuccessAudit_5739.ico");
        imageList_icon.Images.SetKeyName(57, "Extend_13492.ico");
        imageList_icon.Images.SetKeyName(58, "ExtendedStoredProcedure_8284.ico");
        imageList_icon.Images.SetKeyName(59, "ExtensionManager_vsix_OSReg.ico");
        imageList_icon.Images.SetKeyName(60, "ExtensionManager_vsixproject.ico");
        imageList_icon.Images.SetKeyName(61, "FeatureNotAvailable_5734.ico");
        imageList_icon.Images.SetKeyName(62, "FeatureNotAvailable_5734_12x12_16x.ico");
        imageList_icon.Images.SetKeyName(63, "FeatureNotAvailable_5734_12x12_16x_cyan.ico");
        imageList_icon.Images.SetKeyName(64, "FeatureNotAvailable_5734_cyan.ico");
        imageList_icon.Images.SetKeyName(65, "FieldsHeader.ico");
        imageList_icon.Images.SetKeyName(66, "filedownload.ico");
        imageList_icon.Images.SetKeyName(67, "File-exclude_5820.ico");
        imageList_icon.Images.SetKeyName(68, "FileSystemEditor_5852.ico");
        imageList_icon.Images.SetKeyName(69, "FillTool_204.ico");
        imageList_icon.Images.SetKeyName(70, "Find_5650.ico");
        imageList_icon.Images.SetKeyName(71, "Flagthread_7317.ico");
        imageList_icon.Images.SetKeyName(72, "FloppyDrive.ico");
        imageList_icon.Images.SetKeyName(73, "Folder(special)_5843.ico");
        imageList_icon.Images.SetKeyName(74, "Folder(special-open)_5844.ico");
        imageList_icon.Images.SetKeyName(75, "Folder_6221.ico");
        imageList_icon.Images.SetKeyName(76, "Folder_6222.ico");
        imageList_icon.Images.SetKeyName(77, "Font_6007.ico");
        imageList_icon.Images.SetKeyName(78, "GenericVSEditor_9905.ico");
        imageList_icon.Images.SetKeyName(79, "GenericVSProject_9906.ico");
        imageList_icon.Images.SetKeyName(80, "GenericVSToolWindowRepresentation_9908.ico");
        imageList_icon.Images.SetKeyName(81, "GlobalApplicationClass(asax)_443.ico");
        imageList_icon.Images.SetKeyName(82, "GotoNextRow_289.ico");
        imageList_icon.Images.SetKeyName(83, "GoToSourceCode_6546.ico");
        imageList_icon.Images.SetKeyName(84, "GroupBy_284.ico");
        imageList_icon.Images.SetKeyName(85, "HardDrive_9462.ico");
        imageList_icon.Images.SetKeyName(86, "HiddenFolder_427.ico");
        imageList_icon.Images.SetKeyName(87, "HiddenFolder_428.ico");
        imageList_icon.Images.SetKeyName(88, "HTMLPage(HTM)_825.ico");
        imageList_icon.Images.SetKeyName(89, "Index_8287.ico");
        imageList_icon.Images.SetKeyName(90, "Information_blue_6227.ico");
        imageList_icon.Images.SetKeyName(91, "Information_blue_6227_16x16_cyan.ico");
        imageList_icon.Images.SetKeyName(92, "infrareddevice.ico");
        imageList_icon.Images.SetKeyName(93, "InputParameter_8288.ico");
        imageList_icon.Images.SetKeyName(94, "Instance_5746.ico");
        imageList_icon.Images.SetKeyName(95, "IntelliTrace.ico");
        imageList_icon.Images.SetKeyName(96, "Interface_612.ico");
        imageList_icon.Images.SetKeyName(97, "JournalMessages_5742.ico");
        imageList_icon.Images.SetKeyName(98, "KeyOutput_8167.ico");
        imageList_icon.Images.SetKeyName(99, "LaunchConditionsEditor_259.ico");
        imageList_icon.Images.SetKeyName(100, "LayerDiagramfile_layerdiagram_13450.ico");
        imageList_icon.Images.SetKeyName(101, "Library_6213.ico");
        imageList_icon.Images.SetKeyName(102, "LinkedServer_12789.ico");
        imageList_icon.Images.SetKeyName(103, "ListsofTests_8643.ico");
        imageList_icon.Images.SetKeyName(104, "ListView_687.ico");
        imageList_icon.Images.SetKeyName(105, "LOBSystemInstance.ico");
        imageList_icon.Images.SetKeyName(106, "LockControls_322.ico");
        imageList_icon.Images.SetKeyName(107, "logicalmemoryconfiguration.ico");
        imageList_icon.Images.SetKeyName(108, "Login_6031.ico");
        imageList_icon.Images.SetKeyName(109, "LoginScreen_7349.ico");
        imageList_icon.Images.SetKeyName(110, "MainMenuControl_688.ico");
        imageList_icon.Images.SetKeyName(111, "MasterPage_6478.ico");
        imageList_icon.Images.SetKeyName(112, "Measure.ico");
        imageList_icon.Images.SetKeyName(113, "memoryarray.ico");
        imageList_icon.Images.SetKeyName(114, "memorydevice.ico");
        imageList_icon.Images.SetKeyName(115, "MemoryWindow_6537.ico");
        imageList_icon.Images.SetKeyName(116, "MergeModule-exclude_5824.ico");
        imageList_icon.Images.SetKeyName(117, "MergeModuleReference_6335.ico");
        imageList_icon.Images.SetKeyName(118, "MergeModuleReference-excluded_6336.ico");
        imageList_icon.Images.SetKeyName(119, "Method_636.ico");
        imageList_icon.Images.SetKeyName(120, "MethodInstance.ico");
        imageList_icon.Images.SetKeyName(121, "ModelingProject_13455.ico");
        imageList_icon.Images.SetKeyName(122, "motherboarddevice.ico");
        imageList_icon.Images.SetKeyName(123, "MovePrevious_7195.ico");
        imageList_icon.Images.SetKeyName(124, "MSHelpCollectionDefinitionFile_11560.ico");
        imageList_icon.Images.SetKeyName(125, "MSNETFrameworkDependencies_9538.ico");
        imageList_icon.Images.SetKeyName(126, "MultipleOutput-exclude_5825.ico");
        imageList_icon.Images.SetKeyName(127, "NavigateBackwards_6270.ico");
        imageList_icon.Images.SetKeyName(128, "NavigateForward_6271.ico");
        imageList_icon.Images.SetKeyName(129, "NegativeAcknowledgementMessage_5745.ico");
        imageList_icon.Images.SetKeyName(130, "networkadapter.ico");
        imageList_icon.Images.SetKeyName(131, "networkadapterconfiguration.ico");
        imageList_icon.Images.SetKeyName(132, "NetworkMixnode_8709.ico");
        imageList_icon.Images.SetKeyName(133, "NewSolutionFolder_6289.ico");
        imageList_icon.Images.SetKeyName(134, "ODBCAttribute.ico");
        imageList_icon.Images.SetKeyName(135, "OneLevelUp_5834.ico");
        imageList_icon.Images.SetKeyName(136, "Open_6296.ico");
        imageList_icon.Images.SetKeyName(137, "OutputParameter_8289.ico");
        imageList_icon.Images.SetKeyName(138, "PageFile.ico");
        imageList_icon.Images.SetKeyName(139, "ParallelPort.ico");
        imageList_icon.Images.SetKeyName(140, "ParametersInfo_2423.ico");
        imageList_icon.Images.SetKeyName(141, "patchpackage.ico");
        imageList_icon.Images.SetKeyName(142, "PencilTool_206.ico");
        imageList_icon.Images.SetKeyName(143, "Permission_12796.ico");
        imageList_icon.Images.SetKeyName(144, "pnpentity.ico");
        imageList_icon.Images.SetKeyName(145, "PositiveAcknowledgementMessage_5748.ico");
        imageList_icon.Images.SetKeyName(146, "PotsModem.ico");
        imageList_icon.Images.SetKeyName(147, "PrepareProcess.ico");
        imageList_icon.Images.SetKeyName(148, "Print_11009.ico");
        imageList_icon.Images.SetKeyName(149, "PrivateQueue_5749.ico");
        imageList_icon.Images.SetKeyName(150, "Procedure_8937.ico");
        imageList_icon.Images.SetKeyName(151, "processes_5760.ico");
        imageList_icon.Images.SetKeyName(152, "Processor.ico");
        imageList_icon.Images.SetKeyName(153, "PropertyIcon.ico");
        imageList_icon.Images.SetKeyName(154, "PublicQueue_5750.ico");
        imageList_icon.Images.SetKeyName(155, "RegistryEditor_5838.ico");
        imageList_icon.Images.SetKeyName(156, "RegistryValueforBinaryType_5839.ico");
        imageList_icon.Images.SetKeyName(157, "RegistryValueforStringType_5840.ico");
        imageList_icon.Images.SetKeyName(158, "Relation_8467.ico");
        imageList_icon.Images.SetKeyName(159, "Reports-collapsed_12995.ico");
        imageList_icon.Images.SetKeyName(160, "ReturnValue_8291.ico");
        imageList_icon.Images.SetKeyName(161, "RolesNode_Valid_Closed.ico");
        imageList_icon.Images.SetKeyName(162, "Rules.ico");
        imageList_icon.Images.SetKeyName(163, "Save_6530.ico");
        imageList_icon.Images.SetKeyName(164, "ScriptFile_452.ico");
        imageList_icon.Images.SetKeyName(165, "scsicontroller.ico");
        imageList_icon.Images.SetKeyName(166, "SequenceDiagramFile_sequencediagram_13452.ico");
        imageList_icon.Images.SetKeyName(167, "Server_5720.ico");
        imageList_icon.Images.SetKeyName(168, "ServerProject.ico");
        imageList_icon.Images.SetKeyName(169, "ServicePause_5722.ico");
        imageList_icon.Images.SetKeyName(170, "Services_5724.ico");
        imageList_icon.Images.SetKeyName(171, "ServicesStop_5725.ico");
        imageList_icon.Images.SetKeyName(172, "ServiceStart_5723.ico");
        imageList_icon.Images.SetKeyName(173, "ServiceUnknown_5726.ico");
        imageList_icon.Images.SetKeyName(174, "Setup_6331.ico");
        imageList_icon.Images.SetKeyName(175, "SetupProjectWizard_5827.ico");
        imageList_icon.Images.SetKeyName(176, "setup-v.ico");
        imageList_icon.Images.SetKeyName(177, "Shortcut_8169.ico");
        imageList_icon.Images.SetKeyName(178, "ShowDiagramPane_280.ico");
        imageList_icon.Images.SetKeyName(179, "ShowPerformanceSession_7015.ico");
        imageList_icon.Images.SetKeyName(180, "ShowResultsPane_282.ico");
        imageList_icon.Images.SetKeyName(181, "ShowStartPage_6283.ico");
        imageList_icon.Images.SetKeyName(182, "SingleMessage_5727.ico");
        imageList_icon.Images.SetKeyName(183, "SingleOutput_8170.ico");
        imageList_icon.Images.SetKeyName(184, "SingleOutput-exclude_5830.ico");
        imageList_icon.Images.SetKeyName(185, "SoftwareDefinitionModel_11321.ico");
        imageList_icon.Images.SetKeyName(186, "Soundfile_461.ico");
        imageList_icon.Images.SetKeyName(187, "SQLServer_5728.ico");
        imageList_icon.Images.SetKeyName(188, "Strings_7959.ico");
        imageList_icon.Images.SetKeyName(189, "StyleSheet(css)_7483.ico");
        imageList_icon.Images.SetKeyName(190, "Table_748.ico");
        imageList_icon.Images.SetKeyName(191, "tapedrive.ico");
        imageList_icon.Images.SetKeyName(192, "TeamProjectCollection_12999.ico");
        imageList_icon.Images.SetKeyName(193, "TestsNotinaList_8548.ico");
        imageList_icon.Images.SetKeyName(194, "TFSServer_13310.ico");
        imageList_icon.Images.SetKeyName(195, "ToggleOfficeKeyboardScheme_7508.ico");
        imageList_icon.Images.SetKeyName(196, "ToolBarControl_710.ico");
        imageList_icon.Images.SetKeyName(197, "Type_527.ico");
        imageList_icon.Images.SetKeyName(198, "TypeDefinition_521.ico");
        imageList_icon.Images.SetKeyName(199, "UMLModelFile_13454.ico");
        imageList_icon.Images.SetKeyName(200, "uninterruptablepowersupply.ico");
        imageList_icon.Images.SetKeyName(201, "Union_534.ico");
        imageList_icon.Images.SetKeyName(202, "UniqueKey_8270.ico");
        imageList_icon.Images.SetKeyName(203, "usbcontroller.ico");
        imageList_icon.Images.SetKeyName(204, "UseCaseDiagramFile_usecasediagram_13447.ico");
        imageList_icon.Images.SetKeyName(205, "UserDefinedDataType_8271.ico");
        imageList_icon.Images.SetKeyName(206, "UserInterfaceEditor_5845.ico");
        imageList_icon.Images.SetKeyName(207, "videocontroller.ico");
        imageList_icon.Images.SetKeyName(208, "View_8933.ico");
        imageList_icon.Images.SetKeyName(209, "VirtualMachine.ico");
        imageList_icon.Images.SetKeyName(210, "VirtualMachines.ico");
        imageList_icon.Images.SetKeyName(211, "VSNETWebServiceDynamicDiscovery_8215.ico");
        imageList_icon.Images.SetKeyName(212, "Warning_grey_7315_16x16.ico");
        imageList_icon.Images.SetKeyName(213, "Warning_yellow_7231.ico");
        imageList_icon.Images.SetKeyName(214, "Warning_yellow_7231_16x16_cyan.ico");
        imageList_icon.Images.SetKeyName(215, "Warning_yellow_7231_31x32.ico");
        imageList_icon.Images.SetKeyName(216, "warning_yellow_7231_31x32_cyan.ico");
        imageList_icon.Images.SetKeyName(217, "WCFDataServices.ico");
        imageList_icon.Images.SetKeyName(218, "WebCustomControl(ASCX)_816.ico");
        imageList_icon.Images.SetKeyName(219, "WebForm(ASPX)_815.ico");
        imageList_icon.Images.SetKeyName(220, "WebForm(ASPX)_815_color.ico");
        imageList_icon.Images.SetKeyName(221, "WebFormTemplate_11274.ico");
        imageList_icon.Images.SetKeyName(222, "WebUserControl(ascx)_11270.ico");
        imageList_icon.Images.SetKeyName(223, "WindowsForm_817.ico");
        imageList_icon.Images.SetKeyName(224, "WindowsGroups_7309.ico");
        imageList_icon.Images.SetKeyName(225, "wmi_task.ico");
        imageList_icon.Images.SetKeyName(226, "XMLFile_828.ico");
        imageList_icon.Images.SetKeyName(227, "XMLSchema_798.ico");
        imageList_icon.Images.SetKeyName(228, "XSLTTransformfile_829.ico");
        // 
        // imageList_winIcon
        // 
        imageList_winIcon.ColorDepth = ColorDepth.Depth32Bit;
        imageList_winIcon.ImageStream = (ImageListStreamer)resources.GetObject("imageList_winIcon.ImageStream");
        imageList_winIcon.TransparentColor = Color.Transparent;
        imageList_winIcon.Images.SetKeyName(0, "app.ico");
        imageList_winIcon.Images.SetKeyName(1, "blankcd.ico");
        imageList_winIcon.Images.SetKeyName(2, "cab.ico");
        imageList_winIcon.Images.SetKeyName(3, "camera.ico");
        imageList_winIcon.Images.SetKeyName(4, "cdmusic.ico");
        imageList_winIcon.Images.SetKeyName(5, "cellphone.ico");
        imageList_winIcon.Images.SetKeyName(6, "CONTACTS.ICO");
        imageList_winIcon.Images.SetKeyName(7, "document.ico");
        imageList_winIcon.Images.SetKeyName(8, "fax.ico");
        imageList_winIcon.Images.SetKeyName(9, "folderopen.ico");
        imageList_winIcon.Images.SetKeyName(10, "fonfile.ico");
        imageList_winIcon.Images.SetKeyName(11, "fonfont.ico");
        imageList_winIcon.Images.SetKeyName(12, "GenericMusicDoc.ico");
        imageList_winIcon.Images.SetKeyName(13, "GenericPicDoc.ico");
        imageList_winIcon.Images.SetKeyName(14, "GenMixedMediaDoc.ico");
        imageList_winIcon.Images.SetKeyName(15, "GenVideoDoc.ico");
        imageList_winIcon.Images.SetKeyName(16, "globe.ico");
        imageList_winIcon.Images.SetKeyName(17, "group.ico");
        imageList_winIcon.Images.SetKeyName(18, "help.ico");
        imageList_winIcon.Images.SetKeyName(19, "helpdoc.ico");
        imageList_winIcon.Images.SetKeyName(20, "homenet.ico");
        imageList_winIcon.Images.SetKeyName(21, "hotplug.ico");
        imageList_winIcon.Images.SetKeyName(22, "ICS client.ico");
        imageList_winIcon.Images.SetKeyName(23, "ICS host.ico");
        imageList_winIcon.Images.SetKeyName(24, "idr_dll.ico");
        imageList_winIcon.Images.SetKeyName(25, "internetconnection.ico");
        imageList_winIcon.Images.SetKeyName(26, "IPML.ICO");
        imageList_winIcon.Images.SetKeyName(27, "keys.ico");
        imageList_winIcon.Images.SetKeyName(28, "lan disconnect.ico");
        imageList_winIcon.Images.SetKeyName(29, "mail.ico");
        imageList_winIcon.Images.SetKeyName(30, "mp3device.ico");
        imageList_winIcon.Images.SetKeyName(31, "netfol.ico");
        imageList_winIcon.Images.SetKeyName(32, "newfolder.ico");
        imageList_winIcon.Images.SetKeyName(33, "Note.ico");
        imageList_winIcon.Images.SetKeyName(34, "otheroptions.ico");
        imageList_winIcon.Images.SetKeyName(35, "pda.ico");
        imageList_winIcon.Images.SetKeyName(36, "printer.ico");
        imageList_winIcon.Images.SetKeyName(37, "propertiesORoptions.ico");
        imageList_winIcon.Images.SetKeyName(38, "rc_bitmap.ico");
        imageList_winIcon.Images.SetKeyName(39, "scanner.ico");
        imageList_winIcon.Images.SetKeyName(40, "security.ico");
        imageList_winIcon.Images.SetKeyName(41, "sharedocuments.ico");
        imageList_winIcon.Images.SetKeyName(42, "sound.ico");
        imageList_winIcon.Images.SetKeyName(43, "textdoc.ico");
        imageList_winIcon.Images.SetKeyName(44, "user.ico");
        imageList_winIcon.Images.SetKeyName(45, "users.ico");
        imageList_winIcon.Images.SetKeyName(46, "video.ico");
        // 
        // imageList_flag
        // 
        imageList_flag.ColorDepth = ColorDepth.Depth32Bit;
        imageList_flag.ImageStream = (ImageListStreamer)resources.GetObject("imageList_flag.ImageStream");
        imageList_flag.TransparentColor = Color.Transparent;
        imageList_flag.Images.SetKeyName(0, "뉴질랜드.png");
        imageList_flag.Images.SetKeyName(1, "대한민국.png");
        imageList_flag.Images.SetKeyName(2, "미국.png");
        imageList_flag.Images.SetKeyName(3, "브라질.png");
        imageList_flag.Images.SetKeyName(4, "스위스.png");
        imageList_flag.Images.SetKeyName(5, "이집트.png");
        imageList_flag.Images.SetKeyName(6, "캐나다.png");
        // 
        // radioButton_LargeIcon
        // 
        radioButton_LargeIcon.AutoSize = true;
        radioButton_LargeIcon.Location = new Point(0, 0);
        radioButton_LargeIcon.Name = "radioButton_LargeIcon";
        radioButton_LargeIcon.Size = new Size(130, 24);
        radioButton_LargeIcon.TabIndex = 0;
        radioButton_LargeIcon.TabStop = true;
        radioButton_LargeIcon.Text = "큰 아이콘 보기";
        radioButton_LargeIcon.UseVisualStyleBackColor = true;
        radioButton_LargeIcon.CheckedChanged += radioButton_view_CheckedChanged;
        // 
        // radioButton_SmallIcon
        // 
        radioButton_SmallIcon.AutoSize = true;
        radioButton_SmallIcon.Location = new Point(0, 30);
        radioButton_SmallIcon.Name = "radioButton_SmallIcon";
        radioButton_SmallIcon.Size = new Size(145, 24);
        radioButton_SmallIcon.TabIndex = 1;
        radioButton_SmallIcon.TabStop = true;
        radioButton_SmallIcon.Text = "작은 아이콘 보기";
        radioButton_SmallIcon.UseVisualStyleBackColor = true;
        radioButton_SmallIcon.CheckedChanged += radioButton_view_CheckedChanged;
        // 
        // radioButton_List
        // 
        radioButton_List.AutoSize = true;
        radioButton_List.Location = new Point(0, 60);
        radioButton_List.Name = "radioButton_List";
        radioButton_List.Size = new Size(90, 24);
        radioButton_List.TabIndex = 2;
        radioButton_List.TabStop = true;
        radioButton_List.Text = "목록보기";
        radioButton_List.UseVisualStyleBackColor = true;
        radioButton_List.CheckedChanged += radioButton_view_CheckedChanged;
        // 
        // radioButton_Tile
        // 
        radioButton_Tile.AutoSize = true;
        radioButton_Tile.Location = new Point(0, 90);
        radioButton_Tile.Name = "radioButton_Tile";
        radioButton_Tile.Size = new Size(95, 24);
        radioButton_Tile.TabIndex = 3;
        radioButton_Tile.TabStop = true;
        radioButton_Tile.Text = "타일 보기";
        radioButton_Tile.UseVisualStyleBackColor = true;
        radioButton_Tile.CheckedChanged += radioButton_view_CheckedChanged;
        // 
        // radioButton_Details
        // 
        radioButton_Details.AutoSize = true;
        radioButton_Details.Location = new Point(0, 120);
        radioButton_Details.Name = "radioButton_Details";
        radioButton_Details.Size = new Size(110, 24);
        radioButton_Details.TabIndex = 4;
        radioButton_Details.TabStop = true;
        radioButton_Details.Text = "자세히 보기";
        radioButton_Details.UseVisualStyleBackColor = true;
        radioButton_Details.CheckedChanged += radioButton_view_CheckedChanged;
        // 
        // listView1
        // 
        listView1.Columns.AddRange(new ColumnHeader[] { nation, capital, area, Population, Number });
        listView1.Items.AddRange(new ListViewItem[] { listViewItem6, listViewItem7, listViewItem8, listViewItem9, listViewItem10 });
        listView1.Location = new Point(151, 12);
        listView1.Name = "listView1";
        listView1.Size = new Size(479, 226);
        listView1.SmallImageList = imageList_flag;
        listView1.StateImageList = imageList_flag;
        listView1.TabIndex = 5;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = View.Details;
        listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        // 
        // nation
        // 
        nation.Text = "국가";
        nation.Width = 110;
        // 
        // capital
        // 
        capital.Text = "수도";
        capital.Width = 120;
        // 
        // area
        // 
        area.Text = "지역";
        area.Width = 100;
        // 
        // Population
        // 
        Population.Text = "인구";
        // 
        // Number
        // 
        Number.Text = "번호";
        // 
        // comboBox_view
        // 
        comboBox_view.FormattingEnabled = true;
        comboBox_view.Items.AddRange(new object[] { "LageIcon", "SmallIcon", "List", "Tile", "Details" });
        comboBox_view.Location = new Point(0, 168);
        comboBox_view.Name = "comboBox_view";
        comboBox_view.Size = new Size(151, 28);
        comboBox_view.TabIndex = 6;
        comboBox_view.SelectedIndexChanged += comboBox_view_SelectedIndexChanged;
        // 
        // label_nation
        // 
        label_nation.AutoSize = true;
        label_nation.Location = new Point(0, 218);
        label_nation.Name = "label_nation";
        label_nation.Size = new Size(119, 20);
        label_nation.TabIndex = 7;
        label_nation.Text = "선택한 국가이름";
        // 
        // treeView1
        // 
        treeView1.ImageIndex = 0;
        treeView1.ImageList = imageList_winIcon;
        treeView1.Location = new Point(636, 12);
        treeView1.Name = "treeView1";
        treeNode6.Name = "background";
        treeNode6.Text = "바탕화면";
        treeNode7.Name = "노드1";
        treeNode7.Text = "다운로드";
        treeNode8.Name = "노드2";
        treeNode8.Text = "C:\\";
        treeNode9.Name = "노드3";
        treeNode9.Text = "D:\\";
        treeNode10.ImageIndex = 22;
        treeNode10.Name = "root";
        treeNode10.SelectedImageIndex = 23;
        treeNode10.Text = "내 컴퓨터";
        treeView1.Nodes.AddRange(new TreeNode[] { treeNode10 });
        treeView1.SelectedImageIndex = 0;
        treeView1.Size = new Size(265, 226);
        treeView1.TabIndex = 8;
        // 
        // textBox_tree
        // 
        textBox_tree.Location = new Point(912, 17);
        textBox_tree.Name = "textBox_tree";
        textBox_tree.Size = new Size(125, 27);
        textBox_tree.TabIndex = 9;
        // 
        // button_insert
        // 
        button_insert.Location = new Point(920, 50);
        button_insert.Name = "button_insert";
        button_insert.Size = new Size(94, 29);
        button_insert.TabIndex = 10;
        button_insert.Text = "노드 삽입";
        button_insert.UseVisualStyleBackColor = true;
        button_insert.Click += button_insert_Click;
        // 
        // button_delete
        // 
        button_delete.Location = new Point(920, 85);
        button_delete.Name = "button_delete";
        button_delete.Size = new Size(94, 29);
        button_delete.TabIndex = 11;
        button_delete.Text = "노드 삭제";
        button_delete.UseVisualStyleBackColor = true;
        button_delete.Click += button_delete_Click;
        // 
        // domainUpDown_class
        // 
        domainUpDown_class.Items.Add("논리회로");
        domainUpDown_class.Items.Add("컴퓨터구조");
        domainUpDown_class.Items.Add("알고리즘");
        domainUpDown_class.Items.Add("개빡샌교양");
        domainUpDown_class.Items.Add("쉽고널널한교양");
        domainUpDown_class.Items.Add("필수교양");
        domainUpDown_class.Items.Add("필수전공");
        domainUpDown_class.Items.Add("개빡샌전공");
        domainUpDown_class.Items.Add("존내쉬운전공");
        domainUpDown_class.Items.Add("족보있는전공");
        domainUpDown_class.Location = new Point(1056, 18);
        domainUpDown_class.Name = "domainUpDown_class";
        domainUpDown_class.Size = new Size(199, 27);
        domainUpDown_class.TabIndex = 12;
        domainUpDown_class.Text = "교과목 목록";
        domainUpDown_class.Wrap = true;
        // 
        // button_insert_class_in_treeView
        // 
        button_insert_class_in_treeView.Location = new Point(1056, 50);
        button_insert_class_in_treeView.Name = "button_insert_class_in_treeView";
        button_insert_class_in_treeView.Size = new Size(138, 29);
        button_insert_class_in_treeView.TabIndex = 13;
        button_insert_class_in_treeView.Text = "교과목 삽입";
        button_insert_class_in_treeView.UseVisualStyleBackColor = true;
        button_insert_class_in_treeView.Click += button_insert_class_in_treeView_Click;
        // 
        // numericUpDown_Calculator
        // 
        numericUpDown_Calculator.Location = new Point(3, 20);
        numericUpDown_Calculator.Name = "numericUpDown_Calculator";
        numericUpDown_Calculator.Size = new Size(244, 27);
        numericUpDown_Calculator.TabIndex = 14;
        numericUpDown_Calculator.TextAlign = HorizontalAlignment.Right;
        numericUpDown_Calculator.ValueChanged += numericUpDown_Calculator_ValueChanged;
        // 
        // panel_calculator
        // 
        panel_calculator.BackColor = SystemColors.ActiveBorder;
        panel_calculator.Controls.Add(trackBar_calculator);
        panel_calculator.Controls.Add(C_result_SQRT);
        panel_calculator.Controls.Add(label3);
        panel_calculator.Controls.Add(C_result_SQR);
        panel_calculator.Controls.Add(label2);
        panel_calculator.Controls.Add(C_result_log);
        panel_calculator.Controls.Add(label1);
        panel_calculator.Controls.Add(numericUpDown_Calculator);
        panel_calculator.Location = new Point(12, 244);
        panel_calculator.Name = "panel_calculator";
        panel_calculator.Size = new Size(315, 246);
        panel_calculator.TabIndex = 15;
        // 
        // trackBar_calculator
        // 
        trackBar_calculator.BackColor = SystemColors.ActiveBorder;
        trackBar_calculator.LargeChange = 10;
        trackBar_calculator.Location = new Point(253, 3);
        trackBar_calculator.Maximum = 100;
        trackBar_calculator.Name = "trackBar_calculator";
        trackBar_calculator.Orientation = Orientation.Vertical;
        trackBar_calculator.Size = new Size(56, 240);
        trackBar_calculator.TabIndex = 16;
        trackBar_calculator.TickFrequency = 10;
        trackBar_calculator.Scroll += trackBar_calculator_Scroll;
        // 
        // C_result_SQRT
        // 
        C_result_SQRT.Location = new Point(70, 149);
        C_result_SQRT.Name = "C_result_SQRT";
        C_result_SQRT.Size = new Size(177, 27);
        C_result_SQRT.TabIndex = 20;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(5, 152);
        label3.Name = "label3";
        label3.Size = new Size(62, 20);
        label3.TabIndex = 19;
        label3.Text = "SQRT =";
        label3.TextAlign = ContentAlignment.MiddleRight;
        // 
        // C_result_SQR
        // 
        C_result_SQR.Location = new Point(70, 109);
        C_result_SQR.Name = "C_result_SQR";
        C_result_SQR.Size = new Size(177, 27);
        C_result_SQR.TabIndex = 18;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(14, 112);
        label2.Name = "label2";
        label2.Size = new Size(54, 20);
        label2.TabIndex = 17;
        label2.Text = "SQR =";
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // C_result_log
        // 
        C_result_log.Location = new Point(70, 67);
        C_result_log.Name = "C_result_log";
        C_result_log.Size = new Size(177, 27);
        C_result_log.TabIndex = 16;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(5, 70);
        label1.Name = "label1";
        label1.Size = new Size(63, 20);
        label1.TabIndex = 15;
        label1.Text = "log10 =";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // timer_frame
        // 
        timer_frame.Enabled = true;
        timer_frame.Interval = 250;
        timer_frame.Tick += timer_frame_Tick;
        // 
        // label_weightlifting
        // 
        label_weightlifting.AutoSize = true;
        label_weightlifting.BorderStyle = BorderStyle.FixedSingle;
        label_weightlifting.Font = new Font("맑은 고딕", 80F);
        label_weightlifting.Location = new Point(333, 247);
        label_weightlifting.Name = "label_weightlifting";
        label_weightlifting.Size = new Size(171, 179);
        label_weightlifting.TabIndex = 17;
        label_weightlifting.Text = "  ";
        // 
        // imageList_weightlifting
        // 
        imageList_weightlifting.ColorDepth = ColorDepth.Depth32Bit;
        imageList_weightlifting.ImageStream = (ImageListStreamer)resources.GetObject("imageList_weightlifting.ImageStream");
        imageList_weightlifting.TransparentColor = Color.Transparent;
        imageList_weightlifting.Images.SetKeyName(0, "역도1.png");
        imageList_weightlifting.Images.SetKeyName(1, "역도2.png");
        imageList_weightlifting.Images.SetKeyName(2, "역도3.png");
        imageList_weightlifting.Images.SetKeyName(3, "역도4.png");
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageSize = new Size(16, 16);
        imageList1.TransparentColor = Color.Transparent;
        // 
        // label_golf
        // 
        label_golf.AutoSize = true;
        label_golf.BorderStyle = BorderStyle.FixedSingle;
        label_golf.Font = new Font("맑은 고딕", 80F);
        label_golf.Location = new Point(510, 247);
        label_golf.Name = "label_golf";
        label_golf.Size = new Size(171, 179);
        label_golf.TabIndex = 18;
        label_golf.Text = "  ";
        // 
        // imageList_golf
        // 
        imageList_golf.ColorDepth = ColorDepth.Depth32Bit;
        imageList_golf.ImageStream = (ImageListStreamer)resources.GetObject("imageList_golf.ImageStream");
        imageList_golf.TransparentColor = Color.Transparent;
        imageList_golf.Images.SetKeyName(0, "����1.png");
        imageList_golf.Images.SetKeyName(1, "����2.png");
        imageList_golf.Images.SetKeyName(2, "����3.png");
        imageList_golf.Images.SetKeyName(3, "����4.png");
        imageList_golf.Images.SetKeyName(4, "����5.png");
        imageList_golf.Images.SetKeyName(5, "����6.png");
        imageList_golf.Images.SetKeyName(6, "����7.png");
        imageList_golf.Images.SetKeyName(7, "����8.png");
        imageList_golf.Images.SetKeyName(8, "����9.png");
        imageList_golf.Images.SetKeyName(9, "����10.png");
        imageList_golf.Images.SetKeyName(10, "����11.png");
        imageList_golf.Images.SetKeyName(11, "����12.png");
        imageList_golf.Images.SetKeyName(12, "����13.png");
        imageList_golf.Images.SetKeyName(13, "����14.png");
        imageList_golf.Images.SetKeyName(14, "����15.png");
        // 
        // imageList_tenis
        // 
        imageList_tenis.ColorDepth = ColorDepth.Depth32Bit;
        imageList_tenis.ImageStream = (ImageListStreamer)resources.GetObject("imageList_tenis.ImageStream");
        imageList_tenis.TransparentColor = Color.Transparent;
        imageList_tenis.Images.SetKeyName(0, "�״Ͻ�1.png");
        imageList_tenis.Images.SetKeyName(1, "�״Ͻ�2.png");
        imageList_tenis.Images.SetKeyName(2, "�״Ͻ�3.png");
        imageList_tenis.Images.SetKeyName(3, "�״Ͻ�4.png");
        imageList_tenis.Images.SetKeyName(4, "�״Ͻ�5.png");
        imageList_tenis.Images.SetKeyName(5, "�״Ͻ�6.png");
        imageList_tenis.Images.SetKeyName(6, "�״Ͻ�7.png");
        imageList_tenis.Images.SetKeyName(7, "�״Ͻ�8.png");
        imageList_tenis.Images.SetKeyName(8, "�״Ͻ�9.png");
        imageList_tenis.Images.SetKeyName(9, "�״Ͻ�10.png");
        imageList_tenis.Images.SetKeyName(10, "�״Ͻ�11.png");
        imageList_tenis.Images.SetKeyName(11, "�״Ͻ�12.png");
        imageList_tenis.Images.SetKeyName(12, "�״Ͻ�13.png");
        imageList_tenis.Images.SetKeyName(13, "�״Ͻ�14.png");
        imageList_tenis.Images.SetKeyName(14, "�״Ͻ�15.png");
        imageList_tenis.Images.SetKeyName(15, "�״Ͻ�16.png");
        imageList_tenis.Images.SetKeyName(16, "�״Ͻ�17.png");
        imageList_tenis.Images.SetKeyName(17, "�״Ͻ�18.png");
        imageList_tenis.Images.SetKeyName(18, "�״Ͻ�19.png");
        imageList_tenis.Images.SetKeyName(19, "�״Ͻ�20.png");
        // 
        // label_tenis
        // 
        label_tenis.AutoSize = true;
        label_tenis.BorderStyle = BorderStyle.FixedSingle;
        label_tenis.Font = new Font("맑은 고딕", 80F);
        label_tenis.Location = new Point(687, 247);
        label_tenis.Name = "label_tenis";
        label_tenis.Size = new Size(171, 179);
        label_tenis.TabIndex = 19;
        label_tenis.Text = "  ";
        // 
        // _11_Form
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1321, 502);
        Controls.Add(label_tenis);
        Controls.Add(label_golf);
        Controls.Add(label_weightlifting);
        Controls.Add(panel_calculator);
        Controls.Add(button_insert_class_in_treeView);
        Controls.Add(domainUpDown_class);
        Controls.Add(button_delete);
        Controls.Add(button_insert);
        Controls.Add(textBox_tree);
        Controls.Add(treeView1);
        Controls.Add(label_nation);
        Controls.Add(comboBox_view);
        Controls.Add(listView1);
        Controls.Add(radioButton_Details);
        Controls.Add(radioButton_Tile);
        Controls.Add(radioButton_List);
        Controls.Add(radioButton_SmallIcon);
        Controls.Add(radioButton_LargeIcon);
        Name = "_11_Form";
        Text = "_11_Form";
        ((System.ComponentModel.ISupportInitialize)numericUpDown_Calculator).EndInit();
        panel_calculator.ResumeLayout(false);
        panel_calculator.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)trackBar_calculator).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ImageList imageList_icon;
    private ImageList imageList_winIcon;
    private ImageList imageList_flag;
    private RadioButton radioButton_LargeIcon;
    private RadioButton radioButton_SmallIcon;
    private RadioButton radioButton_List;
    private RadioButton radioButton_Tile;
    private RadioButton radioButton_Details;
    private ListView listView1;
    private ColumnHeader nation;
    private ColumnHeader capital;
    private ColumnHeader area;
    private ColumnHeader Population;
    private ColumnHeader Number;
    private ComboBox comboBox_view;
    private Label label_nation;
    private TreeView treeView1;
    private TextBox textBox_tree;
    private Button button_insert;
    private Button button_delete;
    private DomainUpDown domainUpDown_class;
    private Button button_insert_class_in_treeView;
    private NumericUpDown numericUpDown_Calculator;
    private Panel panel_calculator;
    private TextBox C_result_SQRT;
    private Label label3;
    private TextBox C_result_SQR;
    private Label label2;
    private TextBox C_result_log;
    private Label label1;
    private TrackBar trackBar_calculator;
    private System.Windows.Forms.Timer timer_frame;
    private Label label_weightlifting;
    private ImageList imageList_weightlifting;
    private ImageList imageList1;
    private Label label_golf;
    private ImageList imageList_golf;
    private ImageList imageList_tenis;
    private Label label_tenis;
}