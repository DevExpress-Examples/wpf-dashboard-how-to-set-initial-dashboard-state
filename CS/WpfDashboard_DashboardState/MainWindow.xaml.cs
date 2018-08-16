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
        DashboardState dState = new DashboardState();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void dashboardControl_DashboardLoaded(object sender, DevExpress.DashboardWpf.DashboardLoadedEventArgs e)
        {
            XElement data = e.Dashboard.UserData;
            if (data != null)
            {
                if (data.Element("DashboardState") != null)
                {
                    XDocument dStateDocument = XDocument.Parse(data.Element("DashboardState").Value);
                    dState.LoadFromXml(XDocument.Parse(data.Element("DashboardState").Value));
                }
            }
        }
        private void dashboardControl_SetInitialDashboardState(object sender, DevExpress.DashboardWpf.SetInitialDashboardStateWpfEventArgs e)
        {
            e.InitialState = dState;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dState = dashboardControl.GetDashboardState();
            XElement userData = new XElement("Root", new XElement("DateModified", DateTime.Now), new XElement("DashboardState", dState.SaveToXml().ToString(SaveOptions.DisableFormatting)));
            dashboardControl.Dashboard.UserData = userData;
            dashboardControl.Dashboard.SaveToXml("SampleDashboardWithState.xml");
        }
    }
}
