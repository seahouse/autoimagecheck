using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using LJV7_DllSampleAll;
using LJV7_DllSampleAll.Datas;
using LJV7_DllSampleAll.Forms;
using WindowsFormsApplication1.Properties;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    #region Enum

    /// <summary>
    /// Send command definition
    /// </summary>
    /// <remark>Defined for separate return code distinction</remark>
    public enum SendCommand
    {
      /// <summary>None</summary>
      None,
      /// <summary>Restart</summary>
      RebootController,
      /// <summary>Trigger</summary>
      Trigger,
      /// <summary>Start measurement</summary>
      StartMeasure,
      /// <summary>Stop measurement</summary>
      StopMeasure,
      /// <summary>Auto zero</summary>
      AutoZero,
      /// <summary>Timing</summary>
      Timing,
      /// <summary>Reset</summary>
      Reset,
      /// <summary>Program switch</summary>
      ChangeActiveProgram,
      /// <summary>Get measurement results</summary>
      GetMeasurementValue,

      /// <summary>Get profiles</summary>
      GetProfile,
      /// <summary>Get batch profiles (operation mode "high-speed (profile only)")</summary>
      GetBatchProfile,
      /// <summary>Get profiles (operation mode "advanced (with OUT measurement)")</summary>
      GetProfileAdvance,
      /// <summary>Get batch profiles (operation mode "advanced (with OUT measurement)").</summary>
      GetBatchProfileAdvance,

      /// <summary>Start storage</summary>
      StartStorage,
      /// <summary>Stop storage</summary>
      StopStorage,
      /// <summary>Get storage status</summary>
      GetStorageStatus,
      /// <summary>Manual storage request</summary>
      RequestStorage,
      /// <summary>Get storage data</summary>
      GetStorageData,
      /// <summary>Get profile storage data</summary>
      GetStorageProfile,
      /// <summary>Get batch profile storage data.</summary>
      GetStorageBatchProfile,

      /// <summary>Initialize USB high-speed data communication</summary>
      HighSpeedDataUsbCommunicationInitalize,
      /// <summary>Initialize Ethernet high-speed data communication</summary>
      HighSpeedDataEthernetCommunicationInitalize,
      /// <summary>Request preparation before starting high-speed data communication</summary>
      PreStartHighSpeedDataCommunication,
      /// <summary>Start high-speed data communication</summary>
      StartHighSpeedDataCommunication,
    }

    #endregion

    #region Field

    /// <summary>Ethernet settings structure </summary>
    private LJV7IF_ETHERNET_CONFIG _ethernetConfig;
    /// <summary>Measurement data list</summary>
    private List<MeasureData> _measureDatas;
    /// <summary>Current device ID</summary>
    private int _currentDeviceId;
    /// <summary>Send command</summary>
    private SendCommand _sendCommand;
    /// <summary>Callback function used during high-speed communication</summary>
    private HighSpeedDataCallBack _callback;
    /// <summary>Callback function used during high-speed communication (count only)</summary>
    private HighSpeedDataCallBack _callbackOnlyCount;

    /// The following are maintained in arrays to support multiple controllers.
    /// <summary>Array of profile information structures</summary>
    private LJV7IF_PROFILE_INFO[] _profileInfo;
    /// <summary>Array of controller information</summary>
    private DeviceData[] _deviceData;
    /// <summary>Array of labels that indicate the controller status</summary>
    private Label[] _deviceStatusLabels;
    /// <summary>Array of labels that indicate the number of received profiles </summary>
    private Label[] _receivedProfileCountLabels;

    private static int www = 0;
    public static Form1 form1;
    #endregion

    public Form1()
    {
      InitializeComponent();

      // Field initialization
      _sendCommand = SendCommand.None;
      _deviceData = new DeviceData[NativeMethods.DeviceCount];
      _callback = new HighSpeedDataCallBack(ReceiveHighSpeedData);
      _deviceStatusLabels = new Label[] {
        _lblDeviceStatus0, _lblDeviceStatus1, _lblDeviceStatus2,
        _lblDeviceStatus3, _lblDeviceStatus4, _lblDeviceStatus5};

      _receivedProfileCountLabels = new Label[] {
        _lblReceiveProfileCount0, _lblReceiveProfileCount1, _lblReceiveProfileCount2,
        _lblReceiveProfileCount3, _lblReceiveProfileCount4, _lblReceiveProfileCount5};

      for (int i = 0; i < NativeMethods.DeviceCount; i++)
      {
        _deviceData[i] = new DeviceData();
        _deviceStatusLabels[i].Text = _deviceData[i].GetStatusString();
      }
      _profileInfo = new LJV7IF_PROFILE_INFO[NativeMethods.DeviceCount];

      // Communication button comment setting
      SetCommandBtnString();

      // Control initialization
      _cmbMeasureX.DataSource = GetMeasureRangeList();
      _cmbReceivedBinning.DataSource = GetReceivedBiginning();
      _cmbCompressX.DataSource = GetCompressX();

      _cmbMeasureX.SelectedValue = Define.MEASURE_RANGE_FULL;
      _cmbReceivedBinning.SelectedValue = Define.RECEIVED_BINNING_OFF;
      _cmbCompressX.SelectedValue = Define.COMPRESS_X_OFF;

      form1 = this;
    }

    /// <summary>
    /// Get the measurement range.
    /// </summary>
    /// <returns>List used as the combo box data source</returns>
    private List<DictionaryEntry> GetMeasureRangeList()
    {
      List<DictionaryEntry> list = new List<DictionaryEntry>();
      list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_FULL, Define.MEASURE_RANGE_FULL));
      list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_MIDDLE, Define.MEASURE_RANGE_MIDDLE));
      list.Add(new DictionaryEntry(Resources.SID_MEASURE_RANGE_SMALL, Define.MEASURE_RANGE_SMALL));
      return list;
    }

    /// <summary>
    /// Get the light reception characteristic binning list.
    /// </summary>
    /// <returns>List used as the combo box data source</returns>
    private List<DictionaryEntry> GetReceivedBiginning()
    {
      List<DictionaryEntry> list = new List<DictionaryEntry>();
      list.Add(new DictionaryEntry(Resources.SID_RECEIVED_BINNING_OFF, Define.RECEIVED_BINNING_OFF));
      list.Add(new DictionaryEntry(Resources.SID_RECEIVED_BINNING_ON, Define.RECEIVED_BINNING_ON));
      return list;
    }

    /// <summary>
    /// Get the light reception characteristic binning list.
    /// </summary>
    /// <returns>List used as the combo box data source</returns>
    private List<DictionaryEntry> GetCompressX()
    {
      List<DictionaryEntry> list = new List<DictionaryEntry>();
      list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_OFF, Define.COMPRESS_X_OFF));
      list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_2, Define.COMPRESS_X_2));
      list.Add(new DictionaryEntry(Resources.SID_COMPRESS_X_4, Define.COMPRESS_X_4));
      return list;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        List<int> listX = new List<int>();
        listX.Add(3);
        listX.Add(4);
        listX.Add(5);
        listX.Add(7);
        listX.Add(6);
        listX.Add(4);
        List<int> listY = new List<int>();
        listY.Add(3);
        listY.Add(4);
        listY.Add(5);
        listY.Add(7);
        listY.Add(6);
        listY.Add(4);
        //X、Y值成员
        chart.Series[0].Points.DataBindXY(listX, listY);
        chart.Series[0].Points.DataBindY(listY);

        //点颜色
        chart.Series[0].MarkerColor = Color.Green;
        //图表类型  设置为样条图曲线
        chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        //设置点的大小
        chart.Series[0].MarkerSize = 5;
        //设置曲线的颜色
        chart.Series[0].Color = Color.Orange;
        //设置曲线宽度
        chart.Series[0].BorderWidth = 2;
        //chart.Series[0].CustomProperties = "PointWidth=4";
        //设置是否显示坐标标注
        chart.Series[0].IsValueShownAsLabel = false;

        //设置游标
        chart.ChartAreas[0].CursorX.IsUserEnabled = true;
        chart.ChartAreas[0].CursorX.AutoScroll = true;
        chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        //设置X轴是否可以缩放
        chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
        //将滚动条放到图表外
        chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
        // 设置滚动条的大小
        chart.ChartAreas[0].AxisX.ScrollBar.Size = 15;
        // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
        chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.All;
        chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.SkyBlue;
        // 设置自动放大与缩小的最小量
        chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
        chart.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
        //设置刻度间隔
        //chart.ChartAreas[0].AxisX.Interval = 10;
        //将X轴上格网取消
        chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //X轴、Y轴标题
        chart.ChartAreas[0].AxisX.Title = "环号";
        chart.ChartAreas[0].AxisY.Title = "直径";
        chart.ChartAreas[0].AxisX.Minimum = -3.0;
        chart.ChartAreas[0].AxisX.Maximum = 3.0;
        ////设置Y轴范围  可以根据实际情况重新修改
        //double max = listY[0];
        //double min = listY[0];
        //foreach (var yValue in listY)
        //{
        //  if (max < yValue)
        //  {
        //    max = yValue;
        //  }
        //  if (min > yValue)
        //  {
        //    min = yValue;
        //  }
        //}
        //chart.ChartAreas[0].AxisY.Maximum = max;
        //chart.ChartAreas[0].AxisY.Minimum = min;
        //chart.ChartAreas[0].AxisY.Interval = (max - min) / 10;
        //绑定数据源
        chart.DataBind();

        //timer.Start();
      }
      catch (Exception exc)
      {
        MessageBox.Show(exc.ToString());
      }

    }

    private void timer_Tick(object sender, EventArgs e)
    {
      List<int> listX = new List<int>();
      Random r = new Random();
      for (int i = 0; i < 10; i++)
      {
        int num = r.Next(10, 20);
        listX.Add(num);
      }
      List<int> listY = new List<int>();
      for (int i = 0; i < 10; i++)
      {
        int num = r.Next(0, 10);
        listY.Add(num);
      }
      chart.Series[0].Points.DataBindXY(listX, listY);
      chart.Series[0].Points.DataBindY(listY);
      //chart.DataBind();
    }

    private void btnLoadTxtData_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("data.txt", Encoding.Default);
      String line;
      int i = 0;
      List<int> listX = new List<int>();
      List<double> listY = new List<double>();
      while ((line = sr.ReadLine()) != null)
      {
        listX.Add(i);
        i++;
        listY.Add(double.Parse(line.ToString()));
        //Console.WriteLine(line.ToString());
      }
      chart.Series[0].Points.DataBindXY(listX, listY);
      chart.Series[0].Points.DataBindY(listY);
    }

    private void _btnUsbOpen_Click(object sender, EventArgs e)
    {
      int rc = NativeMethods.LJV7IF_UsbOpen(_currentDeviceId);
      // @Point
      // # Enter the "_currentDeviceId" set here for the communication settings into the arguments of each DLL function.
      // # If you want to get data from multiple controllers, prepare and set multiple "_currentDeviceId" values,
      //   enter these values into the arguments of the DLL functions, and then use the functions.

      //AddLogResult(rc, Resources.SID_USB_OPEN);
      AddLogResult(rc, "UsbOpen");

      _deviceData[_currentDeviceId].Status = (rc == (int)Rc.Ok) ? DeviceStatus.Usb : DeviceStatus.NoConnection;
      _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
    }

    /// <summary>
    /// Communication button string setting
    /// </summary>
    private void SetCommandBtnString()
    {
      // Set the communication button comment here to match it with the log output string.
      _btnUsbOpen.Text = Resources.SID_USB_OPEN;
      //_btnGetTime.Text = Resources.SID_GET_TIME;
      //_btnGetVersion.Text = Resources.SID_GET_VERSION;
      //_btnFinalize.Text = Resources.SID_FINALIZE;
      //_btnInitialize.Text = Resources.SID_INITIALIZE;
      //_btnCommClose.Text = Resources.SID_COMM_CLOSE;
      //_btnEthernetOpen.Text = Resources.SID_ETHERNET_OPEN;
      //_btnGetActiveProgram.Text = Resources.SID_GET_ACTIVE_PROGRAM;
      //_btnHighSpeedDataCommunicationFinalize.Text = Resources.SID_HIGH_SPEED_DATA_COMMUNICATION_FINALIZE;
      //_btnStopHighSpeedDataCommunication.Text = Resources.SID_STOP_HIGH_SPEED_DATA_COMMUNICATION;
      //_btnStartHighSpeedDataCommunication.Text = Resources.SID_START_HIGH_SPEED_DATA_COMMUNICATION;
      //_btnPreStartHighSpeedDataCommunication.Text = Resources.SID_PRE_START_HIGH_SPEED_DATA_COMMUNICATION;
      //_btnHighSpeedDataUsbCommunicationInitalize.Text = Resources.SID_HIGH_SPEED_DATA_USB_COMMUNICATION_INITALIZE;
      //_btnHighSpeedDataEthernetCommunicationInitalize.Text = Resources.SID_HIGH_SPEED_DATA_ETHERNET_COMMUNICATION_INITALIZE;
      //_btnRewriteTemporarySetting.Text = Resources.SID_REWRITE_TEMPORARY_SETTING;
      //_btnGetStorageBatchProfile.Text = Resources.SID_GET_STORAGE_BATCH_PROFILE;
      //_btnGetStorageProfile.Text = Resources.SID_GET_STORAGE_PROFILE;
      //_btnGetStorageData.Text = Resources.SID_GET_STORAGE_DATA;
      //_btnGetStorageStatus.Text = Resources.SID_GET_STORAGE_STATUS;
      //_btnStopStorage.Text = Resources.SID_STOP_STORAGE;
      //_btnStartStorage.Text = Resources.SID_START_STORAGE;
      //_btnGetBatchProfileAdvance.Text = Resources.SID_GET_BATCH_PROFILE_ADVANCE;
      //_btnGetProfileAdvance.Text = Resources.SID_GET_PROFILE_ADVANCE;
      //_btnGetBatchProfile.Text = Resources.SID_GET_BATCH_PROFILE;
      //_btnGetProfile.Text = Resources.SID_GET_PROFILE;
      //_btnGetMeasurementValue.Text = Resources.SID_GET_MEASUREMENT_VALUE;
      //_btnChangeActiveProgram.Text = Resources.SID_CHANGE_ACTIVE_PROGRAM;
      //_btnSetTime.Text = Resources.SID_SET_TIME;
      //_btnUpdataSetting.Text = Resources.SID_UPDATA_SETTING;
      //_btnCheckMemoryAccess.Text = Resources.SID_CHECK_MEMORY_ACCESS;
      //_btnSetSetting.Text = Resources.SID_SET_SETTING;
      //_btnGetSetting.Text = Resources.SID_GET_SETTING;
      //_btnClearMemory.Text = Resources.SID_CLEAR_MEMORY;
      //_btnReset.Text = Resources.SID_RESET;
      //_btnTiming.Text = Resources.SID_TIMING;
      //_btnAutoZero.Text = Resources.SID_AUTO_ZERO;
      //_btnStopMeasure.Text = Resources.SID_STOP_MEASURE;
      //_btnStartMeasure.Text = Resources.SID_START_MEASURE;
      //_btnTrigger.Text = Resources.SID_TRIGGER;
      //_btnClearError.Text = Resources.SID_CLEAR_ERROR;
      //_btnGetError.Text = Resources.SID_GET_ERROR;
      //_btnRetrunToFactorySetting.Text = Resources.SID_RETRUN_TO_FACTORY_SETTING;
      //_btnRebootController.Text = Resources.SID_REBOOT_CONTROLLER;
    }

    #region Log output

    /// <summary>
    /// Log output
    /// </summary>
    /// <param name="strLog">Output log</param>
    private void AddLog(string strLog)
    {
      _txtboxLog.AppendText(strLog + Environment.NewLine);
      _txtboxLog.SelectionStart = _txtboxLog.Text.Length;
      _txtboxLog.Focus();
      _txtboxLog.ScrollToCaret();
    }

    /// <summary>
    /// Communication command result log output
    /// </summary>
    /// <param name="rc">Return code from the DLL</param>
    /// <param name="commandName">Command name to be output in the log</param>
    private void AddLogResult(int rc, string commandName)
    {
      if (rc == (int)Rc.Ok)
      {
        AddLog(string.Format(Resources.SID_LOG_FORMAT, commandName, Resources.SID_RESULT_OK, rc));
      }
      else
      {
        //AddLog(string.Format(Resources.SID_LOG_FORMAT, commandName, Resources.SID_RESULT_NG, rc));
        AddLog(string.Format(Resources.SID_LOG_FORMAT, commandName, "NG", rc));
        AddErrorLog(rc);
      }
    }

    /// <summary>
    /// Error log output
    /// </summary>
    /// <param name="rc">Return code</param>
    private void AddErrorLog(int rc)
    {
      if (rc < 0x8000)
      {
        // Common return code
        CommonErrorLog(rc);
      }
      else
      {
        // Individual return code
        IndividualErrorLog(rc);
      }
    }

    /// <summary>
    /// Add Error
    /// </summary>
    /// <param name="dwError"></param>
    private void AddError(uint dwError)
    {
      _txtboxLog.AppendText("  ErrorCode : 0x" + dwError.ToString("x8") + Environment.NewLine);
      _txtboxLog.SelectionStart = _txtboxLog.Text.Length;
      _txtboxLog.Focus();
      _txtboxLog.ScrollToCaret();
    }

    /// <summary>
    /// Common return code log output
    /// </summary>
    /// <param name="rc">Return code</param>
    private void CommonErrorLog(int rc)
    {
      switch (rc)
      {
        case (int)Rc.Ok:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_OK));
          break;
        case (int)Rc.ErrOpenDevice:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_OPEN_DEVICE));
          break;
        case (int)Rc.ErrNoDevice:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_NO_DEVICE));
          break;
        case (int)Rc.ErrSend:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_SEND));
          break;
        case (int)Rc.ErrReceive:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_RECEIVE));
          break;
        case (int)Rc.ErrTimeout:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_TIMEOUT));
          break;
        case (int)Rc.ErrParameter:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_PARAMETER));
          break;
        case (int)Rc.ErrNomemory:
          AddLog(string.Format(Resources.SID_RC_FORMAT, Resources.SID_RC_ERR_NOMEMORY));
          break;
        default:
          AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
          break;
      }
    }

    /// <summary>
    /// Individual return code log output
    /// </summary>
    /// <param name="rc">Return code</param>
    private void IndividualErrorLog(int rc)
    {
      switch (_sendCommand)
      {
        case SendCommand.RebootController:
          {
            switch (rc)
            {
              case 0x80A0:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Accessing the save area"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.Trigger:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The trigger mode is not [external trigger]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.StartMeasure:
        case SendCommand.StopMeasure:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements are off"));
                break;
              case 0x80A0:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurement start processing could not be performed because the REMOTE terminal is off or the LASER_OFF terminal is on"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.AutoZero:
        case SendCommand.Timing:
        case SendCommand.Reset:
        case SendCommand.GetMeasurementValue:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.ChangeActiveProgram:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The change program setting is [terminal]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetProfile:
        case SendCommand.GetProfileAdvance:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements on and profile compression (time axis) off"));
                break;
              case 0x80A0:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"No profile data"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetBatchProfile:
        case SendCommand.GetBatchProfileAdvance:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Not [batch measurements on and profile compression (time axis) off]"));
                break;
              case 0x80A0:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"No batch data (batch measurements not run even once)"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;

        case SendCommand.StartStorage:
        case SendCommand.StopStorage:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Storage target setting is [OFF] (no storage)"));
                break;
              case 0x8082:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage condition setting is not [terminal/command]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetStorageStatus:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetStorageData:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not [OUT value]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetStorageProfile:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not profile, or batch measurements on and profile compression (time axis) off"));
                break;
              case 0x8082:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Batch measurements on and profile compression (time axis) off"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.GetStorageBatchProfile:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [high-speed (profile only)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The storage target setting is not profile, or batch measurements on and profile compression (time axis) off"));
                break;
              case 0x8082:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Not [batch measurements on and profile compression (time axis) off]"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.HighSpeedDataUsbCommunicationInitalize:
        case SendCommand.HighSpeedDataEthernetCommunicationInitalize:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                break;
              case 0x80A1:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        case SendCommand.PreStartHighSpeedDataCommunication:
        case SendCommand.StartHighSpeedDataCommunication:
          {
            switch (rc)
            {
              case 0x8080:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The operation mode is [advanced (with OUT measurement)]"));
                break;
              case 0x8081:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The data specified as the send start position does not exist"));
                break;
              case 0x80A0:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"A high-speed data communication connection was not established"));
                break;
              case 0x80A1:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"Already performing high-speed communication error (for high-speed communication)"));
                break;
              case 0x80A4:
                AddLog(string.Format(Resources.SID_RC_FORMAT, @"The send target data was cleared"));
                break;
              default:
                AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
                break;
            }
          }
          break;
        default:
          AddLog(string.Format(Resources.SID_NOT_DEFINE_FROMAT, rc));
          break;
      }
    }

    #endregion

    private void _btnGetProfile_Click(object sender, EventArgs e)
    {
      _sendCommand = SendCommand.GetProfile;

      using (ProfileForm profileForm = new ProfileForm())
      {
        if (DialogResult.OK == profileForm.ShowDialog())
        {
          _deviceData[_currentDeviceId].ProfileData.Clear();
          _deviceData[_currentDeviceId].MeasureData.Clear();
          LJV7IF_GET_PROFILE_REQ req = profileForm.Req;
          LJV7IF_GET_PROFILE_RSP rsp = new LJV7IF_GET_PROFILE_RSP();
          LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
          uint oneProfDataBuffSize = GetOneProfileDataSize();
          uint allProfDataBuffSize = oneProfDataBuffSize * req.byGetProfCnt;
          int[] profileData = new int[allProfDataBuffSize / Marshal.SizeOf(typeof(int))];

          using (PinnedObject pin = new PinnedObject(profileData))
          {
            int rc = NativeMethods.LJV7IF_GetProfile(_currentDeviceId, ref req, ref rsp, ref profileInfo, pin.Pointer, allProfDataBuffSize);
            AddLogResult(rc, Resources.SID_GET_PROFILE);
            if (rc == (int)Rc.Ok)
            {
              // Response data display
              AddLog(Utility.ConvertToLogString(rsp).ToString());
              AddLog(Utility.ConvertToLogString(profileInfo).ToString());

              AnalyzeProfileData((int)rsp.byGetProfCnt, ref profileInfo, profileData);

              // Profile export
              if (DataExporter.ExportOneProfile(_deviceData[_currentDeviceId].ProfileData.ToArray(), 0, _txtboxProfileFilePath.Text))
              {
                AddLog(@"###Saved!!");

                //StreamReader sr = new StreamReader("rf.txt", Encoding.Default);
                //String line;
                //int i = 0;
                //List<int> listX = new List<int>();
                //List<double> listY = new List<double>();
                //while ((line = sr.ReadLine()) != null)
                //{

                //  String[] aa = line.Split('\t');
                //  if (aa.Length > 1)
                //  {
                //    listX.Add(i);
                //    double zv = double.Parse( aa.ElementAt(1));
                //    zv = zv * 0.0001;
                //    listY.Add(zv);
                //  }
                //  i++;
                //  //Console.WriteLine(line.ToString());
                //}
                //chart.Series[0].Points.DataBindXY(listX, listY);
                //chart.Series[0].Points.DataBindY(listY);
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Get the profile data size
    /// </summary>
    /// <returns>Data size of one profile (in units of bytes)</returns>
    private uint GetOneProfileDataSize()
    {
      // Buffer size (in units of bytes)
      uint retBuffSize = 0;

      // Basic size
      int basicSize = (int)_cmbMeasureX.SelectedValue / (int)_cmbReceivedBinning.SelectedValue;
      basicSize /= (int)_cmbCompressX.SelectedValue;

      // Number of headers
      retBuffSize += (uint)basicSize * (_rdbtnOneHead.Checked ? 1U : 2U);

      // Envelope setting
      retBuffSize *= (_chkboxEnvelope.Checked ? 2U : 1U);

      //in units of bytes
      retBuffSize *= (uint)Marshal.SizeOf(typeof(uint));

      // Sizes of the header and footer structures
      LJV7IF_PROFILE_HEADER profileHeader = new LJV7IF_PROFILE_HEADER();
      retBuffSize += (uint)Marshal.SizeOf(profileHeader);
      LJV7IF_PROFILE_FOOTER profileFooter = new LJV7IF_PROFILE_FOOTER();
      retBuffSize += (uint)Marshal.SizeOf(profileFooter);

      return retBuffSize;
    }

    /// <summary>
    /// AnalyzeProfileData
    /// </summary>
    /// <param name="profileCount">Number of profiles that were read</param>
    /// <param name="profileInfo">Profile information structure</param>
    /// <param name="profileData">Acquired profile data</param>
    private void AnalyzeProfileData(int profileCount, ref LJV7IF_PROFILE_INFO profileInfo, int[] profileData)
    {
      int dataUnit = ProfileData.CalculateDataSize(profileInfo);
      AnalyzeProfileData(profileCount, ref profileInfo, profileData, 0, dataUnit);
    }

    /// <summary>
    /// AnalyzeProfileData
    /// </summary>
    /// <param name="profileCount">Number of profiles that were read</param>
    /// <param name="profileInfo">Profile information structure</param>
    /// <param name="profileData">Acquired profile data</param>
    /// <param name="startProfileIndex">Start position of the profiles to copy</param>
    /// <param name="dataUnit">Profile data size</param>
    private void AnalyzeProfileData(int profileCount, ref LJV7IF_PROFILE_INFO profileInfo, int[] profileData, int startProfileIndex, int dataUnit)
    {
      int readPropfileDataSize = ProfileData.CalculateDataSize(profileInfo);
      int[] tempRecvieProfileData = new int[readPropfileDataSize];

      // Profile data retention
      for (int i = 0; i < profileCount; i++)
      {
        Array.Copy(profileData, (startProfileIndex + i * dataUnit), tempRecvieProfileData, 0, readPropfileDataSize);

        _deviceData[_currentDeviceId].ProfileData.Add(new ProfileData(tempRecvieProfileData, profileInfo));
      }
    }

    private static void InvokeMehtod(List<double> listX, List<double> listY)
    {
      //Form1.form1.chart.Series[0].Points.DataBindY(listY);
      Form1.form1.chart.Series[0].Points.DataBindXY(listX, listY);

    }
    private delegate void InvokeDelegate(List<double> listX, List<double> listY);
    //private static InvokeComplete(IAsyncResult result)
    //{
    //  result.
    //  InvokeDelegate id = (InvokeDelegate)((IAsyncResult)result);
    //  id.EndInvoke(result);
    //}

    //delegate void richtexttip(List<double> listX, List<double> listY);
    //richtexttip richtext3 = delegate (List<double> listX, List<double> listY)
    //{
    //  Form1.form1.chart.Series[0].Points.DataBindXY(listX, listY);
    //};

    /// <summary>
    /// Method that is called from the DLL as a callback function
    /// </summary>
    /// <param name="buffer">Leading pointer of the received data</param>
    /// <param name="size">Size in units of bytes of one profile</param>
    /// <param name="count">Number of profiles</param>
    /// <param name="notify">Completion flag</param>
    /// <param name="user">Thread ID (value passed during initialization)</param>
    public static void ReceiveHighSpeedData(IntPtr buffer, uint size, uint count, uint notify, uint user)
    {
      // @Point
      // Take care to only implement storing profile data in a thread save buffer in the callback function.
      // As the thread used to call the callback function is the same as the thread used to receive data,
      // the processing time of the callback function affects the speed at which data is received,
      // and may stop communication from being performed properly in some environments.

      uint profileSize = (uint)(size / Marshal.SizeOf(typeof(int)));
      List<int[]> receiveBuffer = new List<int[]>();
      int[] bufferArray = new int[profileSize * count];
      Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));

      // Profile data retention
      for (int i = 0; i < count; i++)
      {
        int[] oneProfile = new int[profileSize];
        Array.Copy(bufferArray, i * profileSize, oneProfile, 0, profileSize);
        receiveBuffer.Add(oneProfile);
      }

      ThreadSafeBuffer.Add((int)user, receiveBuffer, notify);

      //List<double> listX = new List<double>();
      //List<double> listX2 = new List<double>();
      //List<double> listY = new List<double>();
      //List<double> listY2 = new List<double>();
      //if (www == 1)
      //{
      //  //StreamWriter file = new System.IO.StreamWriter("tt.txt", true);
      //  int midpos = bufferArray.Length / 2;
      //  double dx1 = 0.0;
      //  double dx2 = 0 - 0.01 * midpos;
      //  for (int i = 0; i < bufferArray.Length; i++)
      //  {
      //    int buf = bufferArray[i];
      //    if (i < midpos)
      //    {
      //      double xv = dx1;
      //      listX.Add(xv);
      //      double zbase = buf;
      //      if (zbase < -2147480000)
      //        zbase = -4.5;
      //      else
      //        zbase = zbase * 0.00001;
      //      double zv = zbase / Math.Sqrt(2.0);
      //      listY.Add(zv);
      //      dx1 += 0.01;
      //    }
      //    else if (i >= midpos)
      //    {
      //      double xv = dx2;
      //      listX.Add(xv);
      //      double zbase = buf;
      //      if (zbase < -2147480000)
      //        zbase = -4.5;
      //      else
      //        zbase = zbase * 0.00001;
      //      double zv = zbase / Math.Sqrt(2.0);
      //      listY.Add(zv);
      //      dx2 += 0.01;
      //    }
      //  }
      //  Form1.form1.chart.BeginInvoke(new InvokeDelegate(InvokeMehtod), new object[] { listX , listY });

      //  www = 0;
      //}
    }



    private void _btnHighSpeedDataUsbCommunicationInitalize_Click(object sender, EventArgs e)
    {
      _sendCommand = SendCommand.HighSpeedDataUsbCommunicationInitalize;

      using (HighSpeedInitalizeForm highSpeedInitalizeForm = new HighSpeedInitalizeForm(false))
      {
        if (DialogResult.OK == highSpeedInitalizeForm.ShowDialog())
        {
          _deviceData[_currentDeviceId].ProfileData.Clear();  // Clear the retained profile data.
          _deviceData[_currentDeviceId].MeasureData.Clear();

          int rc = NativeMethods.LJV7IF_HighSpeedDataUsbCommunicationInitalize(_currentDeviceId,
            (_chkOnlyProfileCount.Checked ? _callbackOnlyCount : _callback),
            highSpeedInitalizeForm.ProfileCnt, (uint)_currentDeviceId);
          // @Point
          // # When the frequency of calls is low, the callback function may not be called once per specified number of profiles.
          // # The callback function is called when both of the following conditions are met.
          //   * There is one packet of received data.
          //   * The specified number of profiles have been received by the time the call frequency has been met.

          AddLogResult(rc, Resources.SID_HIGH_SPEED_DATA_USB_COMMUNICATION_INITALIZE);

          if (rc == (int)Rc.Ok) _deviceData[_currentDeviceId].Status = DeviceStatus.UsbFast;
          _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
        }
      }
    }

    private void _btnPreStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
    {
      _sendCommand = SendCommand.PreStartHighSpeedDataCommunication;

      using (PreStartHighSpeedForm preStartHighSpeedForm = new PreStartHighSpeedForm())
      {
        if (DialogResult.OK == preStartHighSpeedForm.ShowDialog())
        {
          LJV7IF_HIGH_SPEED_PRE_START_REQ req = preStartHighSpeedForm.Req;
          // @Point
          // # SendPos is used to specify which profile to start sending data from during high-speed communication.
          // # When "Overwrite" is specified for the operation when memory full and 
          //   "0: From previous send complete position" is specified for the send start position,
          //    if the LJ-V continues to accumulate profiles, the LJ-V memory will become full,
          //    and the profile at the previous send complete position will be overwritten with a new profile.
          //    In this situation, because the profile at the previous send complete position is not saved, an error will occur.

          LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

          int rc = NativeMethods.LJV7IF_PreStartHighSpeedDataCommunication(_currentDeviceId, ref req, ref profileInfo);
          AddLogResult(rc, Resources.SID_PRE_START_HIGH_SPEED_DATA_COMMUNICATION);
          if (rc == (int)Rc.Ok)
          {
            // Response data display
            AddLog(Utility.ConvertToLogString(profileInfo).ToString());
            _profileInfo[_currentDeviceId] = profileInfo;
          }
        }
      }
    }

    private void _btnStartHighSpeedDataCommunication_Click(object sender, EventArgs e)
    {
      _sendCommand = SendCommand.StartHighSpeedDataCommunication;

      ThreadSafeBuffer.ClearBuffer(_currentDeviceId);
      _receivedProfileCountLabels[_currentDeviceId].Text = "0";
      int rc = NativeMethods.LJV7IF_StartHighSpeedDataCommunication(_currentDeviceId);
      // @Point
      //  If the LJ-V does not measure the profile for 30 seconds from the start of transmission,
      //  "0x00000008" is stored in dwNotify of the callback function.

      AddLogResult(rc, Resources.SID_START_HIGH_SPEED_DATA_COMMUNICATION);

      www = 1;
    }

    private void _btnHighSpeedDataCommunicationFinalize_Click(object sender, EventArgs e)
    {
      int rc = NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(_currentDeviceId);
      AddLogResult(rc, Resources.SID_HIGH_SPEED_DATA_COMMUNICATION_FINALIZE);

      switch (_deviceData[_currentDeviceId].Status)
      {
        case DeviceStatus.UsbFast:
          _deviceData[_currentDeviceId].Status = DeviceStatus.Usb;
          break;
        case DeviceStatus.EthernetFast:
          LJV7IF_ETHERNET_CONFIG config = _deviceData[_currentDeviceId].EthernetConfig;
          _deviceData[_currentDeviceId].Status = DeviceStatus.Ethernet;
          _deviceData[_currentDeviceId].EthernetConfig = config;
          break;
        default:
          break;
      }
      _deviceStatusLabels[_currentDeviceId].Text = _deviceData[_currentDeviceId].GetStatusString();
    }

    private void btnLoadTxtData2_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("t2.txt", Encoding.Default);
      String line;
      int i = 0;
      List<int> listX = new List<int>();
      List<double> listY = new List<double>();
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split('\t');
        if (aa.Length > 1)
        {
          listX.Add(i);
          double zv = double.Parse(aa.ElementAt(1));
          if (zv < -2147480000)
            zv = -4.5;
          else
            zv = zv * 0.00001;
          listY.Add(zv);
        }
        i++;
        //Console.WriteLine(line.ToString());
      }
      chart.Series[0].Points.DataBindXY(listX, listY);
      //chart.Series[0].Points.DataBindY(listY);
    }

    private void btnLoadTxtData3_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("t2.txt", Encoding.Default);
      String line;
      int i = 0;
      List<double> listX = new List<double>();
      List<double> listY = new List<double>();
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split('\t');
        if (aa.Length > 2)
        {
          double xv = double.Parse(aa.ElementAt(0)) * 0.00001;
          listX.Add(xv);
          double zv = double.Parse(aa.ElementAt(2));
          if (zv < -2147480000)
            zv = -4.5;
          else
            zv = zv * 0.00001 / Math.Sqrt(2.0);// + (xv + 4.0) / Math.Sqrt(2.0);
          listY.Add(zv);
        }
        i++;
        //Console.WriteLine(line.ToString());
      }
      chart.Series[0].Points.DataBindXY(listX, listY);
      //chart.Series[0].Points.DataBindY(listY);
    }

    private void btnLoadTxtData4_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("t2.txt", Encoding.Default);
      String line;
      int i = 0;
      List<double> listX = new List<double>();
      List<double> listX2 = new List<double>();
      List<double> listY = new List<double>();
      List<double> listY2 = new List<double>();
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split('\t');
        if (aa.Length > 1)
        {
          double xbase = double.Parse(aa.ElementAt(0)) * 0.00001;
          double xv = (xbase - 4.0) / Math.Sqrt(2.0) - 4 / Math.Sqrt(2.0);
          double xv2 = (xbase + 4.0) / Math.Sqrt(2.0) + 4 / Math.Sqrt(2.0);
          listX.Add(xv);
          listX2.Add(xv2);
          double zbase = double.Parse(aa.ElementAt(2));
          if (zbase < -2147480000)
            zbase = -4.5;
          else
            zbase = zbase * 0.00001;
          double zv = zbase;  // / Math.Sqrt(2.0);
          double zbase2 = double.Parse(aa.ElementAt(1));
          if (zbase2 < -2147480000)
            zbase2 = -4.5;
          else
            zbase2 = zbase2 * 0.00001;
          double zv2 = zbase2;  // / Math.Sqrt(2.0);
          listY.Add(zv);
          listY2.Add(zv2);
        }
        i++;
        //Console.WriteLine(line.ToString());
      }
      foreach (double xv in listX2)
        listX.Add(xv);
      foreach (double zv in listY2)
        listY.Add(zv);
      chart.Series[0].Points.DataBindXY(listX, listY);
      //chart.Series[0].Points.DataBindY(listY);
    }

    private void _timerHighSpeedReceive_Tick(object sender, EventArgs e)
    {
      int count = 0;
      uint notify = 0;
      int batchNo = 0;
      for (int i = 0; i < NativeMethods.DeviceCount; i++)
      {
        if (_chkOnlyProfileCount.Checked)
        {
          _receivedProfileCountLabels[i].Text = ThreadSafeBuffer.GetCount(i, out notify, out batchNo).ToString();
        }
        else
        {
          List<int[]> data = ThreadSafeBuffer.Get(i, out notify, out batchNo);
          if (data.Count == 0) continue;

          foreach (int[] profile in data)
          {
            if (_deviceData[i].ProfileData.Count < Define.WRITE_DATA_SIZE)
            {
              _deviceData[i].ProfileData.Add(new ProfileData(profile, _profileInfo[i]));
              drawLine(profile);
              break;
            }
            count++;
          }
          _receivedProfileCountLabels[i].Text = (Convert.ToInt32(_receivedProfileCountLabels[i].Text) + count).ToString();
        }

        if (notify != 0)
        {
          AddLog(string.Format("  notify[{0}] = {1,0:x8}\tbatch[{0}] = {2}", i, notify, batchNo));
        }
      }
    }

    private void _chkStartTimer_CheckedChanged(object sender, EventArgs e)
    {
      bool isStart = _chkStartTimer.Checked;
      if (isStart)
      {
        _timerHighSpeedReceive.Interval = (int)_numInterval.Value;
        _timerHighSpeedReceive.Start();
      }
      else
      {
        _timerHighSpeedReceive.Stop();
      }
      _numInterval.Enabled = !isStart;
      _chkOnlyProfileCount.Enabled = !isStart;
    }

    private void drawLine(int[] profile)
    {
      List<double> listX_B_Mid = new List<double>();
      List<double> listX_B_Left = new List<double>();
      List<double> listX_A_Mid = new List<double>();
      List<double> listX_A_Right = new List<double>();
      List<double> listY = new List<double>();
      List<double> listY2 = new List<double>();
      List<double> listY_B_Left = new List<double>();
      List<double> listY_A_Right = new List<double>();
      double last_A = 0.0;
      double last_B = 0.0;
      //if (www == 1)
      {
        //StreamWriter file = new System.IO.StreamWriter("tt.txt", true);
        int midpos = profile.Length / 2;
        double dx1 = 0.0;
        double dx2 = -0.0;
        double xxx = 0;
        int aaa = 0;

        aaa = 0;
        for (int i = 0; i < midpos; i++)
        {
          int buf = profile[i];
          //if (buf > -2147480000 && aaa < 200)
          {
            double xv = dx1;
            //listX.Add(xxx);
            //xxx += 1.0;
            double zbase_a = buf;
            if (zbase_a < -2147480000)
              zbase_a = -4.5;
            else
            {
              zbase_a = zbase_a * 0.00001;
              double zv2 = 4.0 - zbase_a;  // / Math.Sqrt(2.0);
              zv2 = (xv + 4.5) / Math.Sqrt(2.0) - zv2 / Math.Sqrt(2.0) + 2.0;
              listY_A_Right.Add(zv2);
              if (listX_A_Mid.Count > 0)
              {
                if (4.0 - zbase_a < 4.0 - last_A)
                  listX_A_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 - Math.Abs(last_A - zbase_a))));
                else
                  listX_A_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 + Math.Abs(last_A - zbase_a))));
                last_A = zbase_a;
              }
              else
              {
                listX_A_Mid.Add(zbase_a);
                last_A = zbase_a;
              }
            }
          }
        }

        for (int i = midpos; i < profile.Length - 1; i++)
        {
          int buf = profile[i];
          //if (buf > -2147480000 && aaa < 200)
          {
            double xv = dx1;
            //listX.Add(xxx);
            xxx += 1.0;
            double zbase_b = buf;
            if (zbase_b < -2147480000)
              zbase_b = -4.5;
            else
            {
              zbase_b = zbase_b * 0.00001;
              double zv2 = 4.0 - zbase_b;
              zv2 = (4.5 - xv) / Math.Sqrt(2.0) - zv2 / Math.Sqrt(2.0) + 2.0;
              listY_B_Left.Add(zv2);
              if (listX_B_Mid.Count > 0)
              {
                if (4.0 - zbase_b > 4.0 - last_B)
                  listX_B_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 - Math.Abs(last_B - zbase_b))));
                else
                  listX_B_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 + Math.Abs(last_B - zbase_b))));
                last_B = zbase_b;
              }
              else
              {
                listX_B_Mid.Add(zbase_b);
                last_B = zbase_b;
              }
            }
            aaa++;
          }
        }

        //InvokeDelegate id = new InvokeDelegate(InvokeMehtod);
        //id.BeginInvoke(listX, listY, new AsyncCallback(), "AsycState:OK"));

        listY_B_Left = listY_B_Left.Take(300).ToList<double>();
        listY_B_Left.Reverse();
        listX_B_Mid = listX_B_Mid.Take(300).ToList<double>();
        listX_B_Mid.Reverse();
        listY_A_Right.Reverse();
        listY_A_Right = listY_A_Right.Take(300).ToList<double>();
        listX_A_Mid.Reverse();
        listX_A_Mid = listX_A_Mid.Take(300).ToList<double>();

        double maxleft = 0.0;
        if (listY_A_Right.Count > 0)
          maxleft = listY_A_Right.Max();
        double maxright = 0.0;
        if (listY_B_Left.Count > 0)
          maxright = listY_B_Left.Max();
        if (maxleft != 0.0 && maxright != 0.0)
        {
          double cj = maxleft - maxright;
          for (int ii = 0; ii < listY_B_Left.Count; ii++)
            listY_B_Left[ii] = listY_B_Left[ii] + cj;

          int pos = listY_B_Left.LastIndexOf(maxleft);
          listY_B_Left = listY_B_Left.Take(pos).ToList<double>();
          listX_B_Mid = listX_B_Mid.Take(pos).ToList<double>();
          pos = listY_A_Right.IndexOf(maxleft);
          listY_A_Right = listY_A_Right.GetRange(pos, listY_A_Right.Count - pos);
          listX_A_Mid = listX_A_Mid.GetRange(pos, listX_A_Mid.Count - pos);
        }

        foreach (double zv in listY_A_Right)
          listY_B_Left.Add(zv);

        //listX.Clear();
        //double j = -3.0 / Math.Sqrt(2.0);
        //for (int i = 0; i < listY_B_Left.Count; i++)
        //{
        //  listX.Add(j);
        //  j += 0.01 / Math.Sqrt(2.0);
        //}

        listX_A_Right.Clear();
        if (listX_A_Mid.Count>0)
          listX_A_Right.Add(0.0);
        for (int ii = 0; ii < listX_A_Mid.Count - 1; ii++)
        {
          listX_A_Right.Add(listX_A_Right.Last() + listX_A_Mid[ii]);
        }
        listX_B_Left.Clear();
        if (listX_B_Mid.Count > 0)
          listX_B_Left.Add(0.0);
        for (int ii = listX_B_Mid.Count - 1; ii > 0; ii--)
        {
          listX_B_Left.Insert(0, listX_B_Left.First() - listX_B_Mid[ii]);
        }
        foreach (double xv in listX_A_Right)
          listX_B_Left.Add(xv);

        IAsyncResult aResult = Form1.form1.chart.BeginInvoke(new InvokeDelegate(InvokeMehtod), new object[] { listX_B_Left, listY_B_Left });
        //Form1.form1.chart.EndInvoke(aResult);

        www = 0;
      }

    }

    private void button1_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("t2.txt", Encoding.Default);
      String line;
      int i = 0;
      List<double> listX_B_Mid = new List<double>();
      List<double> listX_B_Left = new List<double>();
      List<double> listX_A_Mid = new List<double>();
      List<double> listX_A_Right = new List<double>();
      List<double> listY_B_Left = new List<double>();
      List<double> listY_A_Right = new List<double>();
      double last_A = 0.0;
      double last_B = 0.0;
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split('\t');
        if (aa.Length > 1)
        {
          double xbase = double.Parse(aa.ElementAt(0)) * 0.00001;
          double xv = xbase;
          double zbase_a = double.Parse(aa.ElementAt(1));
          if (zbase_a < -2147480000)
            zbase_a = -4.5;
          else
          {
            zbase_a = zbase_a * 0.00001;
            double zv2 = 4.0 - zbase_a;  // / Math.Sqrt(2.0);
            zv2 = (xv + 4.5) / Math.Sqrt(2.0) - zv2 / Math.Sqrt(2.0) + 2.0;
            listY_A_Right.Add(zv2);
            if (listX_A_Mid.Count > 0)
            {
              if (4.0 - zbase_a < 4.0 - last_A)
                listX_A_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs( (0.01 - Math.Abs (last_A - zbase_a))));
              else
                listX_A_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 + Math.Abs(last_A - zbase_a))));
              last_A = zbase_a;
            }
            else
            {
              listX_A_Mid.Add(zbase_a);
              last_A = zbase_a;
            }
          }
          double zbase_b = double.Parse(aa.ElementAt(2));
          if (zbase_b < -2147480000)
            zbase_b = -4.5;
          else
          {
            zbase_b = zbase_b * 0.00001;
            double zv2 = 4.0 - zbase_b;
            zv2 = (4.5 - xv) / Math.Sqrt(2.0) - zv2 / Math.Sqrt(2.0) + 2.0;
            listY_B_Left.Add(zv2);
            if (listX_B_Mid.Count > 0)
            {
              if (4.0 - zbase_b > 4.0 - last_B)
                listX_B_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 - Math.Abs(last_B - zbase_b))));
              else
                listX_B_Mid.Add(Math.Sqrt(2.0) / 2 * Math.Abs((0.01 + Math.Abs(last_B - zbase_b))));
              last_B = zbase_b;
            }
            else
            {
              listX_B_Mid.Add(zbase_b);
              last_B = zbase_b;
            }
          }
        }
        i++;
      }

      listY_B_Left = listY_B_Left.Take(300).ToList<double>();
      listY_B_Left.Reverse();
      listX_B_Mid = listX_B_Mid.Take(300).ToList<double>();
      listX_B_Mid.Reverse();
      listY_A_Right.Reverse();
      listY_A_Right = listY_A_Right.Take(300).ToList<double>();
      listX_A_Mid.Reverse();
      listX_A_Mid = listX_A_Mid.Take(300).ToList<double>();

      double maxleft = 0.0;
      if (listY_A_Right.Count > 0)
        maxleft = listY_A_Right.Max();
      double maxright = 0.0;
      if (listY_B_Left.Count > 0)
        maxright = listY_B_Left.Max();
      if (maxleft != 0.0 && maxright != 0.0)
      {
        double cj = maxleft - maxright;
        for (int ii = 0; ii < listY_B_Left.Count; ii++)
          listY_B_Left[ii] = listY_B_Left[ii] + cj;

        int pos = listY_B_Left.LastIndexOf(maxleft);
        listY_B_Left = listY_B_Left.Take(pos).ToList<double>();
        listX_B_Mid = listX_B_Mid.Take(pos).ToList<double>();
        pos = listY_A_Right.IndexOf(maxleft);
        listY_A_Right = listY_A_Right.GetRange(pos, listY_A_Right.Count - pos);
        listX_A_Mid = listX_A_Mid.GetRange(pos, listX_A_Mid.Count - pos);
      }



      foreach (double zv in listY_A_Right)
        listY_B_Left.Add(zv);

      listX_A_Right.Clear();
      listX_A_Right.Add(0.0);
      for (int ii = 0; ii < listX_A_Mid.Count - 1; ii++)
      {
        listX_A_Right.Add(listX_A_Right.Last() + listX_A_Mid[ii]);
      }
      listX_B_Left.Clear();
      listX_B_Left.Add(0.0);
      for (int ii = listX_B_Mid.Count - 1; ii > 0; ii--)
      {
        listX_B_Left.Insert(0, listX_B_Left.First() - listX_B_Mid[ii]);
      }
      foreach (double xv in listX_A_Right)
        listX_B_Left.Add(xv);

      chart.Series[0].Points.DataBindXY(listX_B_Left, listY_B_Left);
      //chart.Series[0].Points.DataBindY(listY_A_Right);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("B301GF/B301GF_CR10-LE.txt", Encoding.Default);
      String line;
      int i = 0;
      List<double> listX_B_Mid = new List<double>();
      List<double> listX_B_Left = new List<double>();
      List<double> listX_A_Mid = new List<double>();
      List<double> listX_A_Right = new List<double>();
      List<double> listY_B_Left = new List<double>();
      List<double> listY_A_Right = new List<double>();
      double last_A = 0.0;
      double last_B = 0.0;
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        //String[] aa = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase, );
        if (aa.Length > 1)
        {
          string xvaluestring = aa.ElementAt(0);
          if (xvaluestring.StartsWith("."))
            xvaluestring = xvaluestring.Insert(0, "0");
          else if (xvaluestring.StartsWith("-."))
            xvaluestring = xvaluestring.Insert(1, "0");
          double xbase = Convert.ToDouble(xvaluestring);
          double xv = xbase;
          listX_B_Left.Add(xv);

          string yvaluestring = aa.ElementAt(1);
          if (yvaluestring.StartsWith("."))
            yvaluestring = yvaluestring.Insert(0, "0");
          else if (yvaluestring.StartsWith("-."))
            yvaluestring = yvaluestring.Insert(1, "0");
          double ybase = double.Parse(yvaluestring);
          listY_B_Left.Add(ybase);

        }
        i++;
      }






      //foreach (double zv in listY_A_Right)
      //  listY_B_Left.Add(zv);

      //listX_A_Right.Clear();
      //listX_A_Right.Add(0.0);
      //for (int ii = 0; ii < listX_A_Mid.Count - 1; ii++)
      //{
      //  listX_A_Right.Add(listX_A_Right.Last() + listX_A_Mid[ii]);
      //}
      //listX_B_Left.Clear();
      //listX_B_Left.Add(0.0);
      //for (int ii = listX_B_Mid.Count - 1; ii > 0; ii--)
      //{
      //  listX_B_Left.Insert(0, listX_B_Left.First() - listX_B_Mid[ii]);
      //}
      //foreach (double xv in listX_A_Right)
      //  listX_B_Left.Add(xv);

      chart.Series[0].Points.DataBindXY(listX_B_Left, listY_B_Left);
      //chart.Series[0].Points.DataBindY(listY_A_Right);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      StreamReader sr = new StreamReader("B301GF/B301GF_CR10-TE.txt", Encoding.Default);
      String line;
      int i = 0;
      List<double> listX_B_Mid = new List<double>();
      List<double> listX_B_Left = new List<double>();
      List<double> listX_A_Mid = new List<double>();
      List<double> listX_A_Right = new List<double>();
      List<double> listY_B_Left = new List<double>();
      List<double> listY_A_Right = new List<double>();
      double last_A = 0.0;
      double last_B = 0.0;
      while ((line = sr.ReadLine()) != null)
      {

        String[] aa = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        //String[] aa = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase, );
        if (aa.Length > 1)
        {
          string xvaluestring = aa.ElementAt(0);
          if (xvaluestring.StartsWith("."))
            xvaluestring = xvaluestring.Insert(0, "0");
          else if (xvaluestring.StartsWith("-."))
            xvaluestring = xvaluestring.Insert(1, "0");
          double xbase = Convert.ToDouble(xvaluestring);
          double xv = xbase;
          listX_B_Left.Add(xv);

          string yvaluestring = aa.ElementAt(1);
          if (yvaluestring.StartsWith("."))
            yvaluestring = yvaluestring.Insert(0, "0");
          else if (yvaluestring.StartsWith("-."))
            yvaluestring = yvaluestring.Insert(1, "0");
          double ybase = double.Parse(yvaluestring);
          listY_B_Left.Add(ybase);

        }
        i++;
      }





      chart.Series[0].Points.DataBindXY(listX_B_Left, listY_B_Left);
      //chart.Series[0].Points.DataBindY(listY_A_Right);
    }
  }
}
