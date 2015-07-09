using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using OneLogin.Saml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<div>SAML Test Bed</div>");
        Response.Write("<div>Page_Load</div>");
        
        string RawSAMLRequest = Request["SAMLRequest"];
        Response.Write("<div>Raw SAMLRequest :: "+RawSAMLRequest+"</div>");
        
        AccountSettings accountSettings = new AccountSettings();
        OneLogin.Saml.Response samlResponse = new Response(accountSettings);
        samlResponse.LoadXmlFromBase64(Request["SAMLRequest"]);
        
        if (samlResponse.IsValid())
        {
            Response.Write("OK!");
            Response.Write(samlResponse.GetNameID());
        }
        else
        {
            Response.Write("Failed");
        }
        
        
        
        //OneLogin.Saml.AuthRequest req = new AuthRequest(new AppSettings(), accountSettings);
        //Response.Redirect(accountSettings.idp_sso_target_url + "?SAMLRequest=" + Server.UrlEncode(req.GetRequest(AuthRequest.AuthRequestFormat.Base64)));
    }
}
