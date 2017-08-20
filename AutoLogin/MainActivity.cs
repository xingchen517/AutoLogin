using Android.App;
using Android.Widget;
using Android.OS;
using AutoLogin.Model;

namespace AutoLogin
{
    [Activity(Label = "AutoLogin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText txtUserName = null;
        private EditText txtPwd = null;
        private CheckBox ckbxRemPwd = null;
        private CheckBox ckbxAutologin = null;
        private Button btnLogin = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            txtUserName = FindViewById<EditText>(Resource.Id.txtUsrName);
            txtPwd = FindViewById<EditText>(Resource.Id.txtPwd);
            ckbxRemPwd = FindViewById<CheckBox>(Resource.Id.ckBxRemPwd);
            ckbxAutologin = FindViewById<CheckBox>(Resource.Id.ckBxAutoLogin);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            var usrName = txtUserName.Text;
            var pwd = txtPwd.Text;
            if (new Login().Execute(usrName, pwd))
            {
                btnLogin.Text = "登录成功！";
            }
            else
            {
                btnLogin.Text = "失败，请重试！";
            }
        }
    }
}

