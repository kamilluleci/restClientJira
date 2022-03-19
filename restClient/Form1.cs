using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region UI Event Handlers
        private void cmdGO_Click(object sender, EventArgs e)
        {
            //Test urls (URI)
            //https://dry-cliffs-19849.herokuapp.com/
            //https://dry-cliffs-19849.herokuapp.com/users
            //https://dry-cliffs-19849.herokuapp.com/users.json
            //https://dry-cliffs-19849.herokuapp.com/users/2.html

            RestClient rClient = new RestClient();
            rClient.endPoint = txtRestURI.Text;

            if(rdoRollOwn.Checked)
            {
                rClient.authTech = authenticationTechnique.RollYourOwn;
                debugOutput("AuthTechnique: Roll Your Own");
                debugOutput("AuthType: Basic");
            }
            else
            {
                rClient.authTech = authenticationTechnique.NetworkCredential;
                debugOutput("AuthTechnique: NetworkCredential");
                debugOutput("AuthType:??? NetCred decides!");
            }
            
            rClient.userName = txtUserName.Text;
            rClient.userPassword = txtPassword.Text;
            
            debugOutput("Rest Client Created");
            
            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();

            debugOutput(strResponse);


        }

        #endregion

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText+Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message,ToString()+Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm2 frm2 = new frm2(this);
            frm2.Show();
        }
    }
}
