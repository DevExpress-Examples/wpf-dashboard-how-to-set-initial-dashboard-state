# How to Set the Initial Dashboard State

This example demonstrates how to manage dashboard state to save and restore selected master filters values, current drill-down levels and other parameters such as Treemap layers.

![](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-set-initial-dashboard-state/blob/18.1.6%2B/images/wpf-dashboard-set-initial-state.png)

When the main window closes, the [DashboardControl.GetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.GetDashboardState) obtains a dashboard state object. It is serialized to XML and added to the **XElement** object stored in the [Dashboard.UserData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.Dashboard.UserData). Subsequently the dashboard with the dashboard state data is saved to a file.

When the application starts, the DashboardControl loads the dashboard and the DashboardState object is deserialized in the [DashboardControl.DashboardLoaded](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.DashboardLoaded) event handler.

The dashboard state is restored using the [DashboardControl.SetDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetDashboardState) method in the [DashboardControl.SetInitialDashboardState](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.SetInitialDashboardState) event handler.
