Imports DevExpress.DashboardCommon
Imports System
Imports System.Windows
Imports System.Xml.Linq

Namespace WpfDashboard_DashboardState
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Private dState As New DashboardState()
		Public Sub New()
			InitializeComponent()

		End Sub
		Private Sub dashboardControl_DashboardLoaded(ByVal sender As Object, ByVal e As DevExpress.DashboardWpf.DashboardLoadedEventArgs)
			Dim data As XElement = e.Dashboard.UserData
			If data IsNot Nothing Then
				If data.Element("DashboardState") IsNot Nothing Then
					Dim dStateDocument As XDocument = XDocument.Parse(data.Element("DashboardState").Value)
					dState.LoadFromXml(XDocument.Parse(data.Element("DashboardState").Value))
				End If
			End If
		End Sub
		Private Sub dashboardControl_SetInitialDashboardState(ByVal sender As Object, ByVal e As DevExpress.DashboardWpf.SetInitialDashboardStateWpfEventArgs)
			e.InitialState = dState
		End Sub
		Private Sub Window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			dState = dashboardControl.GetDashboardState()
			Dim userData As New XElement("Root", New XElement("DateModified", DateTime.Now), New XElement("DashboardState", dState.SaveToXml().ToString(SaveOptions.DisableFormatting)))
			dashboardControl.Dashboard.UserData = userData
			dashboardControl.Dashboard.SaveToXml("SampleDashboardWithState.xml")
		End Sub

		Private Sub DashboardControl_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
			Dim connParams As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
			connParams.FileName = "Data\SalesPerson.dat"
		End Sub
	End Class
End Namespace
