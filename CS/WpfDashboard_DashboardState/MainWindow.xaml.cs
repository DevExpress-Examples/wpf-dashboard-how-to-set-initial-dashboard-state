using DevExpress.DashboardCommon;
using System;
using System.Windows;
using System.Xml.Linq;

namespace WpfDashboard_DashboardState
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly string PropertyName = "DashboardState";
       
        public MainWindow()
        {
            InitializeComponent();

        }
       
        DashboardState GetDataFromString(string customPropertyValue) {
            DashboardState dState = new DashboardState();
            if(!string.IsNullOrEmpty(customPropertyValue)) {
                var xmlStateEl = XDocument.Parse(customPropertyValue);
                dState.LoadFromXml(xmlStateEl);
            }
            return dState;
        }

        private void dashboardControl_DashboardLoaded(object sender, DevExpress.DashboardWpf.DashboardLoadedEventArgs e) {

        }
        private void dashboardControl_SetInitialDashboardState(object sender, DevExpress.DashboardWpf.SetInitialDashboardStateWpfEventArgs e)
        {
            var state = GetDataFromString(dashboardControl.Dashboard.CustomProperties.GetValue(PropertyName));
            e.InitialState = state;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var dState = dashboardControl.GetDashboardState();
            var stateValue = dState.SaveToXml().ToString(SaveOptions.DisableFormatting);
            dashboardControl.Dashboard.CustomProperties.SetValue("DashboardState", stateValue);
            dashboardControl.Dashboard.SaveToXml("SampleDashboardWithState.xml");
        }

        private void DashboardControl_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            ExtractDataSourceConnectionParameters connParams = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            connParams.FileName = "Data\\SalesPerson.dat";
        }
    }
}
