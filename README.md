# ExcelDNA with web requests

Simple demo repo for an ExcelDNA add-in with retrieves data via an API using HTTPClient.

Attempting to solve issues discussed in https://github.com/Excel-DNA/ExcelDna/issues/255.

## Development

The add-in can be debugged while running within Excel.

In Visual Studio:
- Open the solution
- Right-click **DerivitecExcelCommands** in the Solution Explorer
- Click **Properties**
- In the pane that opens, click **Debug**
- Select **Start external program:** and use the **Browse...** dialog to find the `.exe` for your instance of Excel. For new installs of Office, this commonly found at `C:\Program Files\Microsoft Office\root\Office16\EXCEL.EXE`
- Under **Start options** in the **Command line arguments** textbox enter:
	- `"DerivitecExcelCommands-AddIn.xll"` for 32-bit users
	- `"DerivitecExcelCommands-AddIn64.xll"` for 64-bit users