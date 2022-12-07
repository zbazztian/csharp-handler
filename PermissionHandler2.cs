using System;
using System.IO;
using System.Web;

public class PermissionHandler2 : IHttpHandler
{
	public void ProcessRequest(HttpContext ctx)
	{
		String userName = ctx.Request.QueryString["user"];
		String salutation = "Dear User";

		String permissionsFile = "/home/permissions/" + userName + ".txt";
		if (File.Exists(permissionsFile)) {
			String permissions = File.ReadAllText(permissionsFile);
			ctx.Response.Write(salutation + "! Your permissions are as follows: " + permissions);
		} else {
			ctx.Response.Write("ERROR: Unknown user: " + userName);
		}
	}

	public bool IsReusable { get { return true; } }
}
