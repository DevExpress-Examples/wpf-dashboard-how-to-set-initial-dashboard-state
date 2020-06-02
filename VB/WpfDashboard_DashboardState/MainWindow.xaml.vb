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

		Public Shared ReadOnly PropertyName As String = "DashboardState"
		Public Sub New()
			InitializeComponent()

		End Sub
		Private Function GetDataFromString(ByVal customPropertyValue As String) As DashboardState
			Dim dState As New DashboardState()
			If (Not String.IsNullOrEmpty(customPropertyValue)) Then
				Dim xmlStateEl = XDocument.Parse(customPropertyValue)
				dState.LoadFromXml(xmlStateEl)
			End If
			Return dState
		End Function
		Private Sub dashboardControl_DashboardLoaded(ByVal sender As Object, ByVal e As DevExpress.DashboardWpf.DashboardLoadedEventArgs)

		End Sub
		Private Sub dashboardControl_SetInitialDashboardState(ByVal sender As Object, ByVal e As DevExpress.DashboardWpf.SetInitialDashboardStateWpfEventArgs)
			Dim state = GetDataFromString(dashboardControl.Dashboard.CustomProperties.GetValue(PropertyName))
			e.InitialState = state
		End Sub
		Private Sub Window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
			Dim dState = dashboardControl.GetDashboardState()
			Dim stateValue = dState.SaveToXml().ToString(SaveOptions.DisableFormatting)
			dashboardControl.Dashboard.CustomProperties.SetValue("DashboardState", stateValue)
			dashboardControl.Dashboard.SaveToXml("SampleDashboardWithState.xml")
		End Sub

		Private Sub DashboardControl_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs)
			Dim connParams As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
			connParams.FileName = "Data\SalesPerson.dat"
		End Sub
	End Class
End Namespace
