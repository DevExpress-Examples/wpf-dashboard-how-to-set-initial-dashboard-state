<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/145011512/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830540)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Set the Initial Dashboard State

This example demonstrates how to manage dashboard state to save and restore selected master filters values, current drill-down levels and other parameters such as Treemap layers.

![](./images/wpf-dashboard-set-initial-state.png)

When the main window closes, the [DashboardControl.GetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.GetDashboardState) obtains a dashboard state object. It is serialized to XML and added to the **XElement** object stored in the [Dashboard.UserData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.UserData). Subsequently the dashboard with the dashboard state data is saved to a file.

When the application starts, the DashboardControl loads the dashboard and the DashboardState object is deserialized in the [DashboardControl.DashboardLoaded](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.DashboardLoaded) event handler.

The dashboard state is restored using the [DashboardControl.SetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetDashboardState) method in the [DashboardControl.SetInitialDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetInitialDashboardState) event handler.

**See also:**

* [ASPxDashboard - How to specify a default dashboard state in code](https://github.com/DevExpress-Examples/aspxdashboard-how-to-specify-a-default-dashboard-state-in-code-t513681)
* [ASP.NET MVC Dashboard - How to specify a default dashboard state in code](https://github.com/DevExpress-Examples/aspnet-mvc-dashboard-how-to-specify-a-default-dashboard-state-in-code-t586607)
* [ASP.NET Core Dashboard Control - How to specify a default dashboard state in code](https://github.com/DevExpress-Examples/aspnet-core-dashboard-control-how-to-specify-a-default-dashboard-state-in-code-t607138)
* [WinForms Dashboard - How to Save and Restore the Dashboard State](https://github.com/DevExpress-Examples/winforms-dashboard-save-restore-dashboard-state)
